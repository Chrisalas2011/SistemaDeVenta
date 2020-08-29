using SistemaDeVentas.Datos;
using SistemaDeVentas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeVentas.Presentacion
{
    public partial class FrmDetalleVenta : Form
    {
        private static DataTable dt = new DataTable();
        private static FrmDetalleVenta _instancia = null;
        public FrmDetalleVenta()
        {
            InitializeComponent();
        }

        public static FrmDetalleVenta GetInstance()
        {
            if (_instancia == null)
                _instancia = new FrmDetalleVenta();

            return _instancia;
        }


        //BtnBuscarProducto
        private void button3_Click(object sender, EventArgs e)
        {
            FrmProducto frmProd = FrmProducto.GetInscance();
            frmProd.SetFlag("1");
            frmProd.ShowDialog();
        }

        internal void SetProducto(Producto producto)
        {
            txtClienteId.Text = producto.Id.ToString();
            txtProductoDescripcion.Text = producto.Nombre;
            txtStock.Text = producto.Stock.ToString();
            txtPrecioUnitario.Text = producto.PrecioVenta.ToString();
        }

        internal void SetVenta(Venta venta)
        {
            txtVentaId.Text = venta.Id.ToString();
            txtClienteId.Text = venta.Cliente.Id.ToString();
            txtClienteNombre.Text = venta.Cliente.Nombre;
            txtFecha.Text = venta.FechaVenta.ToShortDateString();
            cmbTipoDoc.Text = venta.TipoDocumento;
            txtNumeroDocumento.Text = venta.NumeroDocumento;    
        }

        // no va
        private void txtProductoDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
        //No va 
        private void txtClienteId_TextChanged(object sender, EventArgs e)
        {

        }
        //No va 

        private void txtProductoId_TextChanged(object sender, EventArgs e)
        {
            
        }

        //BTN GUARDAR   
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string sresultado = ValidarDatos();
                if (sresultado == "")
                { 
                        DetalleVenta detventa = new DetalleVenta();
                    detventa.Venta.Id = Convert.ToInt32(txtVentaId.Text);
                    detventa.Producto.Id = Convert.ToInt32(txtProductoId.Text);
                    detventa.Cantidad = Convert.ToDouble(txtCantidad.Text);
                    detventa.PrecioUnitario = Convert.ToDouble(txtPrecioUnitario.Text);

                    int DetVentaId = FDetalleVenta.Insertar(detventa);

                    if (DetVentaId > 0 )
                    {

                        FDetalleVenta.DisminuirStock(detventa);
                        FrmDetalleVenta_Load(null, null);
                        MessageBox.Show("El Producto se agrego correctamente");

                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("El producto no se pudo agregar, intente nuevamente");
                    }
                       
                    
                }
                else
                {
                    MessageBox.Show(sresultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void limpiar()
        {
            txtProductoId.Text = "";
            txtProductoDescripcion.Text = "";
            txtCantidad.Text = "1";
            txtStock.Text = "0";
            txtPrecioUnitario.Text = "";
        }

        private string ValidarDatos()
        {
            string resultado = "";
            if (txtProductoId.Text == "")
            {
                resultado = resultado + "Debe Seleccionar un producto \n";
            }
            if (Convert.ToInt32(txtCantidad.Text) > Convert.ToInt32(txtStock.Text))
            {
                resultado = resultado + "La cantidad que intenta vender supera el Stock \n";
            }
            return resultado;
        }

        private void FrmDetalleVenta_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FDetalleVenta.GetAll(Convert.ToInt32(txtVentaId.Text));
                dt = ds.Tables[0];
                dgvVentas.DataSource = dt;
                dgvVentas.Columns["VentaId"].Visible = false;
                dgvVentas.Columns["Id"].Visible = false;
                dgvVentas.Columns["ProductoId"].Visible = false;
                dgvVentas.Columns["PrecioVenta"].Visible = false;


                //Aqui ocultamos el label datos no encontrados, si se encuentra algun tipo de dato

                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                  //  dgvVentas_CellClick(null, null);
                }

                else
                {
                    lblDatosNoEncontrados.Visible = true;
                }
               // MostrarGuardarCancelar(false);

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvVentas.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkElimincar =
                    (DataGridViewCheckBoxCell)dgvVentas.Rows[e.RowIndex].Cells["Eliminar"];

                chkElimincar.Value = !Convert.ToBoolean(chkElimincar.Value);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try

            {
                if (MessageBox.Show("Realemte desea quitar los productos seleccionados?", "Eliminacion de Productos "
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvVentas.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            DetalleVenta detVenta = new DetalleVenta();
                            detVenta.Producto.Id = Convert.ToInt32(row.Cells["ProductoId"].Value);
                            detVenta.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                            detVenta.Id = Convert.ToInt32(row.Cells["Id"].Value);

                            if (FDetalleVenta.Eliminar(detVenta) > 0)
                            { 
                                if (FDetalleVenta.AumentarStock(detVenta) != 1)
                                {
                                    MessageBox.Show("No se pudo actulizar el Stock", "Eliminacion de Producto",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El Producto no pudo ser quitado de la venta. Intenten nuevamente", "Eliminacion de Producto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    FrmDetalleVenta_Load(null, null);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}

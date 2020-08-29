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
    public partial class FrmVenta : Form
    {
        private static DataTable dt = new DataTable();
        private object iVentaId;
        private static FrmVenta _instancia = null;

        public FrmVenta()
        {
            InitializeComponent();
        }
        public static FrmVenta GetInscance()
        {
            if (_instancia == null)
                _instancia = new FrmVenta();
            return _instancia;
        }
        private void FrmVenta_Load(object sender, EventArgs e)
        {
            if (dt.Rows.Count < 0)
            {
                lblDatosNoEncontrados.Visible = true;
            }

            try
            {
                DataSet ds = FVenta.GetAll();
                dt = ds.Tables[0];
                dgvVentas.DataSource = dt;

                //Aqui ocultamos el label datos no encontrados, si se encuentra algun tipo de dato

                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                    dgvVentas_CellClick(null, null);
                }

                else
                {
                    lblDatosNoEncontrados.Visible = true;
                }
                MostrarGuardarCancelar(false);

                lblUsuario.Text = Usuario.Nombre + " " + Usuario.Apellido; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        public void MostrarGuardarCancelar(bool b)
        {
            btnGuardar.Visible = b;
            btnCancelar.Visible = b;
            btnBuscarCliente.Visible = b;
            btnNuevo.Visible = !b;
            btnEditar.Visible = !b;
            

            dgvVentas.Enabled = !b;

            txtFecha.Enabled = b;
            cmbTipoDoc.Enabled = b;
            txtNumeroDocumento.Enabled = b;
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmCliente frmccli = new FrmCliente();
            frmccli.SetFlag("1");
            frmccli.ShowDialog();
        }


        public string ValidarDatos()
        {
            string resultado = "";
            if (txtClienteId.Text == "")
            {
                resultado = resultado + "Cliente \n";
            }
            if (txtNumeroDocumento.Text == "")
            {
                resultado = resultado + "Numero de Documento \n";
            }
            return resultado;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string sresultado = ValidarDatos();
                if (sresultado == "")
                {

                    if (txtId.Text == "")
                    {
                        Venta venta = new Venta();
                        venta.Cliente.Id = Convert.ToInt32(txtClienteId.Text);
                        venta.FechaVenta = txtFecha.Value;
                        venta.TipoDocumento = cmbTipoDoc.Text;
                        venta.NumeroDocumento = txtNumeroDocumento.Text;

                        venta.Cliente.Nombre=txtClienteNombre.Text;

                        int iVenta = FVenta.Insertar(venta);
                        if (iVenta  > 0)
                        {

                            FrmVenta_Load(null, null);
                            venta.Id = iVenta;
                            CargarDetalle(venta);
                        }
                    }
                    else
                    {
                        Venta venta = new Venta();
                        venta.Id = Convert.ToInt32(txtId.Text);
                        venta.Cliente.Id = Convert.ToInt32(txtClienteId.Text);
                        venta.FechaVenta = txtFecha.Value;
                        venta.TipoDocumento = cmbTipoDoc.Text;
                        venta.NumeroDocumento = txtNumeroDocumento.Text;


                        if (FVenta.Actulizar(venta) == 1)
                        {
                            MessageBox.Show("Datos Modificados Correctamente");
                            FrmVenta_Load(null, null);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Faltan cargar datos: \n" + sresultado);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CargarDetalle(Venta venta)
        {
            FrmDetalleVenta fDetVenta = FrmDetalleVenta.GetInstance();
            fDetVenta.SetVenta(venta);
            fDetVenta.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvVentas_CellClick(null, null);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);

            txtId.Text = "";
            txtClienteId.Text = "";
            txtClienteNombre.Text = "";
            txtNumeroDocumento.Text = "";
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt.Copy());
                dv.RowFilter = cmbBuscar.Text + " Like '" + txtBuscar.Text + "%'";

                dgvVentas.DataSource = dv;

                if (dv.Count == 0)
                {
                    lblDatosNoEncontrados.Visible = true;
                }
                else
                {
                    lblDatosNoEncontrados.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentas.CurrentRow != null)
            {

                txtId.Text = dgvVentas.CurrentRow.Cells["Id"].Value.ToString();
                txtClienteId.Text = dgvVentas.CurrentRow.Cells["ClienteId"].Value.ToString();
                txtClienteNombre.Text = dgvVentas.CurrentRow.Cells["Nombre"].Value.ToString() +" "+ dgvVentas.CurrentRow.Cells["Apellido"].Value.ToString();
                txtFecha.Text = dgvVentas.CurrentRow.Cells["FechaVenta"].Value.ToString();
                cmbTipoDoc.Text = dgvVentas.CurrentRow.Cells["TipoDocumento"].Value.ToString();
                txtNumeroDocumento.Text = dgvVentas.CurrentRow.Cells["NumeroDocumento"].Value.ToString();

            }
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dgvVentas.Columns["Eliminar"].Index)
            //{
            //    DataGridViewCheckBoxCell chkEliminar =
            //        (DataGridViewCheckBoxCell)dgvVentas.Rows[e.RowIndex].Cells["Eliminar"];

            //    chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            //}
        }

        internal void SetCliente(string sIdCliente, string sNombreCliente)
        {
            txtClienteId.Text = sIdCliente;
            txtClienteNombre.Text = sNombreCliente;
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVentas.CurrentRow != null)
            {
                Venta venta = new Venta();

                venta.Id = Convert.ToInt32 (dgvVentas.CurrentRow.Cells["Id"].Value.ToString());
                venta.Cliente.Id = Convert.ToInt32 (dgvVentas.CurrentRow.Cells["ClienteId"].Value.ToString());
                venta.Cliente.Nombre = dgvVentas.CurrentRow.Cells["Nombre"].Value.ToString() + " " + dgvVentas.CurrentRow.Cells["Apellido"].Value.ToString();
                venta.FechaVenta = Convert.ToDateTime (dgvVentas.CurrentRow.Cells["FechaVenta"].Value.ToString());
                venta.TipoDocumento =  dgvVentas.CurrentRow.Cells["TipoDocumento"].Value.ToString();
                venta.NumeroDocumento = dgvVentas.CurrentRow.Cells["NumeroDocumento"].Value.ToString();

                CargarDetalle(venta);

            }
        }
        //no va
        private void txtClienteId_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;

        }
    }
}

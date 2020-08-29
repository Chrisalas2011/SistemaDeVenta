using SistemaDeVentas.Datos;
using SistemaDeVentas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeVentas.Presentacion
{
    public partial class FrmProducto : Form
    {
        public static DataTable dt = new DataTable();
        private static FrmProducto _instancia;

        public FrmProducto()
        {
            InitializeComponent();
        }

        public static FrmProducto GetInscance()
        {
            if (_instancia == null)
                _instancia = new FrmProducto();
            return _instancia;
        }

        public void SetFlag(string sValor)
        {
            txtFlag.Text = sValor;

        }
        public void SetCategoria(string id, string descripcion)
        {
            txtCategoriaId.Text = id;
            txtCategoriaDescripcion.Text = descripcion;
        }


        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmCategoria frmcate = new FrmCategoria();
            frmcate.SetFlag("1");
            frmcate.ShowDialog();
        }


        private void btnCambiar_Click(object sender, EventArgs e)
        {
            if (Dialogo.ShowDialog() == DialogResult.OK)
            {
                imagen.BackgroundImage = null;
                imagen.Image = new Bitmap(Dialogo.FileName);
                imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {
            imagen.BackgroundImage = null; //Resources.transparente;
            imagen.Image = null;
            imagen.SizeMode = PictureBoxSizeMode.StretchImage;
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
                        Producto producto = new Producto();
                        producto.Nombre = txtNombre.Text;
                        producto.Categoria.Id = Convert.ToInt32 (txtCategoriaId.Text);
                        producto.Nombre = txtNombre.Text;
                        producto.Descripcion = txtDescripcion.Text;
                        producto.Stock =Convert.ToDouble (txtStock.Text);
                        producto.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                        producto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                        producto.FechaVencimiento = txtFechaVencimiento.Value;

                        MemoryStream ms = new MemoryStream();
                        if  (imagen.Image != null)

                        {
                            imagen.Image.Save(ms, imagen.Image.RawFormat);
                        }
                        else
                        {
                            imagen.Image = null; // Resources.transparente;
                            imagen.Image.Save(ms, imagen.Image.RawFormat);
                        }
                        producto.Imagen = ms.GetBuffer();

                        if (FProducto.Insertar(producto) > 0)
                        {
                            MessageBox.Show("Datos Insertados Correctamente");
                            FrmProducto_Load(null, null);
                        }
                    }
                    else
                    {
                        Producto producto = new Producto();

                        producto.Id = Convert.ToInt32 ( txtId.Text);
                        producto.Categoria.Id = Convert.ToInt32(txtCategoriaId.Text);
                        producto.Nombre = txtNombre.Text;
                        producto.Descripcion = txtDescripcion.Text;
                        producto.Stock = Convert.ToDouble(txtStock.Text);
                        producto.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                        producto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                        producto.FechaVencimiento = txtFechaVencimiento.Value;
                        MemoryStream ms = new MemoryStream();
                        if (imagen.Image != null)

                        {
                            imagen.Image.Save(ms, imagen.Image.RawFormat);
                        }
                        else
                        {
                            imagen.Image = null; //Resources.transparente;
                            imagen.Image.Save(ms, imagen.Image.RawFormat);
                        }
                        producto.Imagen = ms.GetBuffer();

                        if (FProducto.Actulizar(producto) == 1)
                        {
                            MessageBox.Show("Datos Modificados Correctamente");
                            FrmProducto_Load(null, null);
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


        public string ValidarDatos()
        {
            string resultado = "";
            if (txtNombre.Text == "")
            {
                resultado = resultado + "Nombre \n";
            }
            return resultado;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvProducto_CellClick(null, null);
        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);

            txtNombre.Text = "";
            txtCategoriaId.Text = "";
            txtCategoriaDescripcion.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            imagen.BackgroundImage = null; //Resources.transparente;
            imagen.Image = null;
            imagen.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Realemte desea eliminar los productos seleccionas?", "Eliminacion de Productos "
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dgvProducto.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Producto producto = new Producto();
                            producto.Id = Convert.ToInt32(row.Cells["Id"].Value);
                            if (FProducto.Eliminar(producto) != 1)
                            {
                                MessageBox.Show("El producto ha sido eliminado", "Eliminacion de producto",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    FrmProducto_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProducto.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvProducto.Rows[e.RowIndex].Cells["Eliminar"];

                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }


        private void dgvProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProducto.CurrentRow != null)
            {
               
                txtId.Text = dgvProducto.CurrentRow.Cells["Id"].Value.ToString();
                txtCategoriaId.Text = dgvProducto.CurrentRow.Cells["CategoriaId"].Value.ToString();
                txtCategoriaDescripcion.Text = dgvProducto.CurrentRow.Cells["CategoriaDescripcion"].Value.ToString();
                txtNombre.Text = dgvProducto.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvProducto.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtStock.Text = dgvProducto.CurrentRow.Cells["Stock"].Value.ToString();
                txtPrecioCompra.Text = dgvProducto.CurrentRow.Cells["PrecioCompra"].Value.ToString();
                txtPrecioVenta.Text = dgvProducto.CurrentRow.Cells["PrecioVenta"].Value.ToString();
                txtFechaVencimiento.Text = dgvProducto.CurrentRow.Cells["FechaVencimiento"].Value.ToString();

                imagen.BackgroundImage = null;


                byte[] b = (byte[])dgvProducto.CurrentRow.Cells["imagen"].Value;
                MemoryStream ms = new MemoryStream(b);
                imagen.Image = Image.FromStream(ms);
                imagen.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        private void FrmProducto_Load(object sender, EventArgs e)
        {
            if (dt.Rows.Count < 0)
            {
                lblDatosNoEncontrados.Visible = true;
            }
            try
            {
                DataSet ds = FProducto.GetAll();
                dt = ds.Tables[0];
                dgvProducto.DataSource = dt;
   
                //Aqui ocultamos el label datos no encontrados, si se encuentra algun tipo de dato
                if (dt.Rows.Count > 0)
                {
                    dgvProducto.Columns["imagen"].Visible = false;
                    lblDatosNoEncontrados.Visible = false;
                    dgvProducto_CellClick(null, null);
                }
                else
                {
                    lblDatosNoEncontrados.Visible = true;
                }
                MostrarGuardarCancelar(false);
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
            btnNuevo.Visible = !b;
            btnEditar.Visible = !b;
            btnEliminar.Visible = !b;

            dgvProducto.Enabled = !b;
            txtNombre.Enabled = b;

            btnCambiar.Visible = b;
            btnQuitar.Visible = b;
            btnBuscarCategoria.Visible = b;

            txtNombre.Enabled = b;
            txtCategoriaId.Enabled = b;
            txtCategoriaDescripcion.Enabled = b;
            txtDescripcion.Enabled = b;
            txtStock.Enabled = b;
            txtPrecioCompra.Enabled = b;
            txtPrecioVenta.Enabled = b;
        }
        

        private void dgvProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtFlag.Text == "1")
            {
                FrmDetalleVenta frmDetVenta = FrmDetalleVenta.GetInstance();

                if (dgvProducto.CurrentCell != null)
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dgvProducto.CurrentRow.Cells["Id"].Value.ToString());
                    producto.Nombre = dgvProducto.CurrentRow.Cells["Nombre"].Value.ToString();
                    producto.Stock = Convert.ToDouble (dgvProducto.CurrentRow.Cells["Stock"].Value.ToString());
                    producto.PrecioVenta = Convert.ToDouble(dgvProducto.CurrentRow.Cells["PrecioVenta"].Value.ToString());


                    frmDetVenta.SetProducto(producto); 
                        
                    frmDetVenta.Show();
                    Close();
                }
            }

        
        }
    }
}

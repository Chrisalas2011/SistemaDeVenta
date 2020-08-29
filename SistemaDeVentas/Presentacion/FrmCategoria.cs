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
    public partial class FrmCategoria : Form
    {
        private static DataTable dt = new DataTable();
        public FrmCategoria()
        {
            InitializeComponent();
        }

        public void SetFlag(string valor)
        {
            txtFlag.Text = valor;

        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = FCategoria.GetAll();
                dt = ds.Tables[0];
                dgvCategoria.DataSource = dt;

                //Aqui ocultamos el label datos no encontrados, si se encuentra algun tipo de dato

                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                    dgvCategoria_CellClick(null, null);
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



        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string sresultado = ValidarDatos();
                if (sresultado == "")
                {

                    if (txtId.Text == "")
                    {
                        Categoria categoria = new Categoria();
                        categoria.Descripcion = txtNombre.Text;
                       
                        if (FCategoria.Insertar(categoria) > 0)
                        {
                            MessageBox.Show("Datos Insertados Correctamente");
                            FrmCategoria_Load(null, null);
                        }
                    }
                    else
                    {
                        Categoria categoria = new Categoria();
                        categoria.Id = Convert.ToInt32((txtId.Text));
                        categoria.Descripcion = txtNombre.Text;

                        if (FCategoria.Actulizar(categoria) == 1)
                        {
                            MessageBox.Show("Datos Modificados Correctamente");
                            FrmCategoria_Load(null, null);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvCategoria_CellClick(null, null);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);

            txtId.Text = "";
            txtNombre.Text = "";
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

                dgvCategoria.DataSource = dv;

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

        private void dgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvCategoria.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar =
                    (DataGridViewCheckBoxCell)dgvCategoria.Rows[e.RowIndex].Cells["Eliminar"];

                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategoria.CurrentRow != null)
            {
                txtId.Text = dgvCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvCategoria.CurrentRow.Cells[2].Value.ToString();
                
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

        public void MostrarGuardarCancelar(bool b)
        {
            btnGuardar.Visible = b;
            btnCancelar.Visible = b;
            btnNuevo.Visible = !b;
            btnEditar.Visible = !b;
            btnEliminar.Visible = !b;

            dgvCategoria.Enabled = !b;

            //Descripcion de la categoria
            txtNombre.Enabled = b;
           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try

            {
                if (MessageBox.Show("Realemte desea elimincar las categoria seleccionas?", "Eliminacion de Categorias "
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvCategoria.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Categoria categoria = new Categoria();
                            categoria.Id = Convert.ToInt32(row.Cells["Id"].Value);
                            if (FCategoria.Eliminar(categoria) != 1)
                            {
                                MessageBox.Show("La categoria no pudo ser eliminada", "Eliminacion de categoria",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    FrmCategoria_Load(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvCategoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (txtFlag.Text == "1")
            {
                FrmProducto frmProd = FrmProducto.GetInscance();

                if (dgvCategoria.CurrentRow != null)
                {
                    frmProd.SetCategoria(dgvCategoria.CurrentRow.Cells[1].Value.ToString(), dgvCategoria.CurrentRow.Cells[2].Value.ToString());
                    frmProd.Show();
                    Close();
                }
            }
        }
    }
}

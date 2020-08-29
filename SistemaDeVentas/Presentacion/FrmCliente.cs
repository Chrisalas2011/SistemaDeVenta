using SistemaDeVentas.Datos;
using SistemaDeVentas.Entidades;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaDeVentas.Presentacion
{
    public partial class FrmCliente : Form
    {
        private static DataTable dt = new DataTable();
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            if (dt.Rows.Count < 0)
            {
                lblDatosNoEncontrados.Visible = true;
            }

            try
            {
                DataSet ds = FCliente.GetAll();
                dt = ds.Tables[0];
                dgvClientes.DataSource = dt;

                //Aqui ocultamos el label datos no encontrados, si se encuentra algun tipo de dato

                if (dt.Rows.Count > 0)
                {
                    lblDatosNoEncontrados.Visible = false;
                    dgvClientes_CellClick(null, null);
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
                    if (sresultado == "") { 

                if (txtId.Text == "")
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Dni = Convert.ToInt32(txtDni.Text);
                    cliente.Domicilio = txtDomicilio.Text;
                    cliente.Telefono = txtTelefono.Text;

                    if (FCliente.Insertar(cliente) > 0)
                    {
                        MessageBox.Show("Datos Insertados Correctamente");
                        FrmCliente_Load(null, null);
                    }
                }
                else
                {
                    Cliente cliente = new Cliente();

                    cliente.Id = Convert.ToInt32((txtId.Text));
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Dni = Convert.ToInt32(txtDni.Text);
                    cliente.Domicilio = txtDomicilio.Text;
                    cliente.Telefono = txtTelefono.Text;

                    if (FCliente.Actulizar(cliente) == 1)
                    {
                        MessageBox.Show("Datos Modificados Correctamente");
                        FrmCliente_Load(null, null);
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

        internal void SetFlag(string band)
        {
            txtFlag.Text = band;
        }

        public string ValidarDatos()
        {
            string resultado = "";
            if (txtNombre.Text == "")
            {
                resultado = resultado + "Nombre \n"; 
            }
            if (txtApellido.Text == "")
            {
                resultado = resultado + "Apellido";
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

            dgvClientes.Enabled = !b;
            txtNombre.Enabled = b;
            txtApellido.Enabled = b;
            txtDni.Enabled = b;
            txtDomicilio.Enabled = b;
            txtTelefono.Enabled = b;
        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);

            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            txtDomicilio.Text = "";
            txtTelefono.Text = ""; 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MostrarGuardarCancelar(false);
            dgvClientes_CellClick(null, null);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvClientes.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkElimincar =
                    (DataGridViewCheckBoxCell)dgvClientes.Rows[e.RowIndex].Cells["Eliminar"];

                    chkElimincar.Value = !Convert.ToBoolean(chkElimincar.Value);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                txtId.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                txtDni.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                txtDomicilio.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
               
            {
                if (MessageBox.Show("Realemte desea elimincar los clientes seleccionas?", "Eliminacion de Clientes "
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {

                    foreach (DataGridViewRow row in dgvClientes.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value))
                        {
                            Cliente cliente = new Cliente();
                            cliente.Id = Convert.ToInt32(row.Cells["Id"].Value);
                            if (FCliente.Eliminar(cliente) != 1)
                            {
                                MessageBox.Show("El cliente no pudo ser eliminado", "Eliminacion de cliente",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }

                    FrmCliente_Load(null, null);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dt.Copy());
                dv.RowFilter = cmbBuscar.Text + " Like '" + txtBuscar.Text + "%'";

                dgvClientes.DataSource = dv;

                if(dv.Count == 0)
                {
                    lblDatosNoEncontrados.Visible = true;
                }
                else
                {
                    lblDatosNoEncontrados.Visible = false;
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                if (txtFlag.Text == "1")
                {
                    FrmVenta frmVenta = FrmVenta.GetInscance();

                    if (dgvClientes.CurrentRow != null)
                    {
                        frmVenta.SetCliente(dgvClientes.CurrentRow.Cells[1].Value.ToString(), dgvClientes.CurrentRow.Cells[2].Value.ToString());
                        frmVenta.Show();
                        Close();
                    }
                }
        }
    } 
    
}
  
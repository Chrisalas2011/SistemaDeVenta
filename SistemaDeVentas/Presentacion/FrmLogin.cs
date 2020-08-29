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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataSet ds = FLogin.ValidarLogin(txtUsuario.Text, txtPassword.Text);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                Usuario.Apellido = dt.Rows[0]["Apellido"].ToString();
                Usuario.Nombre = dt.Rows[0]["Nombre"].ToString();
                Usuario.Id = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                Usuario.Dni = Convert.ToInt32(dt.Rows[0]["Dni"].ToString());
                Usuario.NombreUsuario = dt.Rows[0]["Usuario"].ToString();
                Usuario.Tipo = dt.Rows[0]["Tipo"].ToString();
                Usuario.Telefono = dt.Rows[0]["Telefono"].ToString();
                Usuario.Direccion = dt.Rows[0]["Direccion"].ToString();

                //FrmVenta.GetInscance().Show();
                MDIPrincipal mdi = new MDIPrincipal();
                mdi.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Usario y/o Password incorrectos");
                txtPassword.Text = "";
            }
               
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

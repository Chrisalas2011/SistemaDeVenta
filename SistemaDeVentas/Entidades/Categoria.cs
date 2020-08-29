using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.Entidades
{
    public class Categoria
    {
        private int _id;
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}

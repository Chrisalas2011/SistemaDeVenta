using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.Entidades
{
    public class Venta
    {

        private int _id;
        private Cliente _cliente;
        private DateTime _fechaVenta;
        private string _numeroDocumento;
        private string _tipoDocumento;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        public DateTime FechaVenta
        {
            get { return _fechaVenta; }
            set { _fechaVenta = value; }
        }
        public string NumeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }
        public string TipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }

        public Venta()
        {
            _cliente = new Cliente();
            

        }
    }
}


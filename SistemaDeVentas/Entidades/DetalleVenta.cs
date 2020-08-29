using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.Entidades
{
   public  class DetalleVenta
    {
        //Id, VentaId, ProductoId, Cantidad, PrecioUnitario
        private int _id;
        private Venta _venta;
        private Producto _producto;
        private double _cantidad;
        private double _precioUnitario;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Venta Venta
        {
            get { return _venta; }
            set { _venta = value; }
        }
        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        public double Cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        public double PrecioUnitario
        {
            get { return _precioUnitario; }
            set { _precioUnitario = value; }
        }

        public DetalleVenta()
        {
            _producto = new Producto();
            _venta = new Venta();
        }
    }
}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.Entidades
{
    public class Producto
    {
        private int _id;
        private Categoria _categoria;
        private string _nombre;
        private string _descripcion;
        private double _stock;
        private double _precioCompra;
        private double _precioventa;
        private DateTime _fechaVencimiento;
        private byte[] _imagen;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Categoria Categoria
        {
            get { return _categoria; }
            set { _categoria = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public double Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public double PrecioCompra
        {
            get { return _precioCompra; }
            set { _precioCompra = value; }
        }

        public double PrecioVenta
        {
            get { return _precioventa; }
            set { _precioventa = value; }
        }

        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        public Byte[] Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }

        public Producto()
        {
            _categoria = new Categoria();
        }

        public Producto(int id,Categoria categoria,string nombre, string descripcion,
            double stock, double precioCompra, double precioventa, DateTime fechaVencimiento, byte[] imagen)
        {
            Id = id;
            Categoria = categoria;
            Nombre = nombre;
            Descripcion = descripcion;
            Stock = stock;
            PrecioCompra = precioCompra;
            PrecioVenta = precioventa;
            FechaVencimiento = fechaVencimiento;
            Imagen = imagen;

        }



    }
}

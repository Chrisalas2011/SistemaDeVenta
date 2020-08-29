using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.Entidades
{
    public class Cliente
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _domicilio;
        private string _telefono;
        private int _dni;

        // para asingacion y modificacion de lo valores de esta clase 
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Domicilio
        {
            get { return _domicilio; }
            set { _domicilio = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public int Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }
        public Cliente()
        {

        }
        public Cliente(int id, string nombre, string apellido, string domicilio, string telefono, int dni)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._domicilio = domicilio;
            this._telefono = telefono;
            this._dni = dni;
        }


    }
}

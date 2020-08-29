using SisVenttas.Datos;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVentas.Entidades;

namespace SistemaDeVentas.Datos
{
    public class FCliente
    {

    
        public static DataSet GetAll()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                  
                };
           return FDBHelper.ExecuteDataSet("usp_Datos_FCliente_GetAll", dbParams);

        }

        public static int Insertar(Cliente cliente)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Nombre", SqlDbType.VarChar, 0, cliente.Nombre),
                    FDBHelper.MakeParam("@Apellido", SqlDbType.VarChar, 0, cliente.Apellido),
                    FDBHelper.MakeParam("@Dni", SqlDbType.VarChar, 0, cliente.Dni),
                    FDBHelper.MakeParam("@Telefono", SqlDbType.VarChar, 0, cliente.Telefono),
                    FDBHelper.MakeParam("@Domicilio", SqlDbType.VarChar, 0, cliente.Domicilio)
                };
            return Convert.ToInt32( FDBHelper.ExecuteScalar("usp_Datos_FCliente_Insertar", dbParams));

        }

        public static int Actulizar(Cliente cliente)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, cliente.Id),
                    FDBHelper.MakeParam("@Nombre", SqlDbType.VarChar, 0, cliente.Nombre),
                    FDBHelper.MakeParam("@Apellido", SqlDbType.VarChar, 0, cliente.Apellido),
                    FDBHelper.MakeParam("@Dni", SqlDbType.VarChar, 0, cliente.Dni),
                    FDBHelper.MakeParam("@Telefono", SqlDbType.VarChar, 0, cliente.Telefono),
                    FDBHelper.MakeParam("@Domicilio", SqlDbType.VarChar, 0, cliente.Domicilio)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FCliente_Actulizar", dbParams));

        }
        public static int Eliminar(Cliente cliente)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, cliente.Id),
                    
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FCliente_Eliminar ", dbParams));

        }
    }
}

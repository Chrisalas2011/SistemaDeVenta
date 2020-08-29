using SistemaDeVentas.Entidades;
using SisVenttas.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVentas.Datos
{
   public class FCategoria
    {

        public static DataSet GetAll()
        {

            SqlParameter[] dbParams = new SqlParameter[]
                {

                };
            return FDBHelper.ExecuteDataSet("usp_Datos_FCategoria_GetAll", dbParams);

        }

        public static int Insertar(Categoria categoria)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, categoria.Descripcion)
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FCategoria_Insertar", dbParams));

        }

        public static int Actulizar(Categoria categoria)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, categoria.Id),
                    FDBHelper.MakeParam("@Descripcion", SqlDbType.VarChar, 0, categoria.Descripcion),
                    
                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FCategoria_Actulizar", dbParams));

        }
        public static int Eliminar(Categoria categoria)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, categoria.Id),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FCategoria_Eliminar ", dbParams));

        }
    }
}

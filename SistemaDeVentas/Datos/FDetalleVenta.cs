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
    public static class FDetalleVenta
    {
        public static DataSet GetAll(int ventaId)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@VentaId", SqlDbType.Int, 0, ventaId),  
                };
            return FDBHelper.ExecuteDataSet("usp_Datos_FDetalleVenta_GetAll", dbParams);

        }

        public static int Insertar(DetalleVenta detalleVenta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                   
                    FDBHelper.MakeParam("@VentaId", SqlDbType.Int, 0, detalleVenta.Venta.Id),
                    FDBHelper.MakeParam("@ProductoId", SqlDbType.Int, 0, detalleVenta.Producto.Id),
                    FDBHelper.MakeParam("@Cantidad", SqlDbType.Decimal, 0, detalleVenta.Cantidad),
                    FDBHelper.MakeParam("@PrecioUnitario", SqlDbType.Decimal, 0, detalleVenta.PrecioUnitario),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FDetalleVenta_Insertar", dbParams));

        }

        //public static int Actulizar(DetalleVenta detalleVenta)
        //{
        //    SqlParameter[] dbParams = new SqlParameter[]
        //        {
        //            FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, detalleVenta.Venta.Id),
        //            FDBHelper.MakeParam("@VentaId", SqlDbType.Int, 0, detalleVenta.Venta.Id),
        //            FDBHelper.MakeParam("@ProductoId", SqlDbType.DateTime, 0, detalleVenta.Producto.Id),
        //            FDBHelper.MakeParam("@Cantidad", SqlDbType.VarChar, 0, detalleVenta.Cantidad),
        //            FDBHelper.MakeParam("@PrecioUnitario", SqlDbType.VarChar, 0, detalleVenta.PrecioUnitario), 
        //        };

        //    return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FDetalleVenta_Actulizar", dbParams));
        //}
        public static int Eliminar(DetalleVenta detalleVenta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    FDBHelper.MakeParam("@Id", SqlDbType.Int, 0, detalleVenta.Id),

                };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FDetalleVenta_Eliminar ", dbParams));

        }

        internal static int DisminuirStock(DetalleVenta detVenta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
               {
                    FDBHelper.MakeParam("@ProductoId", SqlDbType.Int, 0, detVenta.Producto.Id),
                    FDBHelper.MakeParam("@Cantidad", SqlDbType.Decimal, 0, detVenta.Cantidad), 
               };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FDetalleVenta_DisminuirStock", dbParams));
        }
        internal static int AumentarStock(DetalleVenta detVenta)
        {
            SqlParameter[] dbParams = new SqlParameter[]
               {
                    FDBHelper.MakeParam("@ProductoId", SqlDbType.Int, 0, detVenta.Producto.Id),
                    FDBHelper.MakeParam("@Cantidad", SqlDbType.Decimal, 0, detVenta.Cantidad),
               };
            return Convert.ToInt32(FDBHelper.ExecuteScalar("usp_Datos_FDetalleVenta_AumentarStock", dbParams));
        }


    }
}


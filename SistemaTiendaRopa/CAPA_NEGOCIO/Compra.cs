using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
using Newtonsoft.Json;

namespace CAPA_NEGOCIO
{
   public class Compra
    {
        public string TableName = "COMPRA";
        public int IdCompra { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int Proveedor { get; set; }

        public int Estado { get; set; }

        public List<Object> Detalles = new List<Object>();

        public Object Insertar(Compra Inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                if (Inst.IdCompra == -1)
                {
                    int idcompra = Convert.ToInt32(SqlADOConexion.SQLM.InsertObject(TableName, Inst));
                    foreach (Object Detalle in Inst.Detalles)
                    {
                        DetalleCompra NewId = new DetalleCompra();
                        NewId.IdDetalleCompra = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).IdDetalleCompra;
                        NewId.Compra = idcompra;
                        NewId.Producto = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).Producto;
                        NewId.Precio = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).Precio;
                        NewId.Cantidad = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).Cantidad;
                        NewId.Medida = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).Medida;
                        NewId.Subtotal = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).Subtotal;
                        NewId.IVA = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).IVA;
                        NewId.Total = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).Total;
                        NewId.TraerIdCompra(NewId);

                        NInventario i = new NInventario();
                        var cant = 0;
                        var existencia = 0;
                        var stock = 0;

                        cant = (JsonConvert.DeserializeObject<DetalleCompra>(Detalle.ToString())).Cantidad;
                        existencia = i.StockActual;
                        stock = existencia + cant;// operacion para aumentar stock
                        var id = Convert.ToInt32(NewId.Producto);
                        i.ActStock(i, id, stock);
                    }
                    return true;
                    // return SqlADOConexion.SQLM.InsertObject(TableName, Inst);
                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, Inst, "IdCompra");
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        public Object TraerCompra(Compra Inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                return SqlADOConexion.SQLM.TakeList(TableName, Inst, null);
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}

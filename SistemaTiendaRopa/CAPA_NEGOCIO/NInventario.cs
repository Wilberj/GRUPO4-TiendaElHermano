using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;

namespace CAPA_NEGOCIO
{
    public class NInventario
    {
        private string TableName = "INVENTARIO";
        public int IdInventario { get; set; }
        public int  Producto { get; set; }
        public DateTime Fecha { get; set; }
        public int Marca { get; set; }
        public int Talla { get; set; }
        public int PrecioCompra { get; set; }
        public string Unidad_Medida { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public int StockActual { get; set; }

        public Object Save(NInventario Inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                if (Inst.IdInventario == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, Inst);
                }
                else
                {
                    return SqlADOConexion.SQLM.UpdateObject(TableName, Inst, "IdInventario");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public object ActStock(NInventario Inst, int id, int cant)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "123");


                return SqlADOConexion.SQLM.ActualizarStock(cant, Inst, id);


            }
            catch (Exception)
            {
                throw;
            }
        }
        public Object GetInventario(NInventario Inst)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;

namespace CAPA_NEGOCIO
{
   public class Compra
    {
        public string TableName = "COMPRA";
        public int IdCompra { get; set; }

        public DateTime Fecha { get; set; }

        public string Descripcion { get; set; }

        public int Proveedor { get; set; }

        public int Usuario { get; set; }

        public int Estado { get; set; }


        public Object Insertar(Compra Inst)
        {
            try
            {
                SqlADOConexion.IniciarConexion("sa", "1234");
                if (Inst.IdCompra == -1)
                {
                    return SqlADOConexion.SQLM.InsertObject(TableName, Inst);
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

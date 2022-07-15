using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CAPA_NEGOCIO;

namespace PROYECTO_TIENDA.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        [HttpPost]

        public object InsertarProveedores(object ObjInst)
        {
            NProveedor Inst = JsonConvert.DeserializeObject<NProveedor>(ObjInst.ToString());
            Inst.Insertar(Inst);
            return true;
        }

        [HttpPost]

        public object TraerProveedores()
        {
            List<Object> Response = new List<Object>();
            NProveedor Inst = new NProveedor();
            Response.Add(Inst.TraerProveedor(Inst));


            TipoDocumento td = new TipoDocumento();
            Response.Add(td.Mostrar(td));

            return Response;

        }
    }
}

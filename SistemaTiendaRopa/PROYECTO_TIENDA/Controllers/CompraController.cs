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
    public class CompraController : ControllerBase
    {
        [HttpPost]

        public Object VerCompra()
        {
            List<Object> Response = new List<Object>();
            Compra Inst = new Compra();
            Response.Add(Inst.TraerCompra(Inst));

            NUsuarios Us = new NUsuarios();
            Response.Add(Us.GetUsuarios(Us));

            NProveedor Prov = new NProveedor();
            Response.Add(Prov.TraerProveedor(Prov));

            DetalleCompra dt = new DetalleCompra();
            Response.Add(dt.TraerDetalleCompra(dt));

            return Response;
        }

    }
}

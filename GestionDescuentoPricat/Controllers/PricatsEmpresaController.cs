using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionDescuentoPricat.Controllers
{
    [RoutePrefix("api/pricatsempresa")]
    public class PricatsEmpresaController : ApiController
    {

        private readonly IPricatsEmpresaServices _pricatsEmpresaServices;

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize registro service instance
        /// </summary>
        public PricatsEmpresaController()
        {
            _pricatsEmpresaServices = new PricatsEmpresaServices();
        }

        #endregion

        // GET api/registro
        public HttpResponseMessage Get()
        {
            var pricatsEmpresas = _pricatsEmpresaServices.GetAllPricatsEmpresas();
            if (pricatsEmpresas != null)
            {
                var pricatsEmpresaEntities = pricatsEmpresas as List<PricatsEmpresaEntity> ?? pricatsEmpresas.ToList();
                if (pricatsEmpresaEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, pricatsEmpresaEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Registro no encontrado");
        }

        // POST api/pricatsEmpresa/descuento/1/2/3/4/5
        [Route("descuento/{idPais?}/{tipoTransaccion?}/{glnProveedor?}/{glnComerciante?}/{bgm?}")]
        public HttpResponseMessage Descuento(string idPais, string tipoTransaccion, string glnProveedor, string glnComerciante, string bgm)
        {
            string validacion = _pricatsEmpresaServices.ValidacionDescuento(idPais, tipoTransaccion, glnProveedor, glnComerciante, bgm);

            if (validacion.Equals("Correcto"))
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Descuento realizado exitosamente");
            
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, validacion);
        }

    }
}

using AutoMapper;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using System.Collections.Generic;
using System.Linq;

namespace BusinessServices
{
    /// <summary>
    /// Offers services for product specific CRUD operations
    /// </summary>
    public class PricatsEmpresaServices : IPricatsEmpresaServices
    {
        private readonly UnitOfWork _unitOfWork;

        /// <summary>
        /// Public constructor.
        /// </summary>
        public PricatsEmpresaServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Fetches registro details by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public PricatsEmpresaEntity GetPricatsEmpresaById(int empresaId)
        {
            var pricatsEmpresa = _unitOfWork.PricatsEmpresaRepository.GetByID(empresaId);
            if (pricatsEmpresa != null)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<PRICATS_X_EMPRESA, PricatsEmpresaEntity>();
                });
                var pricatsModel = Mapper.Map<PRICATS_X_EMPRESA, PricatsEmpresaEntity>(pricatsEmpresa);

                return pricatsModel;
            }
            return null;
        }

        /// <summary>
        /// Fetches all the registros.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PricatsEmpresaEntity> GetAllPricatsEmpresas()
        {
            var pricatsEmpresas = _unitOfWork.PricatsEmpresaRepository.GetAll().ToList();
            if (pricatsEmpresas.Any())
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<PRICATS_X_EMPRESA, PricatsEmpresaEntity>();
                });
                var pricatsModels = Mapper.Map<List<PRICATS_X_EMPRESA>, List<PricatsEmpresaEntity>>(pricatsEmpresas);

                return pricatsModels;
            }
            return null;
        }

        /// <summary>
        /// Realiza validaciones concernientes
        /// </summary>
        /// <returns></returns>
        public string ValidacionDescuento(string idPais, string tipoTransaccion, string glnProveedor, string glnComerciante, string bgm)
        {
            if (!(idPais.Equals("CO")))
                return "Pais ingresado diferente a Colombia";

            if (tipoTransaccion.Equals("1"))
                return "Transaccion GDSN no valida saldos";

            if (!ValidacionProveedor(glnProveedor))
                return "Inconsistencia con GLN del proveedor";



            return "Correcto";
        }

        bool ValidacionProveedor(string _glnProveedor)
        {

            return true;
        }

    }
}

using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices
{
    public interface IPricatsEmpresaServices
    {
        PricatsEmpresaEntity GetPricatsEmpresaById(int empresaId);
        IEnumerable<PricatsEmpresaEntity> GetAllPricatsEmpresas();
        string ValidacionDescuento(string idPais, string tipoTransaccion, string glnProveedor, string glnComerciante, string bgm);
        //int CreatePricatsEmpresa(PricatsEmpresaEntity pricatsEmpresaEntity);
        //bool UpdatePricatsEmpresa(int empresaId, PricatsEmpresaEntity pricatsEmpresaEntity);
        //bool DeletePricatsEmpresa(int empresaId);
    }
}

using DataModel;
using System;

namespace BusinessEntities
{
    public class Crm_EmpresaEntity
    {
        public byte[] GGUID_EMPRESA { get; set; }
        public decimal ID_EMPRESA { get; set; }
        public Nullable<int> CANTIDADCODIGOS { get; set; }
        public bool IND_ESTADO_EMPRESA { get; set; }
        public System.DateTime FECHA_CREACION { get; set; }
        public Nullable<System.DateTime> FECHA_MODIFICACION { get; set; }
        public string USUARIO { get; set; }
        public string CONTRASENA { get; set; }
        public Nullable<bool> IND_DEVOLUCION { get; set; }
        public Nullable<bool> IND_ANTIGUO { get; set; }
        public Nullable<int> ID_ESTADO_GLN { get; set; }
        public Nullable<bool> IND_EN_PROCESO { get; set; }
        public Nullable<bool> IND_SOPORTE_VIGENTE { get; set; }

        public virtual EMPRESA EMPRESA { get; set; }
    }
}

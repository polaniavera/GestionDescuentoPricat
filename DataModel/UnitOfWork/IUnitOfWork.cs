
namespace DataModel.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Save method.
        /// </summary>
        void SavePpal();
        void SaveTrazabilidad();
    }
}

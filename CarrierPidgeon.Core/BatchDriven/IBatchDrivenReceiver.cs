using System.Data;
using System.Threading.Tasks;

namespace CarrierPidgeon.Core.BatchDriven
{
    public interface IBatchDrivenReceiver<TReceiveType> : IReceiver<TReceiveType>
        where TReceiveType : IEntity
    {
        DataTable Pull(params object[] parameters);

        Task<DataTable> PullAsync(params object[] parameters);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarrierPidgeon.Core.BatchDriven
{
    public interface IBatchDrivenReceiver<TReceiveType> : IReceiver<TReceiveType>
        where TReceiveType : IEntity
    {
        IEnumerable<TReceiveType> Pull(params object[] parameters);

        Task<IEnumerable<TReceiveType>> PullAsync(params object[] parameters);
    }
}

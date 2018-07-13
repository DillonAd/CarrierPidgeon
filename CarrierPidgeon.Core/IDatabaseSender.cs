using System.Threading.Tasks;

namespace CarrierPidgeon.Core
{
    public interface IDatabaseSender<TSendType> : ISender<TSendType>
        where TSendType : IEntity
    {
        void Send(string[] parameterNames, TSendType t);
        Task SendAsync(string[] parameterNames, TSendType t);
    }
}
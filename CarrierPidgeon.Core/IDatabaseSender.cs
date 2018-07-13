using System.Threading.Tasks;

namespace CarrierPidgeon.Core
{
    public interface IDatabaseSender<TSendType> : ISender<TSendType>
        where TSendType : IEntity
    {
        void Send(string[] names, TSendType t);
        Task SendAsync(string[] names, TSendType t);
    }
}
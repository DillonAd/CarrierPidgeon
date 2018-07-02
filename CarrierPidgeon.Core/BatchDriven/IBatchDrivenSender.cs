using System.Threading.Tasks;

namespace CarrierPidgeon.Core.BatchDriven
{
    public interface IBatchDrivenSender : ISender
    {
        void Push(params object[] parameters);
        Task PushAsync(params object[] parameters);
    }
}

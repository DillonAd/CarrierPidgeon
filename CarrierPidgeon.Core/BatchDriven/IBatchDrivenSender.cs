using System.Threading.Tasks;

namespace CarrierPidgeon.Core.BatchDriven
{
    public interface IBatchDrivenSender : ISender
    {
        string Command { get; }

        void Push(params object[] parameters);
        Task PushAsync(params object[] parameters);
    }
}

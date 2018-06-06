using System.Threading.Tasks;

namespace CarrierPidgeon.Contracts
{
    protected interface IExecutable
    {
        void Execute();
        Task ExecuteAsync();
    }
}

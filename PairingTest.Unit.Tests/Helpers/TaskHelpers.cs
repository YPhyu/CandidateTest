using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Helpers
{
    internal class TaskHelpers
    {
        public static Task<T> CreatePseudoTask<T>(T result)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
            tcs.SetResult(result);
            return tcs.Task;
        }
    }

}

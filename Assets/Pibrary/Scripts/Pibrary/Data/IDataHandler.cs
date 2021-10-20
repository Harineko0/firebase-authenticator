using System;
using System.Threading.Tasks;
using Pibrary.Config;
using UniRx;

namespace Pibrary.Data
{
    public interface IDataHandler<T>
    {
        public IObservable<LoadingState> OnStateChanged { get;  }
        public IReadOnlyReactiveProperty<T> Data { get; }
        public Task<T> FetchUserData(string uid);
    }
}
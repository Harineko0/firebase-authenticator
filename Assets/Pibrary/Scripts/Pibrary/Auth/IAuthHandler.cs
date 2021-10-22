using System;
using Pibrary.Config;

namespace Pibrary.Auth
{
    public interface IAuthHandler
    {
        public IObservable<LoadingState> OnStateChanged { get; }
        public void GoogleSignIn();
        public void EmailSignIn(string email, string password);
    }
}
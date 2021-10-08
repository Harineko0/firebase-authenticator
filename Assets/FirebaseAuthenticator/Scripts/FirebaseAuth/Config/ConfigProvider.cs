﻿using System;

namespace FirebaseAuth.Config
{
    public enum ConfigEnvironment
    {
        Development,
        Production,
    }

    public enum LoadingState
    {
        WaitingToLoad,
        Loading,
        Completed
    }

    interface IConfigProvider
    {
        public IObservable<LoadingState> OnStateChanged { get; }
        public FirebaseAuthConfig Config { get; }
        
    }
}
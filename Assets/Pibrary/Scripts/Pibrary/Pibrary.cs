﻿using Pibrary.Auth;
using Pibrary.Config;
using Pibrary.Data;
using UnityEngine;

namespace Pibrary
{
    public class Pibrary
    {
        #region Singleton
        
        private Pibrary() {}
        private static Pibrary instance = new Pibrary();
        public static Pibrary DefaultInstance { get => instance; }
        
        #endregion

        private IAuthHandler authHandler;
        public IAuthHandler AuthHandler
        {
            get { return authHandler; }
        }

        private IDataStore<SaveData> dataStore;
        public IDataStore<SaveData> DataStore
        {
            get { return dataStore; }
        }
        
        public void Initialize()
        {
            authHandler = new FirebaseAuthHandler();
            dataStore = new SerialDataStore<SaveData>();
        }
    }
}
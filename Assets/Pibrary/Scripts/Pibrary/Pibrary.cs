using System;
using Pibrary.Config;
using UniRx;
using UnityEngine;

namespace Pibrary
{
    public class Pibrary
    {
        private Pibrary() {}
        private static Pibrary instance = new Pibrary();
        public static Pibrary Instance { get => instance; }

        public void Initialize()
        {
            ConfigProvider.Initialize();
        }
    }
}
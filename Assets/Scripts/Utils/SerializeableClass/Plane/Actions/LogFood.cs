using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class LogFood : BaseFood
    {
        public const string Log = "Log";
        public override void Action()
        {
            Debug.Log($"[LogFood] - {Log}");
        }
    }
}
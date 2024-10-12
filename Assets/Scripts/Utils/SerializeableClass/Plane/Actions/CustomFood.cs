using System;
using UnityEngine;

namespace Utils
{
    [Serializable]
    public class CustomFood : BaseFood
    {
        public string CustomMessage;
        public override void Action()
        {
            Debug.Log($"[CustomFood] - {FoodName} - {CustomMessage} - {Cost}");
        }
    }
}
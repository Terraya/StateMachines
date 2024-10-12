using System;

namespace Utils
{
    [Serializable]
    public abstract class BaseFood: IBaseAction
    {
        public string FoodName;
        public float Cost;
        public abstract void Action();
    }
}
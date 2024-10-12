using System;

[Serializable]
public class BaseMonoAction : IBaseAction
{
    public string Hello;

    public BaseMonoAction()
    {
    }

    public virtual void Action() { }
}
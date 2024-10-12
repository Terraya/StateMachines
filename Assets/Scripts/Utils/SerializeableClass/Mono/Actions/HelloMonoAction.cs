using System;
using UnityEngine;

[Serializable]
public class HelloMonoAction : BaseMonoAction
{
    public override void Action()
    {
        Debug.Log(Hello);
    }
}
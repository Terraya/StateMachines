using System;
using UnityEngine;

[Serializable]
public class CustomMonoAction : BaseMonoAction
{
    public string CustomText;

    public override void Action()
    {
        Debug.Log(Hello);
    }
}
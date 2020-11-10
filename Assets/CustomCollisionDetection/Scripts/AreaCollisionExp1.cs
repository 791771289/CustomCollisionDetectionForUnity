using UnityEngine;
using System.Collections;
using System;
using navid021.CustomCollisionDetection;

public class AreaCollisionExp1 : AbstractAreaManager
{
    [Header("New Other")]
    public int numberInt = 1;

    protected override void OnOverlap(Action<object> action)
    {
        Action<object> act = action;
        if (act != null) {
            useAutoCallBack = false;
            act(numberInt);
        }
    }
}
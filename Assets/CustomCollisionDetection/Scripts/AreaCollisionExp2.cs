using UnityEngine;
using System.Collections;
using System;
using navid021.CustomCollisionDetection;

public class AreaCollisionExp2 : AbstractAreaManager
{
    protected override void OnOverlap(Action<object> action)
    {
        Action<object> act = action;
        if (act != null) {
            useAutoCallBack = false;
            act(color);
        }
    }
}
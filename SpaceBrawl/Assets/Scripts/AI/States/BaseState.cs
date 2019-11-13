using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public BaseState (GameObject comBody)
    {
        this.gameObject = comBody;
        this.transform = comBody.transform;
    }

    protected GameObject gameObject;
    protected Transform transform;

    public abstract Type Tick();
}
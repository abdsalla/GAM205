using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameObject rayVisual;
    private MeshRenderer gameObjectRenderer;
    private Color hostileColor;

    public Transform Target { get; private set; }

    public StateMachine stateMachine => GetComponent<StateMachine>();

    void OnEnable()
    {
        hostileColor = new Color(400f, 10f, 400f, 0f);
        gameObjectRenderer = this.GetComponentInChildren<MeshRenderer>();
        gameObjectRenderer.material.color = hostileColor;

        InitializeStateMachine();
    }

    private void InitializeStateMachine()
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(RevolveState), new RevolveState (this) },
            { typeof(ChaseState), new ChaseState (this) },
            { typeof(AttackState), new AttackState (this) }
        };

        GetComponent<StateMachine>().SetStates(states);

    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }

}
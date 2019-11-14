using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [Header("Visuals")]
    private GameObject rayVisual;
    private MeshRenderer gameObjectRenderer;
    private Color hostileColor;

    public Transform Target { get; private set; }

    public StateMachine stateMachine => GetComponent<StateMachine>();

    void OnEnable()
    {
        // Set different color for all AI
        hostileColor = new Color(400f, 10f, 400f, 0f);  
        gameObjectRenderer = this.GetComponentInChildren<MeshRenderer>();
        gameObjectRenderer.material.color = hostileColor;
        InitializeStateMachine(); // Statemachine call
    }

    private void InitializeStateMachine() // Statemachine dictionary that holds all relevant states
    {
        var states = new Dictionary<Type, BaseState>()
        {
            { typeof(RevolveState), new RevolveState (this) },
            { typeof(ChaseState), new ChaseState (this) },
            { typeof(AttackState), new AttackState (this) }
        };

        GetComponent<StateMachine>().SetStates(states);

    }

    public void SetTarget(Transform target) // Set target
    {
        Target = target;
    }

}
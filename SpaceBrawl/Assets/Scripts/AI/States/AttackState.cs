using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private AIController _aIController;
    private float attackTimer = 3f;

    public AttackState(AIController aIController) : base(aIController.gameObject)
    {
        _aIController = aIController;
    }

    public override Type Tick()
    {
        if (_aIController.Target == null) { return typeof(RevolveState); }

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            Debug.Log("Fired");
            _aIController.gameObject.GetComponent<Firing>().AutomatedFire();
            attackTimer = 3f;
        }

        return null;

    }
}
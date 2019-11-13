using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    private AIController _aIController;

    public ChaseState(AIController aIController) : base(aIController.gameObject)
    {
        _aIController = aIController;
    }

    public override Type Tick()
    {
        if (_aIController.Target == null) { return typeof(RevolveState); }

        transform.LookAt(_aIController.Target);
        transform.Translate(Vector3.forward * Time.deltaTime * GameManager.UFOSpeed);

        var distance = Vector3.Distance(transform.position, _aIController.Target.transform.position);
        if (distance <= GameManager.AttackRange)
        {
            return typeof(AttackState);
        }

        return null;
    }
}
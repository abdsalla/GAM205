using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveState : BaseState
{
    private AIController _aIController;
    private Quaternion desiredRotation;
    private Vector3? destination;
    private Vector3 direction;
    private float stopDistance = 1f;
    private float turnSpeed = 1f;
    private float rayDistance = 3.5f;

    public RevolveState (AIController aIController) : base( aIController.gameObject)
    {
        _aIController = aIController;
    }

    public override Type Tick()
    {
        Transform chaseTarget = CheckForAggro();
        if (chaseTarget != null)
        {
            _aIController.SetTarget(chaseTarget);
            return typeof(ChaseState);
        }

        if (destination.HasValue == false || Vector3.Distance (transform.position, destination.Value) <= stopDistance)
        {
            FindNextDestination();
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * turnSpeed);

        if (IsForwardBlocked())
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, .2f);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * GameManager.UFOSpeed);
        }

        Debug.DrawRay(transform.position, direction * rayDistance, Color.red);
        while (IsPathBlocked())
        {
            FindNextDestination();
        }

        return null;
    }

    private bool IsForwardBlocked()
    {
        Ray ray = new Ray (transform.position, transform.forward);
        return Physics.SphereCast(ray, .5f);
    }

    private bool IsPathBlocked()
    {
        Ray ray = new Ray(transform.position, direction);
        return Physics.SphereCast(ray, .5f);
    }

    private Transform CheckForAggro()
    {
        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;

        for (var i = 0; i < 24; i++)
        {
           if (Physics.Raycast(pos, direction, out hit)) // aggroRange)
           {
                var aIController = hit.collider.GetComponent<AIController>();
                if (aIController != null && aIController)
                {
                    return _aIController.transform;
                }
           } 
            return _aIController.transform;
        }

        return _aIController.transform;
    }

    private void FindNextDestination()
    {
        throw new NotImplementedException();
    }

    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    private GameManager instance;

    private void Awake()
    {
        instance = GameManager.Instance;
    }
    
    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref, grabbing active player", this);
            SetTarget();
            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.transform.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.transform.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target.transform);
        }
        else
        {
            transform.rotation = target.transform.rotation;
        }
    }

    void SetTarget()
    {
        target = GameObject.FindWithTag("Target");
    }
}
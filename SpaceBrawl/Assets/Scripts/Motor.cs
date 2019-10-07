using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float forceMult;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * forceMult;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * Time.deltaTime * forceMult;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(.8f, 0, 0, Space.Self);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-.8f, 0, 0, Space.Self);
        }
    }
}
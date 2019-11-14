using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float forceMult; // speed
    public Transform tf; // cached transform

    private void Awake()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    public void Move(string input) // Detect string of key press then move accordingly
    {
        switch (input)
        {
            case "W" :
                tf.position += tf.forward * Time.deltaTime * forceMult;
                break;
            case "S":
                tf.position += -tf.forward * Time.deltaTime * forceMult;
                break;
        }     
    }
}
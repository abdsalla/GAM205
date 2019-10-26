﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float forceMult;
    public Transform tf; 

    private void Awake()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    public void Move(string input)
    {
        switch (input)
        {
            case "W" :
                tf.position += tf.forward * Time.deltaTime * forceMult;
                break;
            case "S":
                tf.position += -tf.forward * Time.deltaTime * forceMult;
                break;
            case "A":
                tf.Rotate(0f, -5f, 0f);
                break;
            case "D":
                tf.Rotate(0f, 5f, 0f);
                break;
        }     
    }
}
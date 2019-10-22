using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public float forceMult;
    public Transform tf;

    private KeyCode lastHitKey;

    private void Awake()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    void Move(string input)
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
                tf.Rotate(0f, -5f, -1.75f);
                break;
            case "D":
                tf.Rotate(0f, 5f, 1.75f);
                break;
        }     
    }

    void OnGUI()
    {
        string keyString;
        if (Input.anyKey)
        {
            Debug.Log("Key Press Detected");
            if (Event.current.Equals(Event.KeyboardEvent("w")))
            {
                lastHitKey = Event.current.keyCode;
                keyString = lastHitKey.ToString();
                Move(keyString);
            }
            else if (Event.current.Equals(Event.KeyboardEvent("a")))
            {
                lastHitKey = Event.current.keyCode;
                keyString = lastHitKey.ToString();
                Move(keyString);
            }
            else if (Event.current.Equals(Event.KeyboardEvent("s")))
            {
                lastHitKey = Event.current.keyCode;
                keyString = lastHitKey.ToString();
                Move(keyString);
            }
            else if (Event.current.Equals(Event.KeyboardEvent("d")))
            {
                lastHitKey = Event.current.keyCode;
                keyString = lastHitKey.ToString();
                Move(keyString);
            }
        }              
    }
}
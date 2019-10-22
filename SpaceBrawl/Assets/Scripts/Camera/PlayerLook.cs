using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName; //input info
    [SerializeField] private string mouseYInputName; //input info
    [SerializeField] private float mouseSensitivity; // input info
    [SerializeField] private Transform playerBody; // for the player

    private float xAxisClamp;
    private float yAxisClamp;

    private void Awake()
    {
        LockCursor();// calls function
        xAxisClamp = 0.0f;
        yAxisClamp = .0f;
    }
    //for the mouse so you cant look up and down 
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        PlayerRotation(); //call's player rotation function 
    }

    private void PlayerRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime; //This is so we dont whip around that much. 
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime; 

        //parameters for x axis 
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;

            ClampXAxisRotationToValue(330.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;

            ClampXAxisRotationToValue(90.0f);
        }

        //parameters for y axis 
        if (yAxisClamp > 90.0f)
        {
            yAxisClamp = 90.0f;

            ClampYAxisRotationToValue(250.0f);
        }
        else if (yAxisClamp < -90.0f)
        {
            yAxisClamp = -90.0f;

            ClampYAxisRotationToValue(270.0f);
        }
        playerBody.Rotate(Vector3.up * mouseX);  //Lets the player rotate.
        playerBody.Rotate(Vector3.right * mouseY);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    private void ClampYAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.y = value;
        transform.eulerAngles = eulerRotation;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}

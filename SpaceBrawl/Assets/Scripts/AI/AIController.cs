using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private MeshRenderer gameObjectRenderer;
    private Color hostileColor;

    private enum State { Revolve, Chase, Evaluate };

    void OnEnable()
    {
        hostileColor = new Color(400f, 10f, 400f, 0f);
        gameObjectRenderer = this.GetComponentInChildren<MeshRenderer>();
        gameObjectRenderer.material.color = hostileColor;
    }
}
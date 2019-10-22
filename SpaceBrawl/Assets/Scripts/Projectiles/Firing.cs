using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    private bool overheating = false;
    private int shotCount;
    public float laserLifetime;
    public Transform muzzle;
    public GameObject shotPrefab;

    void Update()
    {
        if (overheating == false)
        {
            Fire();
        }   
    }

    void Fire()
    {
        OverheatCheck();

        if (Input.GetKeyDown(KeyCode.Space) && overheating != true)
        {
            GameObject activeRayShot = Instantiate(shotPrefab, muzzle.position, muzzle.rotation) as GameObject;
            shotCount++;
            Destroy(activeRayShot, laserLifetime);
            Debug.Log(5 - shotCount + " shot(s) til Overheat");
        }
    }

    void OverheatCheck()
    {
        if (shotCount > 5)
        {
            overheating = true;
        }
    }
}
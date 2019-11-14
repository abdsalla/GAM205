using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    [Header("Shot Limitations")]
    private bool overheating = false;
    private int shotCount;
    public float laserLifetime = 3f;

    [Header("Shot Body & Exit Point")]
    public Transform muzzle;
    public GameObject shotPrefab;

    void Update()
    {
        // If the Player's shooting function is not on cooldown
        if (overheating == false)
        {
            Fire(); // Check to see if the Player presses shoot
        }   
    }

    public void Fire() // Player shooting
    {
        StartCoroutine(OverheatCheck()); // Pre shot cooldown check

        if (Input.GetKeyDown(KeyCode.Space) && overheating == false && gameObject.GetComponent<TankData>()) // If the player can shoot
        {
            // Make shot and keep track of it
            GameObject activeRayShot = Instantiate(shotPrefab, muzzle.position, muzzle.rotation) as GameObject; 
            shotCount++;
            // Confirms shot is from the Player and not an Enemy for scoring purposes, then destroys shot after a certian amount of time
            activeRayShot.GetComponent<Shot>().isFromPlayer = true; 
            Destroy(activeRayShot, laserLifetime);
            Debug.Log(5 - shotCount + " shot(s) til Overheat");
        }
        StopCoroutine(OverheatCheck()); 
    }

    public void AutomatedFire() // Enemy Shooting
    {
        StartCoroutine(OverheatCheck()); 

        if (overheating == false && gameObject.GetComponent<AIController>()) // If the Enemy using this function can shoot
        {
            GameObject activeRayShot = Instantiate(shotPrefab, muzzle.position, muzzle.rotation) as GameObject;
            shotCount++;
            activeRayShot.GetComponent<Shot>().isFromPlayer = false;
            Destroy(activeRayShot, laserLifetime);
        }
        StopCoroutine(OverheatCheck());
    }

    IEnumerator OverheatCheck() // Cooldown Check
    {
        if (shotCount > 5) // If a unit has shot more than five times make them wait for few secs til they can shoot again
        {
            overheating = true;
            yield return new WaitForSeconds(laserLifetime);
            shotCount = 0;
            overheating = false;
        }
    }
}
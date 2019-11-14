using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Header("Shot Values")]
    public float travelSpeed;
    public float damageDealt;

    [Header("Scoring Values")]
    public bool isFromPlayer;
    public float pointsOnKill;

    private GameManager instance;

    private void OnEnable()
    {
        instance = GameManager.Instance;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * travelSpeed; // Every frame after they spawn, they will accelerate 
    }

    private void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.tag == "Player")
        {
            instance.currentPlayerData.ReceiveDamage(damageDealt); // deal damge to Player if the it was hit
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Threat Neutralized");
            Destroy(other.gameObject);  // Destroy Enemy on contact
            if (isFromPlayer == true)   
            {
                // If the Player destroyed this UFO and not another Enemy, award them points
                instance.AwardPoint(pointsOnKill);
                instance.currentPlayer.GetComponentInChildren<Text>().text = "Score: " + instance.score;
                Debug.Log("Points Awarded");
            }
            Destroy(gameObject);
        }
    }   
}
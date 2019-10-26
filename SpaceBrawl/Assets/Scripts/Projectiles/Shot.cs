using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float travelSpeed;
    public float damageDealt;

    private GameManager instance;

    private void OnEnable()
    {
        instance = GameManager.Instance;
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * travelSpeed;
    }

    private void OnCollisionEnter(Collision other)
    {
        TankData targetRef;
        
        if (other.gameObject.tag == "Player")
        {
            instance.currentPlayerData.ReceiveDamage(damageDealt);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            targetRef = other.gameObject.GetComponent<TankData>();
            targetRef.ReceiveDamage(damageDealt);
        }
    }   
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return instance; } }

    [Header("Player")]
    public GameObject player;
    public GameObject currentPlayer;
    public TankData currentPlayerData;

    [Header("Enemy")]
    public GameObject enemy;
    public int enemyCount;
    private int desiredAmount = 6;

    [Header("Spawn Locations")]
    public GameObject playerSpawn;
    public Transform[] enemySpawnPoints;   

    private static GameManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        PlayerSpawn();
        UpdateUIValues();
        EnemySpawn();
    }

    void UpdateUIValues()
    {
        currentPlayerData = currentPlayer.GetComponent<TankData>();
    }

    void PlayerSpawn()
    {
        if (!currentPlayer)
        {
            currentPlayer = Instantiate(player, playerSpawn.transform.position, playerSpawn.transform.rotation);
        }
    }

    void EnemySpawn()
    {
        if (enemyCount < desiredAmount)
        {
            for (int i = 0; i < desiredAmount; i++)
            {
                Instantiate(enemy, enemySpawnPoints[i].transform.position, playerSpawn.transform.rotation);
                enemyCount++;
            }
        }
    }
}
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
    public float score;

    [Header("Enemy")]
    public GameObject enemy;
    public int enemyCount;
    private int desiredAmount = 6;
    [SerializeField] private float ufoSpeed;
    public static float UFOSpeed => instance.ufoSpeed;
    [SerializeField] private float aggroRadius;
    public static float AggroRadius => instance.aggroRadius;
    [SerializeField] private float attackRange;
    public static float AttackRange => instance.attackRange;

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

        PlayerSpawn(); // Make the Player
        UpdateUIValues(); // Update their UI
        EnemySpawn(); // Make Enemies
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

    public void AwardPoint(float pointsEarned) // Award the Player with points 
    {
        score += pointsEarned;
    }

}
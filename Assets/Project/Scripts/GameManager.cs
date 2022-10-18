using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public float maxSpawnDelay = 7f;
    public int spawnCount;
    public float enemySpawnRadius = 1f;
  
    public GameObject sphere;
    public static GameManager _instance;
    public Joystick joystick;
    public Camera cam;
    public Player player;
    public float playerSpeed = 0.1f;
    public float AiSpeed = 0.1f;
    public float lookSpeed = 0.2f;
    public List<Enemy> triggeredEnemyList = new List<Enemy>();

    public Transform blastPref,shockPref;
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
        Application.targetFrameRate = 60;
        joystick = FindObjectOfType<Joystick>();
        player = FindObjectOfType<Player>();
        cam = FindObjectOfType<Camera>();

    }
    public List<Enemy> GetCLosestAIList()
    {
        return triggeredEnemyList.OrderBy(c => Vector3.Distance(player.transform.position, c.transform.position)).ToList();

    }

    private void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    public void StartGame()
    {

        player.StartCharacter();

    }

 
}

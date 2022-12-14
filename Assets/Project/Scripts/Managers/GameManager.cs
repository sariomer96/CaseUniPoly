using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int totalGold = 0;
    public float maxSpawnDelay = 7f;
    public int spawnCount;
    public float enemySpawnRadius = 1f;
    public TextMeshProUGUI goldTxt;
    public GameObject sphere;
    public static GameManager _instance;
    public Joystick joystick;
    public PlayerCamera cam;
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
        cam = FindObjectOfType<PlayerCamera>();

    }
    
        private void Start()
        {
            StartGame();
            
        }

    public List<Enemy> GetCLosestAIList()
    {
        return triggeredEnemyList.OrderBy(c => Vector3.Distance(player.transform.position, c.transform.position)).ToList();

    }

    IEnumerator RagdollTimer()
    {
        yield return new WaitForSeconds(60f);
        player.StopAllCoroutines();
        player.RegisterAnimation("Idle");
        Enemy[] enemies = FindObjectsOfType<Enemy>();
     TriggerEnemy triggerEnemy=   player.transform.GetComponentInChildren<TriggerEnemy>();
     triggerEnemy.gameObject.SetActive(false);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].StopAllCoroutines();
        }
        SpawnManager._instance. StopCoroutine("SpawnRoutine");
        StartCoroutine("HitToPlayer");
    }

    IEnumerator HitToPlayer()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray();
            }

            yield return null;
        }
     
    }

    void Ray()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit,100,LayerMask.GetMask("Player"))) {
            Transform objectHit = hit.transform;
            print(objectHit);
            player.EnableRagdoll();
            cam.StopAllCoroutines();
            objectHit.GetComponent<Rigidbody>().AddForce(ray.direction*5000f,ForceMode.Force);
            // Do something with the object that was hit by the raycast.
        }
    }
  
    // Update is called once per frame
    public void StartGame()
    {
 
        player.StartCharacter();
        SpawnManager._instance. StartCoroutine("SpawnRoutine");
        StartCoroutine("RagdollTimer");

    }

 
}

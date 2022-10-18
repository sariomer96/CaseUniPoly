using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField] private Enemy enemyPref;
   public static SpawnManager _instance;

   private void Awake()
   {
       _instance = this;
   }

 
    
    IEnumerator SpawnRoutine()
    {
   
        while (true)
        {
       
          

            Vector3 center = GameManager._instance.player.transform.position;
          

            RandomCircle(center, GameManager._instance.enemySpawnRadius);
            // GameManager.Instance.MoveEnemy();
            float randomDuration = Random.Range(3f,GameManager._instance.maxSpawnDelay);

            
            yield return new WaitForSeconds(randomDuration);
          
        }
       
        //  Instantiate(ai, new Vector3(pos.x,0,pos.y), Quaternion.identity);
            
    }
  

    void RandomCircle ( Vector3 center,float radius)
    {
       
       
            int count= GameManager._instance.spawnCount;
            for (int j = 0; j < count; j++)
            { 
                Vector2 randomCircle = Random.insideUnitCircle.normalized;
                Vector3 pos = new Vector3(randomCircle.x * radius, 0, randomCircle.y * radius) + GameManager._instance.player.transform.position;
                Enemy enemy = Instantiate(enemyPref, pos, Quaternion.identity,null);
               
            }
           

        

      
      
 
    }
}

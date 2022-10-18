using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemy : MonoBehaviour
{
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider other)
    {
        
        Enemy enemyAi = other.GetComponent<Enemy>();
        if (enemyAi)
        {
            transform.GetComponentInParent<Player>().AddEnemy(enemyAi);      
           
        }

      
    }

    private void OnTriggerExit(Collider other)
    {
        Enemy enemyAi = other.GetComponent<Enemy>();
        if (enemyAi)
        {
            
            transform.GetComponentInParent<Player>().RemoveEnemy(enemyAi);          
        }
        
    }
}

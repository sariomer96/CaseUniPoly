using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : Character
{
    // Start is called before the first frame update
 
    void OnEnable()
    {
       
        StartCoroutine("MoveRoutine");
    }

    private void OnDestroy()
    {
 
        GameManager._instance.triggeredEnemyList.Remove(this);
    }

    public void CheckHealth()
    {
        if (health<=0)
        {
            Destroy(gameObject);
        }
    }

   public void TakeDamage(float damage)
    {
        health -= damage;
    }
    // Update is called once per frame
    public override Vector3 SetInput()
    {

        return new Vector3(GameManager._instance.player.transform.position.x - transform.position.x, 0,
            GameManager._instance.player.transform.position.z - transform.position.z).normalized;
    }
    public override IEnumerator MoveRoutine()
    {


        while (true)
        {
            Vector3 direction = SetInput();
            
            float speed = GameManager._instance.AiSpeed*Time.fixedDeltaTime;
         
            
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direction * speed);
           
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), GameManager._instance.lookSpeed);
            yield return new WaitForFixedUpdate();
        }
           
          
        

      
    }
}

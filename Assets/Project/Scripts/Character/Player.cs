using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

     string state = "MoveRoutine";
    [SerializeField] public bool isAttack = false;
     [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Awake()
    {
        _animator = transform.GetComponent<Animator>();
    }
    public void AddEnemy(Enemy enemy)
    {
        GameManager._instance.triggeredEnemyList.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        GameManager._instance.triggeredEnemyList.Remove(enemy);
    }
    public void DisableRagdoll()
    {
       Rigidbody[] rb= transform.GetComponentsInChildren<Rigidbody>();

       for (int i = 1; i < rb.Length; i++)
       {
           rb[i].isKinematic = true;
       }
    }
    public void EnableRagdoll()
    {
        Rigidbody[] rb= transform.GetComponentsInChildren<Rigidbody>();
        transform.GetComponent<Collider>().enabled = false;
        transform.GetComponent<Animator>().enabled = false;
        for (int i = 1; i < rb.Length; i++)
        {
            rb[i].isKinematic = false;
        }
    }
    public void StopAnim()
    {
        isAttack = false;
    }
    public void StartCharacter()
    {
        DisableRagdoll();
        StartCoroutine("DecisionRoutine");
        StartCoroutine(state);
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="gold")
        {
            Destroy(other.gameObject);
            GameManager._instance.totalGold++;
            GameManager._instance.goldTxt.text = GameManager._instance.totalGold.ToString();
        }
    }

    public override IEnumerator MoveRoutine()
    {
        
        if (state=="MoveRoutine")
        {
           
            RegisterAnimation("Run");
           
            Vector3 direction = SetInput();
          
        
                
            float speed = GameManager._instance.playerSpeed;
          
        

            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direction * speed);
           
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), GameManager._instance.lookSpeed);
            yield return new WaitForFixedUpdate();
        }
        StartCoroutine(state);
       
    }
    public void ChangeState(string value)
    {
        if (state == value)
            return;
        state = value;
    }
    // Update is called once per frame
    public override Vector3 SetInput()
    {
        Vector3 direction = new Vector3(GameManager._instance.joystick.Direction.x, 0, GameManager._instance.joystick.Direction.y).normalized;
        if (Application.isEditor)
            direction += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        return direction;
    }
    string currentAnimation;
    public void RegisterAnimation(string value)
    {
        if (value == currentAnimation)
            return;
        currentAnimation = value;
        _animator.CrossFade(currentAnimation, 0.2f);
    }
    
    public  IEnumerator DecisionRoutine()
    {
        while (true)
        {
            Vector3 direction = SetInput();

             
             
            if (health<=0)
            {
                print("die");
                ChangeState("DeadRoutine");
            }
            else if (isAttack)
            {
                ChangeState("AttackRoutine");
            }
        
            else if(direction==Vector3.zero)
            {
            
                ChangeState("Idle");
               
            }
            else
            {
        
                ChangeState("MoveRoutine");
            } 
          
          
            yield return null;
        }
    }

    public IEnumerator AttackRoutine()
    {
        if(state=="AttackRoutine")
        {
            RegisterAnimation("Shock");
            
            yield return null;
        }

        StartCoroutine(state);
    }
 
    public  IEnumerator DeadRoutine()
    {
        if (state=="DeadRoutine")
        {
            RegisterAnimation("Defeat");
             
            StopAllCoroutines();
            yield break;
        }
         
    }
    
    public  IEnumerator Idle()
    {
        if(state=="Idle")
        {
            
            RegisterAnimation("Idle");
            
            yield return new WaitForSeconds(0.1f);
        }

      
        StartCoroutine(state);
    }

}

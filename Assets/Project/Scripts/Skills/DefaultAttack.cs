using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DefaultAttack : Skill
{
    // Start is called before the first frame update
    void Start()
    {
        StartSkill();
    }

 

    public override void StartSkill()
    {
        StartCoroutine("SpawnBullet");
    }

    IEnumerator SpawnBullet()
    {
        while (true)
        {
             
           GameObject sphere= Instantiate(GameManager._instance.sphere, GameManager._instance.player.transform.position+new Vector3(0,1f,0)+GameManager._instance.player.transform.forward*0.5f, Quaternion.identity);
           sphere.transform.localRotation = GameManager._instance.player.transform.rotation;
           Weapon skillObject=  sphere.GetComponent<Weapon>();
           skillObject.damage = damage;
           Destroy(sphere,4);
            yield return new WaitForSeconds(cooldown);
        }
    }
}

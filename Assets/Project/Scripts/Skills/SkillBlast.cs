using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SkillBlast : Skill
{
     
    public override void StartSkill()
    {

       List<Enemy> enemy= GameManager._instance.GetCLosestAIList();
         print("blast");
       if (enemy.Count>0)
       {
           Vector3 targetPos = enemy[0].transform.position;
          
           Transform blast=  Instantiate(GameManager._instance.blastPref, GameManager._instance.player.transform.position, Quaternion.identity);
          Weapon weapon=  blast.GetComponent<Weapon>();
          weapon.damage = damage;
           blast.DOMove(targetPos, 2f).SetSpeedBased(true);

         
           Destroy(weapon.gameObject,3f);
       }
      

    }
}

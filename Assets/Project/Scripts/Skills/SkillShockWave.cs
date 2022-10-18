using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class SkillShockWave : Skill
{
    // Start is called before the first frame update

     
    public override void StartSkill()
    {
        
        GameManager._instance.player.isAttack = true;
        
       Transform shock= Instantiate(GameManager._instance.shockPref, GameManager._instance.player.transform.position, Quaternion.identity);
       print(shock.GetInstanceID()+""+shock.transform.position);
       ShockWeapon skillObject=  shock.GetComponentInChildren<ShockWeapon>();
       skillObject.damage = damage;
       skillObject.transform.localScale=Vector3.zero;
       skillObject.transform.DOScale(7f, 1.3f).SetDelay(0.15f).SetEase(Ease.InOutBounce);
       Destroy(skillObject.gameObject,1.3f);
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWeapon : Weapon
{
  
    // Update is called once per frame
    public override void OnTriggerEnter(Collider other)
    {
        Enemy enemy=  other.GetComponentInChildren<Enemy>();

        if (enemy)
        {
            print("HİİTT");
            enemy.TakeDamage(damage);
            enemy.CheckHealth();
           
        }
    }

   
}

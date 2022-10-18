using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update

    public  virtual void OnTriggerEnter(Collider other)
    {
        Enemy enemy=  other.GetComponentInChildren<Enemy>();

        if (enemy)
        {
            enemy.TakeDamage(damage);
            enemy.CheckHealth();
            Destroy(enemy.gameObject);
        }
    }
}

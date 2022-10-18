using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Move");
    }

    // Update is called once per frame

    IEnumerator Move()
    {
        while (true)
        {
            transform.position=Vector3.Lerp(transform.position,transform.position+transform.forward,0.2f);
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy)
        {
            Destroy(gameObject,0.2f);
        }
      
    }
}

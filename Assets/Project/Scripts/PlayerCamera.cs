using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

     
    Vector3 offset;
    public float followStrength = 0.1f;
    private void Start()
    {

     
        offset = transform.position - GameManager._instance.player.transform.position;
        StartCoroutine("MoveRoutine");
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, GameManager._instance.player.transform.position + offset, followStrength);
            yield return new WaitForFixedUpdate();
        }

    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void FixedUpdate(){
        Vector2 pos = transform.position;
        pos.x -= 10 * Time.deltaTime;

        //transform.position = pos;
        //Debug.Log(transform.position.x + " " + (-100).ToString());
        if (transform.position.x < -100){
            //PoolObject.Instance.Spawn();
        }
    }
}

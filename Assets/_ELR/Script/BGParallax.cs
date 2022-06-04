using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BGParallax : MonoBehaviour{
    public float depth = 1;
    private PlayerController _player;
    public float xEnd;
    public float xStart;
    public Vector2 Velocity;
    private void Awake(){
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void FixedUpdate(){
        float realVelocity = Velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realVelocity * Time.fixedDeltaTime;

        if (pos.x <= -xEnd){
            pos.x = xStart;
        }
        transform.position = pos;
    }
}

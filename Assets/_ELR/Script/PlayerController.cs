using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerController : MonoBehaviour
{
    //public Animator PlayerAnimator
    // public delegate void DoAnim(string name);
    //
    // public event DoAnim PlayAnimation;

    public Animator PlayerAnimator;

    public int JumpForce;
    public bool IsGrounded;
    public Vector2 Velocity;
    public float maxXVelocity = 100;
    public float acceleration = 10;
    public float maxAcceleration = 10;
    public Rigidbody2D Rigid2d;

    private bool _canDoubleJump;
    public bool isOver;
    private void Awake(){
        Rigid2d = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Start(){
        isOver = false;
    }
    private void Update() {
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Space)){
            if (IsGrounded){
                Jump();
                _canDoubleJump = true;
                IsGrounded = false;
                return;
            }
            if (_canDoubleJump){
                Jump(true);
                _canDoubleJump = false;
            }
        }
        float moveStep = Input.GetAxis("Horizontal");
        if (moveStep != 0)
        {
            transform.Translate(moveStep * 10f * Time.deltaTime, 0, 0);

        }
    }

    private void FixedUpdate(){
        UpdatePlayerPos();
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (!isOver && collision.gameObject.CompareTag("Ground")){
            if (!IsGrounded){
                IsGrounded = true;
                PlayerAnimator.Play("run");
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isOver = true;
            PlayerAnimator.Play(stateName: "hit");
            //gameObject.SetActive(false);
        }
    }

    private void Jump(bool doubleJump = false){
        
        if (doubleJump){
            Rigid2d.AddForce(Vector2.up * (JumpForce/2));
            PlayerAnimator.Play("double_jump");
            _canDoubleJump = false;
            return;
        }
        Rigid2d.AddForce(Vector2.up * JumpForce);

        PlayerAnimator.Play("jump");
    }

    private void UpdatePlayerPos(){
        Vector2 pos = transform.position;
        if (IsGrounded){
            float velocityRatio = Velocity.x / maxXVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            Velocity.x += acceleration * Time.fixedDeltaTime;
            if (Velocity.x >= maxXVelocity)
            {
                Velocity.x = maxXVelocity;
            }
        }

        transform.position = pos;
    }
}

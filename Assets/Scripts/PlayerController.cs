using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{

    // Player handling
    public int playerHP = 5;
    public float speed = 8f;
    public float acceleration = 30f;
    public float gravity = 20f;
    public float jumpHeight = 12f;
    public float invincibilityDuration = 1.5f;

    public LayerMask enemyLayer;
    private int enemylayer;

    private float playerInvincibleTimer;
    private bool playerInvincible;

    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

    private Enemy enemyScript;
    private bool gotScript = false;

    private Collider2D playerCollider;
    private Vector2 enemyPos;
    private Vector2 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
        enemylayer = (int)Mathf.Log(enemyLayer.value, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHP <= 0) {
            SceneManager.LoadScene("DeathMenu");
        }

        if (playerPhysics.movementStopped) {
            targetSpeed = 0;
            currentSpeed = 0;
        }

        // Input

        // TO ADD DISABLED MOVEMENTS, MODIFY HERE
        targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        if (playerPhysics.grounded) {
            amountToMove.y = 0;

            // Jump, default is "Space", change to getKeyPressed() to check for W
            if(Input.GetKeyDown("w")) {
                amountToMove.y = jumpHeight;
            }
        }

        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime);
    }

    // Increase currentspeed towards target by speed
    private float IncrementTowards(float currentSpeed, float target, float acceleration) {
        if (currentSpeed == target) {
            return currentSpeed;
        }
        else {
            float dir = Mathf.Sign(target - currentSpeed); // must currentSpeed be increased or decreased to get closer to target speed
            currentSpeed += acceleration * Time.deltaTime * dir;

            // if dir is the same, return current speed, otherwise (if gone too far), increment target
            return (dir == Mathf.Sign(target-currentSpeed))? currentSpeed: target; // if currentSpeed has now passed target speed, return target, otherwise return currentSpeed
        }
    }

    void OnTriggerEnter2D(Collider2D col){
      Debug.Log("hit");
      playerHP -= 1;

      playerCollider = GetComponent<BoxCollider2D>();
      
      enemyPos = col.bounds.center;
      playerPos = playerCollider.bounds.center;

      playerPhysics.movementStopped = false;
      currentSpeed = (playerPos.x - enemyPos.x) * 10;
      amountToMove.y = Mathf.Abs(playerPos.y - enemyPos.y) * 10;

      playerPhysics.Move(new Vector2(0, 0.5f));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      //Debug.Log("hit");
      //if col is on layer enemy:
      print("I'm here!");
      GameObject obj = col.gameObject;
      if (obj.layer == enemyLayer)
      {
          if (!gotScript)
          {
              enemyScript = obj.GetComponent<Enemy>(); //Assumes the existence of an "Enemy.cs" script
              gotScript = true;
          }

          if (Time.time > playerInvincibleTimer)
          { //if the player invincibility duration ran out
              playerInvincible = false;
          }
          
          //take damage, make invincible
          if (!playerInvincible)
          {
              
              playerHP -= enemyScript.damage;
              playerInvincibleTimer = Time.time + invincibilityDuration;
              playerInvincible = true;
          }
      }
    }
}
//scriptName = gameObject.GetComponent<ScriptName>();

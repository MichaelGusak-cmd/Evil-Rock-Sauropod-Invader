using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemyX;
    private Vector2 move;
    public float movementRange;
    private bool flipped;
    public float speed = 0.1F;
    // Start is called before the first frame update
    void Start()
    {
        enemyX = transform.position.x;
        move = new Vector2(0, 0);
        // movementRange = enemyX + 2;
    }

    // Update is called once per frame
    void Update()
    {
        move.x += speed * Time.deltaTime;
        enemyX = transform.position.x;
        Debug.Log(transform.position.x);
        
        if (!flipped && (enemyX > movementRange || enemyX < -movementRange))
        {
            speed = -speed;
            flipped = true;
        }

        if (enemyX > -movementRange && enemyX < movementRange)
        {
            flipped = false;
        }
        
       
        transform.Translate(move);
        speed *= 0.95F;
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
}

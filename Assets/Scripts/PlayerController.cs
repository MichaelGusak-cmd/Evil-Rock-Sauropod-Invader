using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerPhysics))]
public class PlayerController : MonoBehaviour
{

    // Player handling
    public float speed = 8;
    public float acceleration = 30;
    public float gravity = 20;
    public float jumpHeight = 12;

    private float currentSpeed;
    private float targetSpeed;
    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    // Update is called once per frame
    void Update()
    {
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
}

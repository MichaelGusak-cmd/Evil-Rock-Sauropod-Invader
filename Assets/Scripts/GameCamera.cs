using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public float trackSpeed = 10;
    public Transform target;

    public void SetTarget(Transform t) {
        target = t;
    }

    // LateUpdate happens after regular updates happen
    void LateUpdate() {
        if (target) {

            float x = IncrementTowards(transform.position.x, target.position.x, trackSpeed);
            float y = IncrementTowards(transform.position.y, target.position.y, trackSpeed);
            transform.position = new Vector3(x,y, transform.position.z);

        }
    }

    // increase currentSpeed towards target by speed
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO (Sorry me in the future)
// 1. Change 3d collision to 2D collision, check comments under video for solution to issue with raycasting
// 2. Add x collision, using above 2d changes to modify video 2 script
// 3. Add more keybinds to player controls with more scripts

[RequireComponent (typeof(BoxCollider2D))]
public class PlayerPhysics : MonoBehaviour
{

    public LayerMask collisionMask;

    private BoxCollider2D collider;
    private Vector2 size;
    private Vector2 centre;

    private float skin = .005f; // distance between player raycast and ground

    [HideInInspector]
    public bool grounded;
    [HideInInspector]
    public bool movementStopped;


    Ray2D ray;
    RaycastHit2D hit;

    void Start() {
        collider = GetComponent<BoxCollider2D>();
        size = collider.bounds.size;
        centre = collider.bounds.center;
    }

    public void Move(Vector2 moveAmount) {

        float deltaY = moveAmount.y;
        float deltaX = moveAmount.x;
        Vector2 pos = transform.position;

        // check collisions above and below
        grounded = false;
        for (int i = 0; i < 3; i++) {
            float dir = Mathf.Sign(deltaY);
            float x = (pos.x - size.x/2.15f) + size.x/2.15f * i; // left, centre, and right of collider
            float y = pos.y + size.y/2 * dir; // bottom of collider

            ray = new Ray2D(new Vector2(x,y), new Vector2(0, dir));
            Debug.DrawRay(ray.origin, ray.direction);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs(deltaY) + skin, collisionMask);

            if (hit.collider != null) {
                // get distance between player and ground
                float distance = Vector2.Distance(ray.origin, hit.point);

                // Stop player's downwards movement after coming within skin of a collider
                if (distance > skin) {
                    deltaY = distance * dir - skin * dir;
                }
                else {
                    deltaY = 0;
                }
                grounded = true;
                break;
            }
        }

        // check collisions left and right
        movementStopped = false;
        for (int i = 0; i < 3; i++) {
            float dir = Mathf.Sign(deltaX);
            float x = pos.x + size.x/2 * dir;
            float y = pos.y - size.y/2.05f + size.y/2.05f * i ; 

            ray = new Ray2D(new Vector2(x,y), new Vector2(dir, 0));
            Debug.DrawRay(ray.origin, ray.direction);
            hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs(deltaY) + skin, collisionMask);

            if (hit.collider != null) {
                // get distance between player and ground
                float distance = Vector2.Distance(ray.origin, hit.point);

                // Stop player's downwards movement after coming within skin of a collider
                if (distance > skin) {
                    deltaX = distance * dir - skin * dir;
                }
                else {
                    deltaX = 0;
                }

                movementStopped = true;
                break;
            }
        }

        Vector2 finalTransform = new Vector2(deltaX, deltaY);

        transform.Translate(finalTransform);
    }
}

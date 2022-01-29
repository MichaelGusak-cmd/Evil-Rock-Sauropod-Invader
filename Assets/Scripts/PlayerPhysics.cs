using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO (Sorry me in the future)
// 1. Change 3d collision to 2D collision, check comments under video for solution to issue with raycasting
// 2. Add x collision, using above 2d changes to modify video 2 script
// 3. Add more keybinds to player controls with more scripts

[RequireComponent (typeof(BoxCollider))]
public class PlayerPhysics : MonoBehaviour
{

    public LayerMask collisionMask;

    private BoxCollider collider;
    private Vector3 size;
    private Vector3 centre;

    private float skin = .005f; // distance between player raycast and ground

    [HideInInspector]
    public bool grounded;

    Ray ray;
    RaycastHit hit;

    void Start() {
        collider = GetComponent<BoxCollider>();
        size = collider.size;
        centre = collider.center;
    }

    public void Move(Vector2 moveAmount) {

        float deltaY = moveAmount.y;
        float deltaX = moveAmount.x;
        Vector2 pos = transform.position;

        grounded = false;
        for (int i = 0; i < 3; i++) {
            float dir = Mathf.Sign(deltaY);
            float x = (pos.x + centre.x - size.x/2) + size.x/2 * i; // left, centre, and right of collider
            float y = pos.y + centre.y + size.y/2 * dir; // bottom of collider

            ray = new Ray(new Vector2(x,y), new Vector2(0, dir));

            if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY) + skin, collisionMask)) {
                // get distance between player and ground
                float distance = Vector3.Distance(ray.origin, hit.point);

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

        Vector2 finalTransform = new Vector2(deltaX, deltaY);

        transform.Translate(finalTransform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponAttack : MonoBehaviour
{
    public GameObject weapon;

    private float dir = 1;
    private float dirUpdate = 0;

    private BoxCollider2D collider;
    private Vector2 size;
    private Vector2 centre;
    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        size = collider.bounds.size;
        centre = collider.bounds.center;

        pos = transform.position;
        pos = new Vector2(pos.x + size.x/2 * dir, pos.y - size.y/6);
        weapon = Instantiate(weapon, pos, Quaternion.identity);
        weapon.transform.Rotate(new Vector3(0,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        dirUpdate = Input.GetAxisRaw("Horizontal");
        
        if (dirUpdate != 0) {
            dir = dirUpdate;
        }
        
        pos = transform.position;
        pos = new Vector2(pos.x + size.x/2 * dir, pos.y - size.y/10);
        weapon.transform.position = pos;
        weapon.transform.Rotate(new Vector3(0,0,5));

        
    }
}


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

    private int adjustX = 4;
    private int adjustY = 3;
    private bool attacking = false;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        size = collider.bounds.size;
        centre = collider.bounds.center;

        pos = transform.position;
        pos = new Vector2(pos.x + size.x/2 * dir, pos.y - size.y/6);
        weapon = Instantiate(weapon, pos, Quaternion.identity);
        weapon.transform.Rotate(new Vector3(0,0,90));
    }

    // Update is called once per frame
    void Update()
    {
        dirUpdate = Input.GetAxisRaw("Horizontal");
        
        if (dirUpdate != 0) {
            dir = dirUpdate;
        }
        
        pos = transform.position;
        pos = new Vector2(pos.x + size.x/adjustX * dir, pos.y + size.y/adjustY);
        weapon.transform.position = pos;
        //weapon.transform.Rotate(new Vector3(0,0,5));
        if(Input.GetKeyDown("space") && !attacking)
        StartCoroutine(SwingWeapon());

        
    }

    IEnumerator SwingWeapon() 
    {
        attacking = true;
        weapon.transform.Rotate(new Vector3(0,0,-90 * dir));
        adjustX = 1;
        adjustY = -10;
        yield return new WaitForSeconds( 0.3f );
        adjustX = 4;
        adjustY = 3;
        weapon.transform.Rotate(new Vector3(0,0,90 * dir));
        yield return new WaitForSeconds( 0.2f );
        attacking = false;

    }
}


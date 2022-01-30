using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{

    public GameObject enemy;

    public float range = 3F;
    public float health = 1;
    public float objectSpeed = 0.00005F;

    private float enemyX, baseX;
    public float speed = 0.00005F;

    private Vector2 move = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start(){
        enemyX = transform.position.x; //get current position
        baseX = enemyX; // save origin position
        speed = objectSpeed; // speed constant
    }

    // Update is called once per frame
    void Update(){
      if (enemyX > baseX+range){
          move.x = 0;
          speed = -objectSpeed;
      }
      
      if (enemyX < baseX-range) {
          move.x = 0; 
          speed = objectSpeed; 
      }

      move.x += speed;
      enemyX = transform.position.x;
      
      transform.Translate(move); // this is what moves the object
    }

    void OnTriggerEnter2D(Collider2D col){
      if(col.CompareTag("PlayerWeapon")) {
        Destroy(enemy.gameObject);
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour{

    public float range = 3F;
    public float health = 10;

    private float enemyX, baseX;
    private float speed;

    private Vector2 move = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start(){
        enemyX = transform.position.x; //get current position
        baseX = enemyX; // save origin position
        speed = 0.0001F; // speed constant
    }

    // Update is called once per frame
    void Update(){
      if (enemyX > baseX+range){
          move.x = 0;
          speed = -0.0001F;
      }
      
      if (enemyX < baseX-range) {
          move.x = 0; 
          speed = 0.0001F; 
      }

      move.x += speed;
      enemyX = transform.position.x;
      
      transform.Translate(move); // this is what moves the object
    }
}

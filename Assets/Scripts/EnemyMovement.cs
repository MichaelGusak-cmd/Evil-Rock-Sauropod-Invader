using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float enemyX;
    private float speed;
    private Vector2 move = new Vector2(0, 0);
    private float movementRange;

    public float health;
    // Start is called before the first frame update
    void Start()
    {
        enemyX = transform.position.x;
        movementRange = enemyX + 2F;
        speed = 0.0001F;
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
      if (enemyX > movementRange)
      {
          move.x = 0;
          speed = -0.0001F;
      }
      
      if (enemyX < -movementRange) 
      {
          move.x = 0; 
          speed = 0.0001F; 
      }

      move.x += speed;
      enemyX = transform.position.x;
      
      transform.Translate(move); // this is what moves the object
    }
    
}

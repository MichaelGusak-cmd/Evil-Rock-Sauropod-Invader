using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject key;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
      Debug.Log("hey");
      if(col.CompareTag("Player")) {
        Destroy(key.gameObject);
      }
    }
}

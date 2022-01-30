using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string NextScene = "DeathMenu";

    private GameObject sceneManager; 
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindWithTag("SceneManager");
    }

    void OnTriggerEnter2D (Collider2D other) {
        print("Trigger");
        if (other.CompareTag("Player")) {
            sceneManager.GetComponent<SceneChanger>().ChangeScene(NextScene);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    private GameCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        cam = GetComponent<GameCamera>();
    }

    private void SpawnPlayer() {
        print(player);
        cam.SetTarget((Instantiate(player, Vector3.zero, Quaternion.identity) as GameObject).transform);
    }
}

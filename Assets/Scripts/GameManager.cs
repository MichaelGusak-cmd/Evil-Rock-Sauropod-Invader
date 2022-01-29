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
        cam = GetComponent<GameCamera>();
        SpawnPlayer();
    }

    private void SpawnPlayer() {
        player = Instantiate(player, Vector2.zero, Quaternion.identity) as GameObject;
        cam.SetTarget(player.transform);

    }
}

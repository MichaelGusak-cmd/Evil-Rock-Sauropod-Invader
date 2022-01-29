using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float platformDelay = 0.5f;
    public float dropDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.layer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w")) {
            StartCoroutine(JumpThrough());
        }
        if (Input.GetKeyDown("s")) {
            StartCoroutine(FallThrough());
        }
    }

    IEnumerator JumpThrough() 
    {
        gameObject.layer = 0;

        yield return new WaitForSeconds( platformDelay );

        gameObject.layer = 6;
    }

    IEnumerator FallThrough() 
    {
        gameObject.layer = 0;

        yield return new WaitForSeconds( platformDelay );

        gameObject.layer = 6;
    }
}

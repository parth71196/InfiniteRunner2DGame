using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformscript : MonoBehaviour
{
    private bool right;
    private static float speed = 1f; 
    private static float margin = 1.9f;
   
    void Awake()
    {
        randomizeMovement();
    }

    // Update is called once per frame
    void Update()
    {
        movePlatform();
    }

    public void randomizeMovement() {
        if (Random.Range(0,2) == 0) {
            right = true;
        }
        else{
            right = false;
        }
       
    }

    public void movePlatform() {

        if (right)
        {
            Vector3 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            if (transform.position.x > margin)
            {
                right = false;
            }
        }

        else {
            Vector3 pos = transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
            if (transform.position.x < -1 * margin)
            {
                right = true;
            }
        }

    }
}

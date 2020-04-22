using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private static float distance = 4.0f;
    private float newDistance;
    private bool move;
    // Start is called before the first frame update

    public void OnEnable()
    {
        PlayerScript.move += Move;
    }

    public void OnDisable()
    {
        PlayerScript.move -= Move;
    }
    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        if (move) {
            Vector3 position = transform.position;
            position.y += 4.0f * Time.deltaTime;

            transform.position = position;

            if (transform.position.y >= newDistance) {
                move = false;
            }
        }
    }
    public void Move()
    {
        Vector3 position = transform.position;
        newDistance = position.y + distance;
        move = true;
    }

}

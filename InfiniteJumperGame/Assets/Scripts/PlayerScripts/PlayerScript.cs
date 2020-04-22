using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    private Button jumpButton;
    private Rigidbody2D playerRigidBody;
    private static string JUMP_BUTTON = "JumpButton";
    private GameObject platform;
    private bool hasJumped,playerCollidedWithCamera;
    public delegate void MoveCamera();
    public static event MoveCamera move;
    void Awake()
    {
        jumpButton = GameObject.Find(JUMP_BUTTON).GetComponent<Button>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        jumpButton.onClick.AddListener(()=>Jump());
    }

    public void Update()
    {
        if (playerCollidedWithCamera == false) {
            if (hasJumped && playerRigidBody.velocity.y == 0)
            {
                hasJumped = false;
                transform.SetParent(platform.transform);
                if (move != null) {
                    move();
                }
            }
            else if (platform != null)
            {

                transform.SetParent(platform.transform);
            }
        }
        
    }
    public void Jump() {
        if (playerRigidBody.velocity.y == 0) {
            playerRigidBody.velocity = new Vector2(0, 10);

            
        }
    }

    public void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Platform") {
            Debug.Log("Collision Detected");
            platform = target.gameObject;
            hasJumped = true;
        }

        else {
            platform = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "MainCamera")
        {
            Debug.Log("Main Camera collided");
            playerCollidedWithCamera = true;

        }
    }

    public void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "MainCamera") {
            Debug.Log("Moved Away From Camera");
            playerCollidedWithCamera = false;
        }        
    }

}

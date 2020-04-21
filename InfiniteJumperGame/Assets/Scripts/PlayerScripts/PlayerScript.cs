using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    private Button jumpButton;
    private Rigidbody2D playerRigidBody;
    private static string JUMP_BUTTON = "JumpButton";
    
    void Awake()
    {
        jumpButton = GameObject.Find(JUMP_BUTTON).GetComponent<Button>();
        playerRigidBody = GetComponent<Rigidbody2D>();
        jumpButton.onClick.AddListener(()=>Jump());
    }

    public void Jump() {
        if (playerRigidBody.velocity.y == 0) {
            playerRigidBody.velocity = new Vector2(0, 10);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 100f;
    public bool leftSideControls = true;
    private Rigidbody2D rb;
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if ((touch.position.x < Screen.width / 2) && leftSideControls && !jump  )//Left side
            {
                Debug.Log("Jumps");
                jump = true;
            }
            else if ((touch.position.x > Screen.width / 2) && !leftSideControls && !jump)//Right side
            {
                Debug.Log("Jumpd");
                jump = true;
            }
        }

        if (Input.GetKey(KeyCode.W) && !jump)
        {
            jump = true;
        }

        if (jump)
        {
            Jump();
        }
    }

    void Jump()
    {
        Debug.Log("Jump");
        rb.AddForce(Vector2.up * jumpForce * Time.deltaTime,ForceMode2D.Impulse);
        jump = false;
    }
}

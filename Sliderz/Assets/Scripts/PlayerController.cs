using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 100f;
    public bool leftSideControls = true;
    public LayerMask groundMask;
    private Rigidbody2D rb;
    private SpriteRenderer sprRender;
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprRender = GetComponent<SpriteRenderer>();
        Debug.Log(sprRender.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if ((touch.position.x < Screen.width / 2) && leftSideControls && !jump && GroundCheck())//Left side
            {
                Debug.Log("Jumps");
                jump = true;
            }
            else if ((touch.position.x > Screen.width / 2) && !leftSideControls && !jump && GroundCheck())//Right side
            {
                Debug.Log("Jumpd");
                jump = true;
            }
        }

        if (Input.GetKey(KeyCode.W) && !jump && GroundCheck())
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

    bool GroundCheck()
    {
        Debug.Log("Start");
        Vector2 sprSize = sprRender.size;

        Collider2D hit = Physics2D.OverlapArea(new Vector2(transform.position.x - sprSize.x/2, transform.position.y), new Vector2(transform.position.x + sprSize.x/2, transform.position.y + sprSize.y + .1f),groundMask);

        if (hit != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

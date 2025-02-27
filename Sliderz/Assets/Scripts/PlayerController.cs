using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject m_camera;
    public float constForce = 10f;
    public float jumpForce = 10f;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool normalGrv;
    public static bool leftSideControls = true;
    bool grvSwitched;
    bool jump;

    Vector2 firstPt;
    Vector2 secPt;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        normalGrv = true;
        Vector2 firstPt = new Vector2(transform.position.x - .5f, transform.position.y - .5f);
        Vector2 secPt = new Vector2(transform.position.x + .5f, transform.position.y - .51f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            rb.velocity = (Vector2.right * constForce);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;
            if (leftSideControls)
            {
                if (touchPos.x < m_camera.transform.position.x)
                {
                    jump = true;
                }
            }
            else
            {
                if (touchPos.x > m_camera.transform.position.x)
                {
                    jump = true;
                }
            }
        }

        if ((Input.GetKey(KeyCode.W) || jump) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log(leftSideControls);
            jump = false;
        }

        //DO GRAVITY SWITCH LATER
        // if (Input.GetKeyDown(KeyCode.Space)){
        // normalGrv = !normalGrv;
        // if (normalGrv){
        // firstPt = new Vector2(transform.position.x - .5f,transform.position.y - .51f);
        // secPt = new Vector2(transform.position.x + .5f,transform.position.y + .5f);
        // rb.gravityScale *= -1;
        // grvSwitched = !grvSwitched;
        // }else{
        // firstPt = new Vector2(transform.position.x - .5f,transform.position.y + .51f);
        // secPt = new Vector2(transform.position.x + .5f,transform.position.y + .5f);
        // rb.gravityScale *= -1;
        // grvSwitched = !grvSwitched;
        // }
        // }

        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - .5f, transform.position.y - .51f), new Vector2(transform.position.x + .5f, transform.position.y + .5f), groundMask);

        Vector3 orgin = new Vector3(transform.position.x, transform.position.y - .2f, transform.position.z);
        Debug.DrawRay(orgin, Vector2.right);
        RaycastHit2D hit = Physics2D.Raycast(orgin, Vector2.right, 1f, groundMask);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                menuUI.GetComponent<GameController>().GameOver();
            }
        }

        //if the player goes through the ground they will die
        LvlGenerator botYScript = GameObject.Find("Main Camera").GetComponent<LvlGenerator>();
        int botY = botYScript.bottomY;
        if (transform.position.y <= (botY - 2f))
        {
            menuUI.GetComponent<GameController>().GameOver();
        }
    }
}
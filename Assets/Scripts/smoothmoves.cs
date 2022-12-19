using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothmoves : MonoBehaviour
{
    [Header("movement")]
    [SerializeField] private int speed;
    private Rigidbody2D playerRigidbody;

    private SwingNail state;

    [Header("ground checks")]
    [SerializeField] private Transform point;
    private bool onground;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask groundstuff;

    [Header("Jumping")]
    [SerializeField] private float jumpTime;
    [SerializeField] private int jumpheigt;
    private float jumpTimeCount;
    private bool jumping;

    [Header("dash")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    public float StartDash;
    private int direction;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        state = GetComponent<SwingNail>();
        dashTime = StartDash;
    }

    
    void FixedUpdate()
    {
        Movement();
        
    }

    private void Update()
    {
        onground = Physics2D.OverlapCircle(point.position, radius, groundstuff);
        Jump();
        Dash();
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed, 0) * Time.deltaTime;
            if (state.attacking == false)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
            if (state.attacking == false)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

    }
    void Jump()
    {
        if (onground == true && Input.GetKeyDown(KeyCode.Z))
        {
            jumping = true;
            jumpTimeCount = jumpTime;
            playerRigidbody.velocity = Vector2.up * jumpheigt;
        }

        if (Input.GetKey(KeyCode.Z) && jumping == true)
        {
            if (jumpTimeCount > 0)
            {
                playerRigidbody.velocity = Vector2.up * jumpheigt;
                jumpTimeCount -= Time.deltaTime;

            }
            else
            {
                jumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            jumping = false;
        }
    }

    void Dash()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 2;
        }

        if (dashTime <= 0)
        {
            dashTime = StartDash;
            

            if (direction == 1 && Input.GetKeyDown(KeyCode.C))
            {
                playerRigidbody.velocity = Vector2.left * dashSpeed;
                playerRigidbody.gravityScale = 0;
            }
            else if (playerRigidbody.gravityScale == 0)
            {
                playerRigidbody.gravityScale = 3.5f;
            }

            if (direction == 2 && Input.GetKeyDown(KeyCode.C))
            {
                playerRigidbody.velocity = Vector2.right * dashSpeed;
                playerRigidbody.gravityScale = 0;
            }
            else if (playerRigidbody.gravityScale == 0)
            {
                playerRigidbody.gravityScale = 3.5f;
            }
        }
    }
}

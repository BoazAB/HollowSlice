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
    public bool onground;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask groundstuff;

    [Header("Jumping")]
    [SerializeField] private float jumpTime;
    [SerializeField] private int jumpheigt;
    [SerializeField] private int maxjump;
    private int jumpcount;
    private float jumpTimeCount;
    private float secjumpTimeCount;
    private bool jumping;
    private bool secjump;

    [Header("dash")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    private float dashTimecount;
    private int direction;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        state = GetComponent<SwingNail>();
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
            Debug.Log("Nstart " + secjump);
            if (jumpTimeCount > 0)
            {
                playerRigidbody.velocity = Vector2.up * jumpheigt;
                jumpTimeCount -= Time.deltaTime;
                Debug.Log("Nendjump " + secjump);
            }
            else
            {
                jumping = false;
            }
            Debug.Log("Nend " + secjump);
        }


        if (onground == true && Input.GetKeyDown(KeyCode.Z))
        {
            secjumpTimeCount = jumpTime;
            playerRigidbody.velocity = Vector2.up * jumpheigt;
            Debug.Log("Scheck " + secjump);
        }

        if (Input.GetKey(KeyCode.Z) && (onground == false && secjump == true))
        {
            Debug.Log("Sstart " + secjump);
            if (secjumpTimeCount > 0)
            {
                playerRigidbody.velocity = Vector2.up * jumpheigt;
                secjumpTimeCount -= Time.deltaTime;
                Debug.Log("Sendjump " + secjump);
            }
            else
            {
                secjump = false;
            }
            Debug.Log("Send " + secjump);
        }


        if (Input.GetKeyUp(KeyCode.Z))
        {
            jumping = false;
            secjump= true;
            Debug.Log("reset " + secjump);
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

        if (direction == 1 && Input.GetKeyDown(KeyCode.C))
        {
            dashTimecount = dashTime;
            if (dashTimecount >= 0)
            {
                playerRigidbody.velocity = Vector2.left * dashSpeed;
                dashTimecount -= Time.deltaTime;
            }
                
        }
        if (direction == 2 && Input.GetKeyDown(KeyCode.C))
        {
            if (dashTimecount >= 0)
            {
                playerRigidbody.velocity = Vector2.right * dashSpeed;
                dashTimecount -= Time.deltaTime;
            }
            
        }
    }
}

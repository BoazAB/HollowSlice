using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
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
    [SerializeField] private float dashtime;
    [SerializeField] private float startdashtime;
    private int direction;
    private int realdire;

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

            Debug.Log(direction);
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction = 1;
                realdire = 1;
                Debug.Log("left");
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direction = 2;
                realdire = 2;
                Debug.Log("right");
            }
        }
        else
        {
            if (dashtime <= 0)
            {
                direction = 0;
                dashtime = startdashtime;
                playerRigidbody.velocity = Vector2.zero;
                playerRigidbody.gravityScale = 3.5f;
            }
            else
            {
                dashtime -= Time.deltaTime;
                if (realdire == 1 && Input.GetKeyDown(KeyCode.C))
                {
                    dashtime = startdashtime;
                    playerRigidbody.velocity = Vector2.left * dashSpeed;
                    playerRigidbody.gravityScale = 0;
                }
                if (realdire == 2 && Input.GetKeyDown(KeyCode.C))
                {
                    dashtime = startdashtime;
                    playerRigidbody.velocity = Vector2.right * dashSpeed;
                    playerRigidbody.gravityScale = 0;
                }
            }
        }
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
            playerRigidbody.gravityScale = 3.5f;
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


        if (onground == true && Input.GetKeyDown(KeyCode.Z))
        {
            secjumpTimeCount = jumpTime;
            playerRigidbody.velocity = Vector2.up * jumpheigt;
            playerRigidbody.gravityScale = 3.5f;
        }

        if (Input.GetKey(KeyCode.Z) && (onground == false && secjump == true))
        {

            if (secjumpTimeCount > 0)
            {
                playerRigidbody.velocity = Vector2.up * jumpheigt;
                secjumpTimeCount -= Time.deltaTime;

            }
            else
            {
                secjump = false;
            }

        }


        if (Input.GetKeyUp(KeyCode.Z))
        {
            jumping = false;
            secjump= true;

        }
    }
    
    void Dash()
    {
        /*dashright = new Vector3(dashdish, 0, 0);
        dashleft = new Vector3(dashdish,0, 0);

         if (direction == 1 && Input.GetKeyDown(KeyCode.C) )
         {
             transform.position = Vector3.MoveTowards(transform.position, dashleft, dashSpeed * Time.deltaTime);
         }

         if (direction == 2 && Input.GetKeyDown(KeyCode.C))
         {
             transform.position += Vector3.MoveTowards(transform.position, -dashleft, dashSpeed * Time.deltaTime);
         }*/
    }
}

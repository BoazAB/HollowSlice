using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothmoves : MonoBehaviour
{
    [Header("movement")]
    [SerializeField] private int speed;
    [SerializeField] private int jumpheigt;
    private Rigidbody2D playerRigidbody;

    private SwingNail state;

    [Header("ground checks")]
    [SerializeField] private Transform point;
    public bool onground;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask groundstuff;

    [Header("Jumping")]
    [SerializeField] private float jumpTime;
    private float jumpTimeCount;
    private bool jumping;

    [Header("dash")]
    [SerializeField] private float dash;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        state = GetComponent<SwingNail>();
    }

    
    void Update()
    {
        Movement();
        Jump();
        onground = Physics2D.OverlapCircle(point.position , radius , groundstuff);
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
}
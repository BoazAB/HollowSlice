using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoothmoves : MonoBehaviour
{
    [Header("movement var")]
    [SerializeField] private int speed;
    [SerializeField] private int jumpheigt;

    private Rigidbody2D playerRigidbody;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0) * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}

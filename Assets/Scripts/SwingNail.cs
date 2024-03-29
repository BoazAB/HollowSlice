using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SwingNail : MonoBehaviour
{
    private bool facingRight;
    public GameObject hitLine;
    public GameObject hitUp;
    public GameObject hitDown;
    private Vector3 rightPlace;

    private smoothmoves move;
    public bool groundCheck;

    private bool up;
    private bool down;

    [SerializeField]
    public int hitKnockback;
    private Rigidbody2D playerRigidbody;

    private PlayerHealth inv;


    public bool attacking;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        move = GetComponent<smoothmoves>();
        inv = GetComponent<PlayerHealth>();
    }
    void Update()
    {
        groundCheck = move.onground;
        if (Input.GetKeyDown("x") && attacking == false)
        {
            attacking = true;
            swing();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            facingRight = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            facingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            up = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            up = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            down = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            down = false;
        }
    }
    private void swing()
    {
        if (groundCheck == false && down == true)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 1, this.gameObject.transform.rotation.z);
            var downHit = Instantiate(hitDown, rightPlace, Quaternion.identity);
            inv.invTimer = 0.5f;
            downHit.transform.parent = this.gameObject.transform;
            Destroy(downHit, 0.5f);
            StartCoroutine(WaitToHit());
        }
        else if (up == true)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.rotation.z);
            var newHit = Instantiate(hitUp, rightPlace, Quaternion.identity);
            inv.invTimer = 0.5f;
            newHit.transform.parent = this.gameObject.transform;
            Destroy(newHit, 0.5f);
            StartCoroutine(WaitToHit());
        }
        else if (facingRight)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x + 1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            var newHit = Instantiate(hitLine, rightPlace, Quaternion.identity.normalized);
            inv.invTimer = 0.5f;
            newHit.transform.parent = this.gameObject.transform;
            Destroy(newHit, 0.5f);
            StartCoroutine(WaitToHit());
        }
        else if (!facingRight)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x + -1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            var newHit = Instantiate(hitLine, rightPlace, Quaternion.Euler(0, 180, 0));
            inv.invTimer = 0.3f;
            newHit.transform.parent = this.gameObject.transform;
            Destroy(newHit, 0.3f);
            StartCoroutine(WaitToHit());
        }
    }
    IEnumerator WaitToHit()
    {
        yield return new WaitForSeconds(0.5f);
        attacking = false;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Enemy" && groundCheck == false && down == true)
        {
            Debug.Log("knockback");
            playerRigidbody.velocity = Vector2.up * hitKnockback;
        }
    }
}


//register if attack button is hit
//get the direction youre facing
//spawn hitbox in that direction

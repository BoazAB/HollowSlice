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
    private Vector3 rightPlace;

    [SerializeField]
    private bool Up;

    public bool attacking;
    private void Start()
    {
    }
    void Update()
    {
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
            Up = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Up = false;
        }
    }
    private void swing()
    {
        if (Up == true)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.rotation.z);
            var newHit = Instantiate(hitUp, rightPlace, Quaternion.identity);
            newHit.transform.parent = this.gameObject.transform;
            Destroy(newHit, 1);
            StartCoroutine(waitToHit());
        }
        else if (facingRight)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x + 1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            var newHit = Instantiate(hitLine, rightPlace, Quaternion.identity.normalized);
            newHit.transform.parent = this.gameObject.transform;
            Destroy(newHit, 1);
            StartCoroutine(waitToHit());
        }
        else if (!facingRight)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x + -1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            var newHit = Instantiate(hitLine, rightPlace, Quaternion.Euler(0, 180, 0));
            newHit.transform.parent = this.gameObject.transform;
            Destroy(newHit, 1);
            StartCoroutine(waitToHit());
        }
    }
    IEnumerator waitToHit()
    {
        yield return new WaitForSeconds(1);
        attacking = false;
    }
}


//register if attack button is hit
//get the direction youre facing
//spawn hitbox in that direction
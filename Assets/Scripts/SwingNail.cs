using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwingNail : MonoBehaviour
{
    private bool facingRight;
    public GameObject hitLine;
    private Vector3 rightPlace;

    
    public bool attacking;

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
    }
    private void swing()
    {
        if (facingRight)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x + 1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            var newHit = Instantiate(hitLine, rightPlace, Quaternion.identity);
            newHit.transform.parent = this.gameObject.transform;
            Destroy(newHit, 1);
            StartCoroutine(waitToHit());
            
        }
        else if (!facingRight)
        {
            rightPlace = new Vector3(this.gameObject.transform.position.x + -1f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            var newHit = Instantiate(hitLine, rightPlace, Quaternion.identity);
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
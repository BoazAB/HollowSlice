using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearEnemyNew : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public GameObject spearLeft;
    public Transform spearLeftPos;
    public int typeAttack = 0;


    private float distance;
    private float timer;

    [SerializeField]
    float loungeSpeed;

    Rigidbody2D rb2d;

    [SerializeField]
    Transform castPoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("placeHolderPlayer");
    }

    /* private void Update()
    {
        
    }
    */

    // Update is called once per frame
    void Update()
    {
        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        /*Debug.Log(distance); */

        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


        float distanceEnemyAndPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 8)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {

                typeAttack = Random.Range(1, 2);

                timer = 0;
                shoot();

                /*
                timer = 0;
                lounge();
                */

            }
        }

        //if (loungeAtPlayer(agro))

    }

    void shoot()
    {
        Instantiate(spearLeft, spearLeftPos.position, Quaternion.identity);
    }

    /*
    void loungePlayer
    {
        if (Transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(moveSpeed, 0)
        }
        else if (Transform.position.x > player.position.x)
        {
            rb2d.velocity = new Vector2(-moveSpeed, 0)
        }

    }
    */

    bool loungeAtPlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("placeHolderPlayer"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
        }

        return val;

    }

    /*
    void lounge()
    {
        Debug.Log("TestTestTest");
    }
    */

}

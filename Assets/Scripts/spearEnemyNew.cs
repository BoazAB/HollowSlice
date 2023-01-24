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

        if(distance < 8)
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

    }

    void shoot()
    {
        Instantiate(spearLeft, spearLeftPos.position, Quaternion.identity);
    }

    /*
    void lounge()
    {
        Debug.Log("TestTestTest");
    }
    */

}

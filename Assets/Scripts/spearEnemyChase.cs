using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearEnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
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

        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

}

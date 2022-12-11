using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int HP;
    public int NumMasks;

    public Image[] Masks;
    public Sprite WholeMask;
    public Sprite BrokenMask;

    // Start is called before the first frame update
    void Start()
    {
        HP = 9;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("everybody wants to be my");
            GotHit();
        }
    }

    private void GotHit()
    {

    }
}

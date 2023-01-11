using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text HealthText;

    public int HP;
    public int numOfMask;

    public Image[] Masks;
    public Sprite WholeMask;
    public Sprite BrokenMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HP > numOfMask)
        {
            HP = numOfMask;
        }
        if (HP < 0)
        {
            HP = 0;
        }
        for (int i = 0; i < Masks.Length; i++)
        {
            if (i < HP)
            {
                Masks[i].sprite = WholeMask;
            }
            else
            {
                Masks[i].sprite = BrokenMask;
            }

            if (i < numOfMask)
            {
                Masks[i].enabled = true;
            }
            else
            {
                Masks[i].enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("everybody wants to be, my");
            GotHit();
        }
    }

    private void GotHit()
    {
        HP--;
    }
}

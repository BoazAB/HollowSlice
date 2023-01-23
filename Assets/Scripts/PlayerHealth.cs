using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text HealthText;

    public int HP;
    public int numOfMask;
    public Collider2D hurtbox;

    public Image[] Masks;
    public Sprite WholeMask;
    public Sprite BrokenMask;

    public float invTime;
    public float invTimer;

    public Rigidbody2D playerRigidbody;
    public int knockback;
    private int thornTime;

    // Start is called before the first frame update
    void Start()
    {
        invTimer = invTime;
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
        if (invTimer > 0)
        {
            invTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D hurtbox)
    {
        if (invTimer <= 0 && hurtbox.gameObject.tag == "Enemy")
        {
            GotHit();
        }
    }

    private void GotHit()
    {
            HP--;
            invTimer = invTime;
            playerRigidbody.velocity = Vector2.right * knockback + Vector2.up * knockback;
            Invoke(nameof(Thorns), 5.0f);
    }

    private void Thorns()
    {
        
    }
}

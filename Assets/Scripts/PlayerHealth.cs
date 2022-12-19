using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int HP = 9;
    public Text HealthText;
    public int NumMasks;

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
        HealthText.text = HP.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HP--;
        }
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

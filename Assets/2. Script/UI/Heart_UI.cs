using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart_UI : MonoBehaviour
{
    public GameObject[] hearts;
    public int heart_count;
    private bool isDead;

    Animator anim;
    Rigidbody2D rigid;
    Collider2D coll;
    SpriteRenderer spriter;

    public GameObject player_hand; 


    void Start()
    {
        isDead = false;
        heart_count = hearts.Length;

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDead == true)
        {
            // Set Dead Code
            Debug.Log("You Die");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            if (heart_count >= 1)
            {
                heart_count -= 1;
                Destroy(collision.gameObject);
                Destroy(hearts[heart_count].gameObject);
            }
            if (heart_count < 1)
            {
                player_hand.SetActive(false);
                coll.enabled = false;
                rigid.simulated = false;
                spriter.sortingOrder = 1;
                anim.SetTrigger("Death");
                
                isDead = true;
            }
        }
    }
}

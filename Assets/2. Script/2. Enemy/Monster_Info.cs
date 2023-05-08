using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Info : MonoBehaviour
{
    public float health;

    public GameObject hand;
    public GameObject bullet_money;

    Animator anim;
    Collider2D coll;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    AudioSource audio;

    
    void Awake()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            health -= collision.gameObject.GetComponent<Bullet>().bullet_damage;
            Destroy(collision.gameObject);

            if (health <= 0)
            {
                Destroy(hand);

                coll.enabled = false; //콜라이더 비활성화
                rigid.simulated = false; //리지드바디 비활성화
                spriter.sortingOrder = 1;

                anim.SetTrigger("Death");
                audio.Play();

                Instantiate(bullet_money, transform.position, transform.rotation);
            }
            else if (health > 0)
            {
                anim.SetTrigger("Hit");
            }
        }        
    }

    void Death()
    {
        Destroy(gameObject);
        GameManager.instance.spawner.GetComponent<Spawner>().killCount++;
    }
}

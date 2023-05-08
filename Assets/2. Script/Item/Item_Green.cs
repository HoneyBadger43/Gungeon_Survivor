using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Green : MonoBehaviour
{
    public Sprite[] sprites;

    SpriteRenderer spriter;

    Animator anim;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetTrigger("Open");
            }
        }
    }

    void SpawnItem()
    {
        Instantiate(GameManager.instance.WeaponPrefabs[2], transform.position, Quaternion.identity);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money_Movement : MonoBehaviour
{
    private float distance; // money¿Í playerÀÇ °Å¸®
    public float money_moveSpeed;

    public GameObject player;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 money_move_dir = player.transform.position - transform.position;

        distance = Mathf.Abs(Vector2.Distance(player.transform.position, transform.position));

        if (distance < 10)
        {
            rigid.MovePosition(rigid.position + money_move_dir * money_moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("µ· È¹µæ +1");
            GameManager.instance.money_count += 1;
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        player = GameManager.instance.player;
    }
}

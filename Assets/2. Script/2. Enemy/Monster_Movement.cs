using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Movement : MonoBehaviour
{
    public const float MOVESPEED = 1.5f;
    private float speed;
    public Rigidbody2D player; //Ÿ���� RigidBody

    private Vector2 dirVec_toPlayer;
    public float distance;

    Rigidbody2D rigid; //���� RigidBody
    Animator anim;

    private bool isLive = true;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) //�Ѵ� false���� ���� X
        {                                                                 //���� state�� ������ �������� �Լ�
            return;
        }

        //�� �̵�
        distance = Mathf.Abs(Vector2.Distance(player.position, rigid.position));
        speed = MOVESPEED;

        if (distance > 5.5f)
        {
            anim.SetBool("Walk", distance > 5.5f);

 
            dirVec_toPlayer = player.position - rigid.position;

            Vector2 nextVec_toPlayer = dirVec_toPlayer.normalized * MOVESPEED * Time.fixedDeltaTime; 

            rigid.MovePosition(rigid.position + nextVec_toPlayer);

            rigid.velocity = Vector2.zero;
        }
        else if (distance > 4.5 && distance < 5.5f)
        {
            anim.SetBool("Walk", false);
            speed = 0;
        }
        else if (distance < 5.5f)
        {
            anim.SetBool("Walk", distance < 5.5f);
            Vector2 dirVec_oppositePlayer = rigid.position - player.position;
            Vector2 nextVec_oppositePlayer = dirVec_oppositePlayer.normalized * MOVESPEED * Time.deltaTime;
            rigid.MovePosition(rigid.position + nextVec_oppositePlayer);
            rigid.velocity = Vector2.zero;
        }
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        //���� ����
        if (player.position.x < rigid.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (player.position.x > rigid.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void OnEnable()
    {
        player = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}

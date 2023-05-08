using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /* ============== �Ӽ� ============== */
    public float moveSpeed;
    public Vector2 inputVec;
    public Vector2 nextVec;
    float angle;

    /* ============== ������Ʈ =============== */
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    public Transform player_hand; // -> Hunter Hand
    AudioSource audio;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        nextVec = inputVec.normalized * moveSpeed * Time.fixedDeltaTime; //�밢��
        rigid.MovePosition(rigid.position + nextVec);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.right * 30f; // ���������� �̵�
        }
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        inputVec = new Vector2(x, y);
        

        //���콺 ��ġ�� ���� �÷��̾� �� ȸ��
        Vector3 mousePos = Input.mousePosition;
        Vector3 handPos = Camera.main.WorldToScreenPoint(player_hand.position);

        mousePos.x = mousePos.x - handPos.x;
        mousePos.y = mousePos.y - handPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        player_hand.transform.rotation = Quaternion.Euler(0, 0, angle);

        //���콺 ��ġ�� ���� Player�� LocalScale ����
        if (mousePos.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            player_hand.transform.localScale = new Vector3(-1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            player_hand.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void LateUpdate() //���� ���������� �Ѿ�� ������ ����Ǵ� �Լ�
    {
        anim.SetFloat("Speed", inputVec.magnitude); //magnitude -> ���� ũ�⸸ ��ȯ
    }
}

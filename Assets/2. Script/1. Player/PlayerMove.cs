using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /* ============== 속성 ============== */
    public float moveSpeed;
    public Vector2 inputVec;
    public Vector2 nextVec;
    float angle;

    /* ============== 컴포넌트 =============== */
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
        nextVec = inputVec.normalized * moveSpeed * Time.fixedDeltaTime; //대각선
        rigid.MovePosition(rigid.position + nextVec);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.right * 30f; // 오른쪽으로 이동
        }
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        inputVec = new Vector2(x, y);
        

        //마우스 위치에 따른 플레이어 총 회전
        Vector3 mousePos = Input.mousePosition;
        Vector3 handPos = Camera.main.WorldToScreenPoint(player_hand.position);

        mousePos.x = mousePos.x - handPos.x;
        mousePos.y = mousePos.y - handPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        player_hand.transform.rotation = Quaternion.Euler(0, 0, angle);

        //마우스 위치에 따른 Player의 LocalScale 반전
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

    void LateUpdate() //다음 프레임으로 넘어가기 직전에 실행되는 함수
    {
        anim.SetFloat("Speed", inputVec.magnitude); //magnitude -> 순수 크기만 반환
    }
}

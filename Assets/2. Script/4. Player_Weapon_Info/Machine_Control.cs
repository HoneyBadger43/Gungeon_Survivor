using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Control : MonoBehaviour
{
    public GameObject bullet_prefab;

    public GameObject bullet_respawn;

    private float fire_rate = 0.08f;

    private bool canFire = false;

    Animator anim;
    AudioSource audioSource;

    void Awake()
    {
        anim = bullet_respawn.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !canFire)
        {
            StartCoroutine(GunFire());
        }
    }

    IEnumerator GunFire()
    {
        canFire = true;

        int bulletsFired = 0; // 발사한 총알 수를 체크하는 변수
        while (Input.GetMouseButton(0))
        {
            // 7발씩 묶어서 발사
            while (bulletsFired < 7)
            {
                anim.SetBool("Fire", true);
                Instantiate(bullet_prefab, bullet_respawn.transform.position, transform.rotation);
                audioSource.Play();
                bulletsFired++;
                yield return new WaitForSeconds(fire_rate);
            }

            anim.SetBool("Fire", false);

            // 7발 발사 후 0.3초 대기
            yield return new WaitForSeconds(0.3f);

            // 다시 7발 발사
            bulletsFired = 0;
        }

        canFire = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.playerHand.index++;
            QuickSlot.instance.InputGun("Machine");
            GameManager.instance.playerHand.hand_item[2] = Instantiate(QuickSlot.instance.quickSlot[2], GameManager.instance.playerHand.transform.position, Quaternion.identity);
            GameManager.instance.playerHand.hand_item[2].SetActive(false);
            GameManager.instance.playerHand.hand_item[2].transform.SetParent(GameManager.instance.playerHand.transform);
            Destroy(gameObject);
        }
    }
}

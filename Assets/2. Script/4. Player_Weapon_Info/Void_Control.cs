using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void_Control : MonoBehaviour
{
    public GameObject bullet_prefab;

    public GameObject bullet_respawn;

    private float fire_rate = 0.25f;

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
            // 5발씩 묶어서 발사
            while (bulletsFired < 5)
            {
                anim.SetBool("Fire", true);
                Instantiate(bullet_prefab, bullet_respawn.transform.position, transform.rotation);
                audioSource.Play();
                bulletsFired++;
                yield return new WaitForSeconds(fire_rate);
            }

            anim.SetBool("Fire", false);

            // 5발 발사 후 0.5초 대기
            yield return new WaitForSeconds(0.5f);

            // 다시 5발 발사
            bulletsFired = 0;
        }

        canFire = false;
    }
}

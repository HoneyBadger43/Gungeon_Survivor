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

        int bulletsFired = 0; // �߻��� �Ѿ� ���� üũ�ϴ� ����
        while (Input.GetMouseButton(0))
        {
            // 5�߾� ��� �߻�
            while (bulletsFired < 5)
            {
                anim.SetBool("Fire", true);
                Instantiate(bullet_prefab, bullet_respawn.transform.position, transform.rotation);
                audioSource.Play();
                bulletsFired++;
                yield return new WaitForSeconds(fire_rate);
            }

            anim.SetBool("Fire", false);

            // 5�� �߻� �� 0.5�� ���
            yield return new WaitForSeconds(0.5f);

            // �ٽ� 5�� �߻�
            bulletsFired = 0;
        }

        canFire = false;
    }
}

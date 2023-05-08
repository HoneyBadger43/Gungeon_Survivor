using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47_Control : MonoBehaviour
{
    public GameObject bullet_prefab;

    public GameObject bullet_respawn;

    public float fire_rate;

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
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Fire",true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("Fire", false);
        }

        if (Input.GetMouseButton(0) && !canFire)
        {
            StartCoroutine(GunFire());
        }
    }

    IEnumerator GunFire()
    {
        canFire = true;

        while (Input.GetMouseButton(0))
        {
            Instantiate(bullet_prefab, bullet_respawn.transform.position, transform.rotation);
            audioSource.Play();
            yield return new WaitForSeconds(0.15f);
        }

        canFire = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.playerHand.index++;
            QuickSlot.instance.InputGun("AK47_Weapon");
            GameManager.instance.playerHand.hand_item[1] = Instantiate(QuickSlot.instance.quickSlot[1], GameManager.instance.playerHand.transform.position, Quaternion.identity);
            GameManager.instance.playerHand.hand_item[1].SetActive(false);
            GameManager.instance.playerHand.hand_item[1].transform.SetParent(GameManager.instance.playerHand.transform);

            Destroy(gameObject);
        }
    }
}

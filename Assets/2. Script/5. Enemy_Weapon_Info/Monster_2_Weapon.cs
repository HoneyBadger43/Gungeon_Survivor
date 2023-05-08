using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_2_Weapon : MonoBehaviour
{
    public GameObject bullet_prefab;
    public GameObject player;
    public Transform bullet_respawn;

    private float timer;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 8f)
        {
            timer += Time.deltaTime;

            if (timer > 4f)
            {
                timer = 0;
                StartCoroutine(GunFire());
            }
        }
    }

    void Fire()
    {
        Instantiate(bullet_prefab, bullet_respawn.position, transform.rotation);
    }

    IEnumerator GunFire()
    {
        int bulletsFired = 0; 
       
        while (bulletsFired < 5)
        {
            Instantiate(bullet_prefab, bullet_respawn.transform.position, transform.rotation);
            bulletsFired++;
            yield return new WaitForSeconds(0.3f); //총알 사이의 간격
        }

        bulletsFired = 0;
   
    }

    void OnEnable()
    {
        player = GameManager.instance.player;
    }
}

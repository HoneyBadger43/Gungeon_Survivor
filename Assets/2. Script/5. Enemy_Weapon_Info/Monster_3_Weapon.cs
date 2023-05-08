using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_3_Weapon : MonoBehaviour
{
    public GameObject bullet_prefab;
    public GameObject player;
    public Transform bullet_respawn;

    private float timer;

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < 8)
        {
            timer += Time.deltaTime;

            if (timer > 1.5f)
            {
                timer = 0;
                Fire();
            }
        }
    }

    void Fire()
    {
        Instantiate(bullet_prefab, bullet_respawn.position, transform.rotation);
    }

    void OnEnable()
    {
        player = GameManager.instance.player;
    }
}

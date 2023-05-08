using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Hand_Rotate : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        EnemyHandRotate();
    }

    void EnemyHandRotate()
    {
        //Enemy Hand 오브젝트 회전
        Vector2 dirVec_toPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        float angle = Mathf.Atan2(dirVec_toPlayer.y, dirVec_toPlayer.x) * Mathf.Rad2Deg;
        transform.localScale = new Vector3(1, 1, 1);

        if (player.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, -1, 1);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void OnEnable()
    {
        player = GameManager.instance.player.GetComponent<Transform>();    
    }
}

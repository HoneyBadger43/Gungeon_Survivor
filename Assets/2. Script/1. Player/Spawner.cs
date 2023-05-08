using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public GameObject[] ItemPrefabs;
    public Transform player;

    public float killCount;
    public float timer;
    bool boxDrop = false;
    private Vector3 itemPos;

    void Awake()
    {
        itemPos = player.position + (Vector3.up * 2f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 3f)
        {
            Instantiate(enemyPrefabs[Random.Range(0,3)], spawnPoints[Random.Range(0, 10)].position, Quaternion.identity);
            timer = 0f;
        }

        if (!boxDrop && killCount == 3)
        {
            Instantiate(ItemPrefabs[0], itemPos, Quaternion.identity);
            boxDrop = true;
        }

        if (boxDrop && killCount == 6)
        {
            Instantiate(ItemPrefabs[1], itemPos + new Vector3(0,2,0), Quaternion.identity);
            boxDrop = false;
        }
    }
}
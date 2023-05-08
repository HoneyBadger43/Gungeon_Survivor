using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public GameObject spawner;

    public GameObject[] WeaponPrefabs;
    public Hand_Item playerHand;

    public int money_count = 0;

    public float maxGameTime = 20;
    public float gameTime;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;       
    }
}

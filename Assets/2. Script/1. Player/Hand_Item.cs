using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand_Item : MonoBehaviour
{
    public GameObject[] hand_item;
    public int index = 0;

    void Awake()
    {
        hand_item = new GameObject[3];      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && index >= 0)
        {
            for (int i = 0; i < index + 1; i++)
            {
                hand_item[i].SetActive(false);
            }
            hand_item[0].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && index >= 1)
        {
            for (int i = 0; i < index + 1; i++)
            {
                hand_item[i].SetActive(false);
            }
            hand_item[1].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && index >= 2)
        {
            for (int i = 0; i < index + 1; i++)
            {
                hand_item[i].SetActive(false);
            }
            hand_item[2].SetActive(true);
        }
    }
   
}

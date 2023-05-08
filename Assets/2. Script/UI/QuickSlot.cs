using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlot : MonoBehaviour
{
    public static QuickSlot instance;

    public GameObject[] quickSlot;

    int useIndex;
    int weaponIndex;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        quickSlot = new GameObject[3];

        for (int i = 0; i < quickSlot.Length; i++)
        {
            quickSlot[i] = null;
        }

        //퀵슬롯에 Weapon0 등록
        quickSlot[0] = GameManager.instance.WeaponPrefabs[0];

        //아이템 생성 -> Hand의 자식오브젝트로 등록 후 비활성화 
        GameManager.instance.playerHand.hand_item[0] = Instantiate(quickSlot[0], GameManager.instance.playerHand.transform.position, Quaternion.identity);
        GameManager.instance.playerHand.hand_item[0].SetActive(false);
        GameManager.instance.playerHand.hand_item[0].transform.SetParent(GameManager.instance.playerHand.transform);

    }

    public void InputGun(string weaponName)
    {       
        for (int i = 0; i < quickSlot.Length; i++)
        {
            if (quickSlot[i] == null)
            {
                useIndex = i;
                break;
            }          
        }

        for (int i = 0; i < GameManager.instance.WeaponPrefabs.Length; i++)
        {
            if (GameManager.instance.WeaponPrefabs[i].name == weaponName)
            {
                weaponIndex = i;
                Debug.Log(weaponIndex);
            }               
        }

        quickSlot[useIndex] = GameManager.instance.WeaponPrefabs[weaponIndex];
    }
}


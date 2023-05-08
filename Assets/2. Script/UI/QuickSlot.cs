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

        //�����Կ� Weapon0 ���
        quickSlot[0] = GameManager.instance.WeaponPrefabs[0];

        //������ ���� -> Hand�� �ڽĿ�����Ʈ�� ��� �� ��Ȱ��ȭ 
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


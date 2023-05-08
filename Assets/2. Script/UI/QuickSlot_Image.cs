using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickSlot_Image : MonoBehaviour
{
    [SerializeField]
    public Image quickSlotImage;

    [SerializeField]
    private int quickSlotIndex;


    private void Update()
    {
        if (QuickSlot.instance.quickSlot[quickSlotIndex] != null)
        {
            for (int i = 0; i < GameManager.instance.WeaponPrefabs.Length; i++)
            {
                if (GameManager.instance.WeaponPrefabs[i].name == QuickSlot.instance.quickSlot[quickSlotIndex].name)
                {
                    GameObject weapon = GameManager.instance.WeaponPrefabs[i];
                    quickSlotImage.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
                    quickSlotImage.color = new Color(1, 1, 1, 1);
                }
            }
        }

        if (QuickSlot.instance.quickSlot[quickSlotIndex] == null)
        {
            quickSlotImage.color = new Color(1, 1, 1, 0);
        }
    }
}

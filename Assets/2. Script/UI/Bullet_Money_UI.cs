using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet_Money_UI : MonoBehaviour
{
    Text money_text;

    void Awake()
    {
        money_text = GetComponent<Text>();
    }

    void LateUpdate()
    {
        money_text.text = string.Format("{0:F0}", GameManager.instance.money_count);
    }
}

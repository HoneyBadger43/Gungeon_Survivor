using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_UI : MonoBehaviour
{
    public float gameTime;

    Text timeText;

    void Awake()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        gameTime += Time.deltaTime;
    }

    void LateUpdate()
    {
        int min = Mathf.FloorToInt(gameTime / 60);
        int sec = Mathf.FloorToInt(gameTime % 60);
        timeText.text = string.Format("{0:D2}:{1:D2}", min, sec);
    }
}

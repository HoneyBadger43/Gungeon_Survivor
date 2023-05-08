using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeControl : MonoBehaviour
{
    private float shakeTimeRemaining;
    private float shakePower;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartShake(0.01f, 0.5f);
        }
    }

    private void LateUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-0.06f, 0.06f) * shakePower;
            //float yAmount = Random.Range(-0.1f, 0.1f) * shakePower;

            transform.position += new Vector3(xAmount, 0, 0f);
        }
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
    }
}

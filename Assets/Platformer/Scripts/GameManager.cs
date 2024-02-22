using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Camera cam;
    public float unitsPerSecond = 3.0f;

    private void Update()
    {
        int intTime = 400 - (int)Time.realtimeSinceStartup;
        string timeStr = $"Time \n {intTime}";
        timerText.text = timeStr;
    }

    private void FixedUpdate()
    {
        float velocity = Input.GetAxis("Horizontal");
        Vector3 force = Vector3.right * velocity;
        cam.GameObject().GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}

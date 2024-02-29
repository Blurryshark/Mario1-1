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
    private int coincount = 0;
    public TextMeshProUGUI textobject;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        textobject.text = "x" + coincount.ToString();
        textobject.text = "0";
    }

    private void Update()
    {
        int intTime = 100 - (int)Time.realtimeSinceStartup;
        string timeStr = "Time: " + intTime.ToString();
        timerText.text = timeStr;
        if( intTime < 0 )
            Debug.Log("Ran out of time!");
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // hit.collider.gameObject.SetActive(false);
                // if (hit.collider.gameObject.name == "Question(Clone)")
                // {
                //     coincount++;
                //     score = 200 * coincount;
                //     textobject.text = "x" + coincount;
                //     scoreText.text = score.ToString();
                // }
            }
        }
    }

    private void FixedUpdate()
    {
        float velocity = Input.GetAxis("Horizontal");
        Vector3 force = Vector3.right * velocity;
        cam.GameObject().GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
    }
}

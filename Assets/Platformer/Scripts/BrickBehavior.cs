using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BrickBehavior : MonoBehaviour
{
    private AudioSource speaker;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        speaker = GetComponent<AudioSource>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                speaker.Play();
                hit.collider.gameObject.SetActive(false);
            }
        }
    }

    private void OnMouseDown()
    {
        
    }
}

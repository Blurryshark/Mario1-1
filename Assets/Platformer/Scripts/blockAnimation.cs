using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockAnimation : MonoBehaviour
{
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        InvokeRepeating("change", 1f, 0.15f);
    }

    void change()
    {
        float currOff = rend.material.mainTextureOffset.y;
        currOff += -0.2f;
        rend.material.mainTextureOffset = new Vector2(0, currOff);
    }
    void Update()
    {
        
    }
}

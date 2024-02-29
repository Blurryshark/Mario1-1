using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Debug.Log("MArio is Dead!!");
    }
}

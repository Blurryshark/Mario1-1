using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    public float acceleration = 100f;
    public float maxspeed = 100f;
    public float jumpImpulse = 10f;
    public float jumpBoost = 10f;
    public bool isgrounded;
    public bool sprinting;
    private int coincount = 0;
    private int score = 0;
    public TextMeshProUGUI textobject;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private void Update()
    {
        int intTime = 100 - (int)Time.realtimeSinceStartup;
        string timeStr = "Time: " + intTime.ToString();
        timerText.text = timeStr;
        if( intTime < 0 )
            Debug.Log("Ran out of time!");
        
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody rb = GetComponent<Rigidbody>(); 
        rb.velocity += Vector3.right * horizontalMovement * Time.deltaTime * acceleration;
        
        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y;
        
        Vector3 start = transform.position; 
        Vector3 end = start + Vector3.down * halfHeight; 
        
        //Debug.DrawLine(start,end,Color.blue, 0f, false);
        sprinting = (Input.GetKey(KeyCode.LeftShift));
        isgrounded = (Physics.Raycast(start, Vector3.down, halfHeight));
        if (isgrounded && Input.GetKeyDown(KeyCode.Space))
        {
                rb.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        } else if (!isgrounded && Input.GetKey(KeyCode.Space))
        {
            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
            }
        }
       
        if (Math.Abs(rb.velocity.x) > maxspeed) 
        { 
            Vector3 newVel = rb.velocity; 
            newVel.x = Math.Clamp(newVel.x, -maxspeed, maxspeed);
            if (sprinting)
            {
                newVel.x += 2f;
            }
            rb.velocity = newVel;
        }

        if (isgrounded&&Math.Abs(horizontalMovement) < .50f)
        {
            Vector3 newVel = rb.velocity;
            newVel.x *= 1f - Time.deltaTime;
            rb.velocity = newVel;
        }

        float yaw = (rb.velocity.x > 0) ? 90 : -90;
        transform.rotation = Quaternion.Euler(0f, yaw ,0f);

        float speed = rb.velocity.x;
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("Speeed", Math.Abs(speed));
        anim.SetBool("in Air", !isgrounded);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.name == "Question(Clone)")
        {
            coincount++;
            textobject.text = "x" + coincount;
            score += 100;
        } else if (other.gameObject.name == "Brick(Clone)")
        {
            score += 100;
        }

        if (other.gameObject.name == "FlagPole(Clone)")
        {
            score += 100;
            Destroy(this);
            Debug.Log("Level Passed!");
        }
        scoreText.text = score.ToString();
        
        if (other.gameObject.name != "testBlock(Clone)" && other.gameObject.name != "Stone(Clone)")
          Destroy(other.gameObject);
    }
}

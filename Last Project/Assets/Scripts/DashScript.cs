using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : PlayerController
{
    [SerializeField] float dashForce;
    [SerializeField] float dashDuration;
    [SerializeField] Canvas UI;
    float lastGravity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UI.enabled = false;
            GetComponent<JumpScript>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            lastGravity = rb.gravityScale; 
            rb.gravityScale = 0.2f;
            rb.AddForce(new Vector2(dashForce * GetDirection(), 0), ForceMode2D.Impulse);   
            StartCoroutine(Dash());
        }

    }
    IEnumerator Dash()
    {
        yield return new WaitForSeconds(dashDuration);
        rb.gravityScale = lastGravity;  
        GetComponent<DashScript>().enabled = false;//отключаем скрипт после рывка
        GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<JumpScript>() .enabled = true; 
        GetComponent<PlayerController>().enabled = true;
    }
}

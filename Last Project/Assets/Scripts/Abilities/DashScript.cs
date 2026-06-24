using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : PlayerController
{
    [SerializeField] float dashForce;
    [SerializeField] float dashDuration;
    [SerializeField] Canvas UI;
    PlayerFillAnimation fillAnimation;
    PlayerController controller;
    float lastGravity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fillAnimation = GetComponent<PlayerFillAnimation>();
        controller = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UI.enabled = false;
            GetComponent<JumpScript>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            fillAnimation.PlayFill(Color.white);
            lastGravity = rb.gravityScale;
            rb.gravityScale = 0.2f;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(dashForce * controller.FacingDirection, 0), ForceMode2D.Impulse);
            StartCoroutine(Dash());

        }

    }
    IEnumerator Dash()
    {
        yield return new WaitForSeconds(dashDuration);
        rb.gravityScale = lastGravity;
        rb.velocity = Vector2.zero;
        GetComponent<DashScript>().enabled = false;//��������� ������ ����� �����
        GetComponent<JumpScript>().enabled = true;
        GetComponent<PlayerController>().enabled = true;
    }
}

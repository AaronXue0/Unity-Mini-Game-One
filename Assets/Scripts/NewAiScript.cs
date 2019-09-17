using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAiScript : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    [SerializeField]
    float speed;

    Vector2 movement;
    bool skillCD;

    GameObject fb;
    Rigidbody2D rbFB;
    float second;
    int predict;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        skillCD = true;
    }

    private void Update()
    {
        if (Ctrl_fb.catch_ball == 1)
            CatchBall();
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Action", 0.0f);
        if (fb != null)
        {
            GetMovement();
            HitBall();
            MovingAI(movement);
        }
        else
            movement = new Vector2(0.0f, 0.0f);
        ChangeStatement();
    }

    void ChangeStatement()
    {
        if (second >= 1.1f && skillCD == false)
            skillCD = true;
        else if (skillCD == false)
            second += Time.deltaTime;
        else if( skillCD == true)
            second = 0;
    }

    void HitBall()
    {
        //if  > 6)
        Debug.Log(Mathf.Abs(rbFB.velocity.x));
        if (Mathf.Abs(rbFB.velocity.x) < 5)
            predict = 3;
        else if (Mathf.Abs(rbFB.velocity.x) < 7)
            predict = 5;
        else
            predict = 7;
        if (Mathf.Abs(transform.position.x - rbFB.transform.position.x) < predict && skillCD == true)
        {
            skillCD = false;
            animator.SetFloat("Action", 1.0f);
        }
    }

    void CatchBall()
    {
        fb = GameObject.FindGameObjectWithTag("FB");
        rbFB = fb.GetComponent<Rigidbody2D>();
        Ctrl_fb.catch_ball = 0;
    }

    void GetMovement()
    {
        if (transform.position.y - rbFB.transform.position.y > 0.5)
            movement = new Vector2(0.0f, -0.8f);
        else if (transform.position.y - rbFB.transform.position.y < -0.5)
            movement = new Vector2(0.0f, 0.8f);
    }

    void MovingAI(Vector2 direction)
    {
        if (((Vector2)transform.position + (direction * speed * Time.deltaTime)).y > 4 || ((Vector2)transform.position + (direction * speed * Time.deltaTime)).y < -4)
            return;
        if (Mathf.Abs(direction.y) < 0.01)
            return;
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        animator.SetFloat("Speed", Mathf.Abs(direction.y));
    }

    private void Reset()
    {
        animator.SetFloat("Action", 0.0f);
    }

}

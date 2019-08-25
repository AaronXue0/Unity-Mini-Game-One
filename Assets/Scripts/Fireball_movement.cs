using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    private SpriteRenderer sr;

    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Vector2 startmovement;

    public static int reverse;
    private int stop;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        stop = 0;
        if(reverse < 0)
        {
            sr.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        //Debug.Log(rb.velocity.ToString());
        if (rb.velocity.x > 0)
            sr.flipX = true;
        else if (rb.velocity.x < 0)
            sr.flipX = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) //player hit the ball
    {
        if (collision.gameObject.tag == "Player" && stop == 0)
        {
            if (rb.velocity.x > 10)
                rb.velocity = new Vector2(10f, rb.velocity.y);
            if (rb.velocity.y < 1)
                rb.velocity = new Vector2(rb.velocity.x, 2f);
            if (rb.velocity.y > 10)
                rb.velocity = new Vector2(rb.velocity.x, 9f);
            if (Mathf.Abs(rb.velocity.x) < 1f)
            {
                rb.velocity = new Vector2(reverse * 1 * Random.Range(0.9f, 1f) * startmovement.x, Random.Range(-1f, 1f) * startmovement.y);
            }
            else if (Mathf.Abs(rb.velocity.x) < 12f && collision.transform.position.y >= transform.position.y)
            {
                rb.velocity = new Vector2(-1 * Random.Range(1.1f, 1.2f) * rb.velocity.x, Random.Range(-1.5f,-1.1f) * rb.velocity.y);
            }
            else if (Mathf.Abs(rb.velocity.x) < 12f && collision.transform.position.y <= transform.position.y)
            {
                rb.velocity = new Vector2(-1 * Random.Range(1.1f, 1.2f) * rb.velocity.x, Random.Range(1.1f, 1.5f) * rb.velocity.y);
            }
            else if (Mathf.Abs(rb.velocity.y) < 8f && collision.transform.position.y <= transform.position.y)
            {
                rb.velocity = new Vector2(-1 * rb.velocity.x, Random.Range(1.1f, 1.2f) * rb.velocity.y);
            }
            else if (Mathf.Abs(rb.velocity.y) < 8f && collision.transform.position.y >= transform.position.y)
            {
                rb.velocity = new Vector2(-1 * rb.velocity.x, Random.Range(-1.2f, -1.1f) * rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(-1 * rb.velocity.x, rb.velocity.y);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//hit the left || right wall
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            GetDestory();
            Score.score_ai += 1;
            Ctrl_fb.ctrl = 1;
        }
        else if(collision.gameObject.tag == "RightWall")
        {
            GetDestory();
            Score.score_player+=1;
            Ctrl_fb.ctrl = 0;
        }
    }
    void GetDestory()
    {
        stop = 1;
        Ctrl_fb.create_ball = 1;
        rb.velocity = new Vector2(0, 0);
        animator.SetTrigger("Exp");
        //Destroy(gameObject);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.01f);
    }
}


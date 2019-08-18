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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        Debug.Log(rb.velocity.ToString());
        if (rb.velocity.x > 0)
            sr.flipX = true;
        else if (rb.velocity.x < 0)
            sr.flipX = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) //player hit the ball
    {
        if (collision.gameObject.tag == "Player")
        {
            if (rb.velocity.x > 10)
                rb.velocity = new Vector2(10f, rb.velocity.y);
            if (rb.velocity.y > 4 || rb.velocity.y < 1)
                rb.velocity = new Vector2(rb.velocity.x, 1.5f);
            if (Mathf.Abs(rb.velocity.x) < 1f)
            {
                rb.velocity = new Vector2(1 * Random.Range(0.9f, 1f) * startmovement.x, Random.Range(-1f, 1f) * startmovement.y);
            }
            else if (Mathf.Abs(rb.velocity.x) < 10f && collision.transform.position.y >= transform.position.y)
            {
                rb.velocity = new Vector2(-1 * Random.Range(1.1f, 1.2f) * rb.velocity.x, Random.Range(-1.5f,-1.1f) * rb.velocity.y);
            }
            else if (Mathf.Abs(rb.velocity.x) < 10f && collision.transform.position.y <= transform.position.y)
            {
                rb.velocity = new Vector2(-1 * Random.Range(1.1f, 1.2f) * rb.velocity.x, Random.Range(1.1f, 1.5f) * rb.velocity.y);
            }
            else if (Mathf.Abs(rb.velocity.y) < 3f && collision.transform.position.y <= transform.position.y)
            {
                rb.velocity = new Vector2(-1 * rb.velocity.x, Random.Range(1.1f, 1.2f) * rb.velocity.y);
            }
            else if (Mathf.Abs(rb.velocity.y) < 3f && collision.transform.position.y >= transform.position.y)
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
            //GetDestory();
        }
        else if(collision.gameObject.tag == "RightWall")
        {
            //GetDestory();
        }
    }
    void GetDestory()
    {
        rb.velocity = new Vector2(0, 0);
        animator.SetTrigger("Exp");
        //Destroy(gameObject);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 0.01f);
        Debug.Log("Lwall");
    }
}
/*
 if (Mathf.Abs(rb.velocity.x) < 1f)
            {
                rb.velocity = new Vector2(startmovement.x, Random.Range(-1f, 1f)*startmovement.y);
            }
            else if (Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                rb.velocity = new Vector2(rb.velocity.x * -1.2f, 1 * 1.2f);
            }
            else if ( Mathf.Abs(rb.velocity.x) > 12f && Mathf.Abs(rb.velocity.y) < 3.01f)
            {
                rb.velocity = new Vector2(rb.velocity.x * -1f,rb.velocity.y * Random.Range(1f, 1.5f));
            }
            else if (Mathf.Abs(rb.velocity.x) < 12f && Mathf.Abs(rb.velocity.y) < 3.01f)
            {
                rb.velocity = new Vector2(rb.velocity.x * -1.2f, rb.velocity.y * Random.Range(-1f, 1.5f));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x * -1f, rb.velocity.y * 1f);
            }
*/

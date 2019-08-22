using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public Rigidbody2D rb;

    private Vector2 movement;
    public float Action_CD;
    private float CD;

    private GameObject fb;
    private Rigidbody2D rb_fb;
    private float pos_y;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        CD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position.y - pos_y);
        if (Ctrl_fb.catch_ball == 1)
            Catchball();
        if(fb != null)
        {
                getmovement();
        }
    }

    void getmovement()
    {
        if(transform.position.y >= rb_fb.transform.position.y)
            movement = new Vector2(0.0f, -1f);
        else
            movement = new Vector2(0.0f, 1f);
    }

	void FixedUpdate()
	{
        if (CD - 0.01 < 0.01)
		{
            //Debug.Log(movement + "AI");
            AI_Move(movement);
		}
	}

    void Catchball()
    {
        fb = GameObject.FindGameObjectWithTag("FB");
        rb_fb = fb.GetComponent<Rigidbody2D>();
        Ctrl_fb.catch_ball = 0;
    }

	void AI_Move(Vector2 direction)
    {
        if (((Vector2)transform.position + (direction * speed * Time.deltaTime)).y > 4 || ((Vector2)transform.position + (direction * speed * Time.deltaTime)).y < -4)
            return;
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
		animator.SetFloat("Speed", Mathf.Abs(direction.y));
        //Debug.Log(pos_y);
	}
}

//transform.position = Vector2.MoveTowards(transform.position, fb.transform.position, speed * Time.deltaTime);
//Debug.Log(fb.transform.position.x - transform.position.x);

/*
 * ai -> chase,predic
 * score -> win/lose

#fireball -> movement
#tilemap : image broken
*/
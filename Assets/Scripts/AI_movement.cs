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
    
    // Start is called before the first frame update
    void Start()
	{
		rb = this.GetComponent<Rigidbody2D>();
		CD = 0;
	}

	// Update is called once per frame
	void Update()
	{
		Reset();
        //transform.position = Vector2.MoveTowards(transform.position, fb.transform.position, speed * Time.deltaTime);
        //Debug.Log(fb.transform.position.x - transform.position.x);
        if(CD < 0.01)
        {
            //animator.SetFloat("Action", 1.0f);
            CD = Action_CD;
        }
        else if (CD > 0.0)
        {
            CD -= Time.deltaTime;
        }
    }

	void FixedUpdate()
	{
		if (CD - 0.01 < 0.01)
		{
            //Debug.Log(movement + "AI");
            if (Mathf.Abs(movement.y) > 0)
            {
                movement.x = 0f;
                Player_Move(movement);
            }
		}
	}

	void Player_Move(Vector2 direction)
	{
		if (((Vector2)transform.position + (direction * speed * Time.deltaTime)).y > 4 || ((Vector2)transform.position + (direction * speed * Time.deltaTime)).y < -4)
			return;
        if (movement.y >= 1.0f)
            movement.y = 1.0f;
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
		animator.SetFloat("Speed", Mathf.Abs(direction.y));
	}

	private void Reset()
	{
		animator.SetFloat("Action", 0.0f);
	}
}

/*
 * instantiate flame : "fly" and "face" the right side!

fireball -> movement
ai -> chase,predic
tilemap : image broken
score
*/
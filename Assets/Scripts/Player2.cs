using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
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
    //public Text txt_CD;

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
        if (Input.GetKey(KeyCode.L) && CD < 0.01)
        {
            animator.SetFloat("Action", 1.0f);
            CD = Action_CD;
        }
        else if (CD > 0.0)
        {
            CD -= Time.deltaTime;
        }
        movement = new Vector2(0.0f, Input.GetAxis("Vertical2"));
    }

    void FixedUpdate()
    {
        if (CD - 0.01 < 0.01)
        {
            Player_Move(movement);
        }
    }

    void Player_Move(Vector2 direction)
    {
        if (((Vector2)transform.position + (direction * speed * Time.deltaTime)).y > 4 || ((Vector2)transform.position + (direction * speed * Time.deltaTime)).y < -4)
            return;
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        animator.SetFloat("Speed", Mathf.Abs(direction.y));
    }

    void Reset()
    {
        animator.SetFloat("Action", 0.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private Vector2 movement;
    //public Text txt_CD;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            animator.SetFloat("Action", 1.0f);
    }

    void FixedUpdate()
    {
        Reset();
        movement = new Vector2(0.0f, Input.GetAxis("Vertical"));
        Player_Move(movement);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl_fb : MonoBehaviour
{
    public GameObject fb;
    private SpriteRenderer sr;

    public static int ctrl;
    public static int create_ball;
    public static int catch_ball;

    [SerializeField]
    public float max_time;
    private float delay_time;

    // Start is called before the first frame update
    void Start()
    {
        ctrl = 1;
        create_ball = 1;
        delay_time = 1f;
        Fireball_movement.reverse = 1;
        //Debug.Log(leftposition.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(create_ball == 1)
        {
            delay_time += 0.5f * Time.deltaTime;
        }
        if(delay_time >= max_time)
        {
            delay_time = 0;
            create_fb();
            create_ball = 0;
        }
    }

    void create_fb()
    {
        if (ctrl == 1)
        {
            Instantiate(fb,
                        new Vector3(-6.8f, Random.Range(-4f,4f), 0.0f),
                        Quaternion.identity);
            Fireball_movement.reverse = 1;
        }
        else if(ctrl == 0)
        {
            Instantiate(fb,
                        new Vector3(6.8f, Random.Range(-4f, 4f), 0.0f),
                        Quaternion.identity);
            Fireball_movement.reverse = -1;
        }
        catch_ball = 1;
    }
}

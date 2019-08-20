using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crtl_fb : MonoBehaviour
{
    public GameObject fb;
    private SpriteRenderer sr;

    public static int ctrl;
    public static int create_ball;

    // Start is called before the first frame update
    void Start()
    {
        ctrl = 1;
        create_ball = 1;
        //Debug.Log(leftposition.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(create_ball == 1)
        {
            create_ball = 0;
            create_fb();
        }
    }

    void create_fb()
    { 
        if (ctrl == 1)
        {
            Instantiate(fb,
                        new Vector3(-6.8f, 0.0f, 0.0f),
                        Quaternion.identity);
        }
        else if(ctrl == 0)
        {
            Instantiate(fb,
                        new Vector3(6.8f, 0.0f, 0.0f),
                        Quaternion.identity);
        }
    }
}

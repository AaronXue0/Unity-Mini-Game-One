using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score_ai;
    public static int score_player;

    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = score_player + " : " + score_ai;   
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score_player + " : " + score_ai);
        txt.text = score_player + " : " + score_ai;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score_ai;
    public static int score_player;

    private Text txt;
    private float delay_time;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = score_player + " : " + score_ai;
        delay_time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score_player + " : " + score_ai);
        txt.text = score_player + " : " + score_ai;
        if(score_ai >= 5 || score_player >= 1)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        delay_time += Time.deltaTime;
        if(delay_time >= 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}

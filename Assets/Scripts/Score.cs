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

    private int gamemode;
    [SerializeField]
    private int endScoreAi;
    [SerializeField]
    private int endScorePlayer;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = score_player + " : " + score_ai;
        delay_time = 0.0f;
        gamemode = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(gamemode);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score_player + " : " + score_ai);
        txt.text = score_player + " : " + score_ai;
        if(gamemode == 1)
        {
            if (score_ai >= endScoreAi || score_player >= endScorePlayer)
            {
                if(score_ai >= endScoreAi)
                    txt.text = "You lose";
                else if (score_player >= endScorePlayer)
                    txt.text = "You Win";
                EndGame();
            }
        }
        else if(gamemode == 2)
        {
            if (score_ai >= endScoreAi || score_player >= endScorePlayer)
            {
                if (score_ai >= endScoreAi)
                    txt.text = "Player2 Win";
                else if (score_player >= endScorePlayer)
                    txt.text = "Player1 Win";
                EndGame();
            }
        }
    }

    void EndGame()
    {
        delay_time += Time.deltaTime;
        if(delay_time >= 1.5)
        {
            SceneManager.LoadScene(0);
            Score.score_ai = 0;
            Score.score_player = 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField]
    private Text txtTime;
    [SerializeField]
    private Text txtScore;

    private float time = 10.0f;
    private int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        this.UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        Debug.LogFormat("UpdateScoreUI: {0}", this.score);
        this.txtScore.text = string.Format("{0} Point", score);
    }

    public void IncreaseScore(int score) 
    {
        this.score += score;
        
        InfoManager.instance.score = this.score;

        Debug.LogFormat("score: {0}", this.score);
    }
    public void DecreaseScore(int score)
    {
        this.score -= score;
    }


    void Update()
    {
        if (this.isGameOver) return;

        this.time -= Time.deltaTime;    //매프레임마다 감소된 시간을 표시
        //https://sosobaba.tistory.com/244 
        //https://chragu.com/entry/C-double-to-string
        this.txtTime.text = this.time.ToString("F1");   //소수점 1자리까지 표시                                 

        if (this.time <= 0) {
            if (this.isGameOver == false) {
                Debug.Log("***** Game Over *****");
                this.isGameOver = true;
                this.LoadGameOverScene();
            }
        }
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}

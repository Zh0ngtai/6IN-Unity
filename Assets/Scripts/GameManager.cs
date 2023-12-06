using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Brick;
    

    public Text timeText;
    public Text bestScoreText;
    public Text thisScoreText;
    public GameObject WinPanel;
    public GameObject Bricks;
    public GameObject LosePanel;
    public GameObject BatPrefabs;
    public static GameManager I;
    public Timer timer; 
    public Image TimerSlider;
    
   


    void Awake()
    {   
       
        I = this;
    }


    // Start is called before the first frame update


    void Start()
    {
        WhatKindOfStage();
        Time.timeScale = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {

        timeText.text = timer.CoolTime.ToString("N2");
        if (timer.CoolTime < 0)
        {
            LoseGame();

        }
        WinGame();

       
    }
    public void Stage1CreateBricks()
    {
        for (int i = 0; i < 72; i++)
        {
            GameObject newBrick = Instantiate(Brick);
            newBrick.transform.parent = GameObject.Find("Bricks").transform;

            float x = (i % 18) * 1.5f - 16.4f;
            float y = (i / 18) * 1.6f + 3.5f;

            newBrick.transform.position = new Vector3(x, y, 0);
        }
    }

    public void Stage2CreateBricks()
    {
        for (int i = 0; i < 54; i++)
        {
            GameObject newBrick = Instantiate(Brick);
            newBrick.transform.parent = GameObject.Find("Bricks").transform;

            float x = (i % 18) * 1.5f - 16.4f;
            float y = (i / 6) * 0.8f + 2.2f;

            newBrick.transform.position = new Vector3(x, y, 0);
        }
    }

    public void Stage3CreateBricks()
    {
        for (int i = 0; i < 90; i++)
        {
            GameObject newBrick = Instantiate(Brick);
            newBrick.transform.parent = GameObject.Find("Bricks").transform;

            float x = (i % 9) * 3.0f - 15.6f;
            float y = (i / 9) * 0.8f + 1.5f;

            newBrick.transform.position = new Vector3(x, y, 0);
        }
    }
    public void Stage2CreateBats()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject newBat = Instantiate(BatPrefabs);
            newBat.transform.parent = GameObject.Find("Bats").transform;

            float x = 0.0f;
            float y = 0.0f;

            newBat.transform.position = new Vector3(x, y, 0);
        }
    }
    public void Stage3CreateBats()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject newBat = Instantiate(BatPrefabs);
            newBat.transform.parent = GameObject.Find("Bats").transform;

            float x = 0.0f;
            float y = i * -2.0f;

            newBat.transform.position = new Vector3(x, y, 0);
        }
    }
    public void WhatKindOfStage()
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            Stage1CreateBricks();
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            Stage2CreateBricks();
            Stage2CreateBats();
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            Stage3CreateBricks();
            Stage3CreateBats();
        }
    }
    public void WinGame()
    {
        int bricksnum = GameObject.Find("Bricks").transform.childCount;
        if (bricksnum == 0)
        {
            Time.timeScale = 0.0f;
            WinPanel.SetActive(true);
           
            if (PlayerPrefs.HasKey("bestScore") == false)
            {
                PlayerPrefs.SetFloat("bestScore", timer.CoolTime);
            }
            else
            {
                if (PlayerPrefs.GetFloat("bestScore") < timer.CoolTime) 
                {
                    PlayerPrefs.SetFloat("bestScore", timer.CoolTime);
                }
            }
            bestScoreText.text = PlayerPrefs.GetFloat("bestScore").ToString("N2");
            thisScoreText.text = timer.CoolTime.ToString("N2");
        }       
    }
    public void LoseGame()
    {
        Time.timeScale = 0.0f;
        LosePanel.SetActive(true);
        
    }
    public void CheckBalls()
    {
        Invoke("CheckBallreal", 0.03f); 
    }
    public void CheckBallreal() 
    {
        GameObject ballfound = GameObject.Find("Ball(Clone)");
        Debug.Log(ballfound);
        if (ballfound == null)
        {
            LoseGame();
        }
    }
    public void AddTime()
    {
        timer.UpdateTime -= 7.0f;
       
    }
}

//
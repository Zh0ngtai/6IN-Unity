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
    public static GameManager I;
    float limit = 60f;
   


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
        { 
            if (limit > 0)
            {
                limit -= Time.deltaTime;
                //Time.timeScale = 0.0f;
                //limit = 0.0f;
                //LoseGame();
            }
            timeText.text = limit.ToString("N2");
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
            float y = (i / 6) * 0.8f + 2.5f;

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

    public void WhatKindOfStage()
    {
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            Stage1CreateBricks();
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            Stage2CreateBricks();
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            Stage3CreateBricks();
        }
    }
    public void WinGame()
    {
        int bricksnum = GameObject.Find("Bricks").transform.childCount;
        if (bricksnum == 0)
        {
            Time.timeScale = 0.0f;
            WinPanel.SetActive(true);
        }       
      
    }
    public void LoseGame()
    {
        Time.timeScale = 0.0f;
        LosePanel.SetActive(true);
        thisScoreText.text = limit.ToString("N2");


        if (PlayerPrefs.HasKey("bestScore") == false)
        {
            PlayerPrefs.SetFloat("bestScore", limit);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestScore") > limit)
            {
                PlayerPrefs.SetFloat("bestScore", limit);
            }
        }
        bestScoreText.text = PlayerPrefs.GetFloat("bestScore").ToString("N2");
    }
}
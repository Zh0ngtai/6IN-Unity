using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Brick;
    

    public Text timeText;
    public Text scoreText;
    public Text bestScoreText;
    public Text thisScoreText;
    public GameObject endPanel1;
    public GameObject endPanel2;
    public GameObject WinPanel;
    public GameObject Bricks;
    public GameObject LosePanel;
    public static GameManager I;
    float limit = 10;

    void Awake()
{
    I = this;
}
    
   
    // Start is called before the first frame update

    
    void Start()
    {
        CreateBricks();
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;       
        if (limit < 0)
        {
            Time.timeScale = 0.0f; limit = 0.0f;
            LoseGame();
        }
        timeText.text = limit.ToString("N2");



        WinGame();
    }
    public void CreateBricks()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newBrick = Instantiate(Brick);
            newBrick.transform.parent = GameObject.Find("Bricks").transform;

            float x = (i % 10) * 2.4f - 15.0f;
            float y = (i / 10) * 1.2f + 1.0f;

            newBrick.transform.position = new Vector3(x, y, 0);
            

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

    }




}
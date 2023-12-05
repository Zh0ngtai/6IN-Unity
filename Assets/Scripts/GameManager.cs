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
    float limit = 60;

    void Awake()
{
    I = this;
}
    
   
    // Start is called before the first frame update

    
    void Start()
    {
        CreateBricks();
        CreateBats();
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
        for (int i = 0; i < 72; i++)
        {
            GameObject newBrick = Instantiate(Brick);
            newBrick.transform.parent = GameObject.Find("Bricks").transform;

            float x = (i % 18) * 1.5f - 16.4f;
            float y = (i / 18) * 1.6f + 3.5f;

            newBrick.transform.position = new Vector3(x, y, 0);
            

        }
    }
    public GameObject BatPrefab;  // Bat 1 프리팹을 저장할 변수
    void CreateBats()
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject newBat = Instantiate(BatPrefab);
            newBat.transform.parent = GameObject.Find("Bats").transform;

            float x = 0.0f;
            float y = 0.0f;

            newBat.transform.position = new Vector3(x, y, 0);
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

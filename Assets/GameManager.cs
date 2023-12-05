using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Brick;
    public GameManager I;

    public Text timeText;
    public Text scoreText;
    public Text bestScoreText;
    public Text thisScoreText;
    public GameObject endPanel1;
    public GameObject endPanel2;
    public GameObject stage;
    // Start is called before the first frame update

    private void Awake()
    {
        I = this;
    }
    void Start()
    {
        GenerateBricks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateBricks()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject newBrick = Instantiate(Brick);
            newBrick.transform.parent = GameObject.Find("Bricks").transform;

            float x = (i % 10) * 1.4f - 6.3f;
            float y = (i / 10) * 0.8f + 1.0f;

            newBrick.transform.position = new Vector3(x, y, 0);
        }
    }
}

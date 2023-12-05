using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterMove : MonoBehaviour
{
    float direction = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>10)
        {
            direction = 0f;
            SceneManager.LoadScene("GameScene");
        }
        
        transform.position += new Vector3(direction, 0, 0);
    }
}

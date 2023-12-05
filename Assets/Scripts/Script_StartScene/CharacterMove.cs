using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(transform.position.x>12)
        {
            direction = 0;
        }
        transform.position += new Vector3(direction, 0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    int brickLife = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (brickLife == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        brickLife--;
    }


    
}

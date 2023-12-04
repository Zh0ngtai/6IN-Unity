using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public Rigidbody2D rb;
    float X, Y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Random.insideUnitSphere * speed, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
            GameManager.I.LoseGame();
        }
    }

    
}

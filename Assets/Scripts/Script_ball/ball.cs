using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = new Vector2(Random.Range(-0.5f, 0.5f), 0.5f);

        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(direction * speed, ForceMode2D.Impulse);
    }


    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    
}

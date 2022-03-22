using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float input;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(input * speed * Time.fixedDeltaTime, 0);
    }

    public void setDirection(int direction)
    {
        input = direction;
    }
}

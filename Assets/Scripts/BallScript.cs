using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Random.insideUnitCircle.normalized * 10f;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * 10f;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Target":
                {
                    ScoreManagerScript.Instance.increaseScore();
                    Destroy(other.gameObject);
                    if (ScoreManagerScript.Instance.score == 54)
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                }
            case "Lose":
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    break;
                }
        }
    }
}

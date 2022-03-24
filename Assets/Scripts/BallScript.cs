using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip blockSound;
    private Rigidbody2D rb;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        rb.velocity = Random.insideUnitCircle.normalized * 10f;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        int directionX = rb.velocity.x < 0 ? -1 : 1;
        int directionY = rb.velocity.y < 0 ? -1 : 1;
        rb.velocity = new Vector2(Mathf.Abs(rb.velocity.normalized.x * 10f) < 3f ? directionX * 3f : rb.velocity.normalized.x * 10f, Mathf.Abs(rb.velocity.normalized.y * 10f) < 3f ? directionY * 3f : rb.velocity.normalized.y * 10f);
        Debug.Log(rb.velocity.y);
        switch (other.gameObject.tag)
        {
            case "Target":
                {
                    ScoreManagerScript.Instance.increaseScore();
                    audioSource.PlayOneShot(blockSound);
                    Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
                    Destroy(other.gameObject);
                    if (ScoreManagerScript.Instance.score == 52)
                    {
                        ScoreManagerScript.Instance.score = 0;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                    }
                    break;
                }
            case "Lose":
                {
                    ScoreManagerScript.Instance.score = 0;
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                    break;
                }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource deathsound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
            GameManager.control.score--;

            if (GameManager.control.score < 0)
            {
                GameManager.control.score = 0;
            }

            else if (GameManager.control.score > 40)
            {
                GameManager.control.score = 40;
            }
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        deathsound.Play();
        GameManager.control.lives--;

        if (GameManager.control.lives < 1)
        {
            SceneManager.LoadScene("End Screen");
            GameManager.control.lives = 3;
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

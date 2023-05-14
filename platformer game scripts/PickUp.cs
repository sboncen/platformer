using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{


    public static int score;

    [SerializeField] private Text applesText;
    [SerializeField] private AudioSource collectnoise;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("apple"))
        {
            Destroy(collision.gameObject);
            GameManager.control.score++;
            collectnoise.Play();
       
        }


        

}

}

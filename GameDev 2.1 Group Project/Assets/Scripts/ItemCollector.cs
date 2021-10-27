using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // imports code to allow Text to be used 

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private Text cherriesText;

    //This is the variable for the cherry pick up sound effect
    [SerializeField] private AudioSource cherrySound;

    /* This method is called when the player collides with the cherry 
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry")) // checks if the tag is "Cherry"
        {
            cherrySound.Play();
            Destroy(collision.gameObject); // destroys the cherry object
            cherries++; // increases the cherry counter
            cherriesText.text = "Cherries: " + cherries; // updates the UI text on screen
        }
    }
}

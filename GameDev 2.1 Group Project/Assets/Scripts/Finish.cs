using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script handles level transitions when the player colides with the finish object.
public class Finish : MonoBehaviour
{
    // No need for '[SerializedField]' as there's only 1 sound thats going to be used.
    private AudioSource finishSound;

    // This boolean is used to check whether or not the player has already touched the finish object.
    private bool levelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 3f);
        
        }
    }

    private void CompleteLevel()
    {
        // This one line of code moves the player onto the next scene(level) in the index.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}

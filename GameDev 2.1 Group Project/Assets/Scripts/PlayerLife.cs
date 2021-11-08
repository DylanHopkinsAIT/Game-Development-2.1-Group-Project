using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour 
{
    //The death sound variable.
    [SerializeField] private AudioSource deathSound;

    private Rigidbody2D player;
    private Animator anim; // We use this to switch to the death animation

    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) // To distinguish between the different object and layers we use a new tag called 'Trap' for all the new traps
        {
            Die(); // If we are colliding with the 'Trap' tag then our player will die
        }
    }

    private void Die() // I called 'Die' as a sperate method for better organisation
    {
        player.bodyType = RigidbodyType2D.Static; /* I created the player body to be static to fix our death bug
                                                   * when our player would die hed be able to move after his death
                                                   * so in making him a static body it disables his movement system but only after he comes into contact with traps
                                                   * while if i was to do it in his 'Rigidbody2d' component he wouldnt be able to move at all */

        deathSound.Play();
        anim.SetTrigger("death"); // This will execute the trigger and cause the death animation
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // This will restart the current level
        
    }
}

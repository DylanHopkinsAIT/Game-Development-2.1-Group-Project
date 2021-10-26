using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) /* This part will only be executed if the collider for the platform collides with the player object */
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) /* This part will only be executed if the player leaves the platform */
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null); // We want to remove the parent values once we leave the platform as we want full freedom to our player
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    public float spdHorizontal = 7.0f;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        CharacterMovement();
    }

    /* Character Movement Script 
     * 
     * Rather than hard coding the input keys, use the inputs defined inside unity.
     * Go to Edit > Project Settings > Input Manager > Axes to see the different types available.
     * This can be better as it allows for multiple types of control (Keyboard, Joystick etc.) without hard coding for each.
     * 
     */
    private void CharacterMovement() 
    {
        //Set float dirX equal to the horizontal axis ranging between -1 and 1, allowing analog support.
        float dirHorizontal = Input.GetAxisRaw("Horizontal");

        //Player Move Left(-1 to -0.1) / Right (0.1 to 1) by using horizontal as a multiplier, times the speed.
        player.velocity = new Vector2(dirHorizontal * spdHorizontal, player.velocity.y);

        //Player Jump from Input manager, rather than hard coding spacebar.
        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, 14f);
        }

    }
}

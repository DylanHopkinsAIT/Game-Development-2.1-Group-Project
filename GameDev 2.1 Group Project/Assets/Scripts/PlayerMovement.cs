using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private Animator anim;
    private SpriteRenderer sprite;

    //Using [SerializeField] allows the values to be changed in unity, but is better practice than just making the variable public.
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpSpeed = 14.0f;
    private float dirHorizontal = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        CharacterMovement();
        AnimationState();
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
        dirHorizontal = Input.GetAxisRaw("Horizontal");

        //Player Move Left(-1 to -0.1) / Right (0.1 to 1) by using horizontal as a multiplier, times the speed.
        player.velocity = new Vector2(dirHorizontal * moveSpeed, player.velocity.y);

        //Player Jump from Input manager, rather than hard coding spacebar.
        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

    }

    //Test if player is moving horizontally to determine what animation should play
    private void AnimationState() 
    {
        //Moving Right (dirHorizontal is between 0.1 and 1)
        if (dirHorizontal > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;

        }

        //Moving Left (dirHorizontal is between -1 and -0.1)
        else if (dirHorizontal < 0)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }

        //Idle (dirHorizontal is 0)
        else
        {
            anim.SetBool("running", false);
        }
    }
}

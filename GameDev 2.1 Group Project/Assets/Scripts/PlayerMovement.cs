using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;

    //Using [SerializeField] allows the values to be changed in unity, but is better practice than just making the variable public.
    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private float jumpSpeed = 14.0f;
    private float dirHorizontal = 0f;

    [SerializeField] private bool HasJumpBoost = false;
    [SerializeField] private float JBforce = 45.0f;

    /*Create an enum (a group of read - only constants) to define what type of movement is happening.
     *This is more efficient than using true or false booleans for fall/jump/run/idle every time and also a lot tidier.
     *In this instance Idle = 0 | Fall = 1 | Jump = 2 | Run = 3 
    */
    private enum MovementState {idle, run, jump, fall }

    //These variables are used for the audio source(s).
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource jbSound;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        CharacterMovement();
        AnimationState();
        JumpBoostAbility();
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
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

    }

    private void JumpBoostAbility()
    {
        if (HasJumpBoost == true && IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JBforce, ForceMode2D.Impulse);
            }
        }
    }

    //Test if player is moving to determine what animation should play
    private void AnimationState() 
    {
        MovementState state;

        //Moving Right (dirHorizontal is between 0.1 and 1)
        if (dirHorizontal > 0f)
        {
            state = MovementState.run;
            sprite.flipX = false;
        }

        //Moving Left (dirHorizontal is between -1 and -0.1)
        else if (dirHorizontal < 0)
        {
            state = MovementState.run;
            sprite.flipX = true;
        }

        //Idle (dirHorizontal is 0)
        else
        {
            state = MovementState.idle;
        }

        //Jumping
        if (player.velocity.y > .1f)
        {
            state = MovementState.jump;
        }
        else if (player.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }

        //Cast enum value (0/1/2/3 as mentioned when enum was initialized) as integer for unity animator 
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpBoost")
        {
            jbSound.Play();
            HasJumpBoost = true;
            Destroy(collision.gameObject);
        }
    }
}

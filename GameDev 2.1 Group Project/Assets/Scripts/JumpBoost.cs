using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    [SerializeField] private bool HasJumpBoost = false;
    [SerializeField] private float JBforce = 60.0f;
   
    void Update()
    {
        JumpBoostAbility();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpBoost")
        {
            HasJumpBoost = true;
            Destroy(collision.gameObject);
        }
    }

    private void JumpBoostAbility()
    {
        if (HasJumpBoost == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * JBforce, ForceMode2D.Impulse);
            }
        }
    }
}

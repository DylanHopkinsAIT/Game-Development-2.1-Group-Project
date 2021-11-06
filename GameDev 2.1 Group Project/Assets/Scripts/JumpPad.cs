using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float BounceForce = 50.0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * BounceForce, ForceMode2D.Impulse);
        }
    }
}

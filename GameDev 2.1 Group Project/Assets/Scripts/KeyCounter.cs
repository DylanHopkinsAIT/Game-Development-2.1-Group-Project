using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    [SerializeField]private int KeyCount = 0;
    [SerializeField]private AudioSource keySound;

    void Update()
    {
        DestroyLock(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            KeyCount++;
            Destroy(collision.gameObject);
            keySound.Play();
        }
    }

    private void DestroyLock()
    {
        if (KeyCount == 3)
        {
            GameObject go = GameObject.Find(tag = "Lock");
            if (go)
            {
                Destroy(go.gameObject);
            }
        }
    }
}

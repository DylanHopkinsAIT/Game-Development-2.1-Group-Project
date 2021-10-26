using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 3f; // This is the speed we want the saw to rotate at
     private void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime); // This will rotate the 'Z' value of the image making it spin like a saw
    }
}

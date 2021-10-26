using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; /* We are making an array of waypoints so that in the future we can have more then 1
                                                      * We use the [SerializeField] so that we can use it in the editor */
    private int currentWaypointIndex = 0; /* this is the current waypoint we are working with
                                           * we dont need the [SerializeField] as we can manage it within the script
                                           0 = the first index of the first waypoint*/

    [SerializeField] private float speed = 2f; /* this is the speed at which we want the platform to move at */

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f) /* this way can check the distance between the platform and the currently set up waypoint 
                                                                                                             * if the current waypoint and the platform have a distance of < .1f, 
                                                                                                             * then we know we are touching the waypoint and then we want to switch to the next waypoint*/
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // we reset the currentWaypointIndex to 0 meaning we reached our waypoint
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed); /* the speed is determined by our game units in our case it is a 16x16 unit
                                                                                                                                                   * and we would like for the platform to move at the speed of 2 game units either direction
                                                                                                                                                   * Time.deltaTime ignores the frames per second as the platform would move across the screen rapidly
                                                                                                                                                   * (Makes the game Frame Rate Independent)*/
    }
}
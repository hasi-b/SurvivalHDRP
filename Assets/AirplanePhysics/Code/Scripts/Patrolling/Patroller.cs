using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] waypoints;
    public float speed;
    private int waypointIndex;
    private float dist;
    public Animation animation;
    void Start()
    {
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }
    void Patrol()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
    void IncreaseIndex()
    {
        waypointIndex = Random.Range(0,waypoints.Length);
        if(waypointIndex>= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
}

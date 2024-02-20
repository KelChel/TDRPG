using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public int health = 100;
    private Transform target;
    private int waypointIndex = 0;

    private void Start()
    {
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <=0)
        {
            Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }   
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy (gameObject);
    }

}

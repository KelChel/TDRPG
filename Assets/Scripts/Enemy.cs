using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    public int waveCost = 1;

    public float startHealth = 100;
    private float health;

    private Transform target;
    private int waypointIndex = 0;



    public Image healthBar;

    private void Start()
    {
        health = startHealth;
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

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

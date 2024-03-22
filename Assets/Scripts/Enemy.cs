using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float startHealth = 100;
    public int pathNumber = 1;

    private float health;
    private Waypoints waypoints;
    private Transform target;
    private int waypointIndex = 0;
    private Transform[] points;

    public Image healthBar;
    

    private Vector3 originalScale; 
    private Vector3 originalHealthScale;

    private void Start()
    {
        waypoints = GameObject.FindObjectOfType<Waypoints>();
        points = waypoints.GetWaypoints(pathNumber);
        target = points[0];

        health = startHealth;

        // Сохраняем оригинальный масштаб врага
        originalScale = transform.localScale;
        originalHealthScale = healthBar.rectTransform.localScale;


    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(speed * Time.deltaTime * dir.normalized, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }

        // Поворачиваем врага
        if (dir.x < 0)
        {
            // Если точка находится слева от врага, повернуть его влево
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
            healthBar.rectTransform.localScale = new Vector3(-originalHealthScale.x, originalHealthScale.y, originalHealthScale.z);
        }
        else
        {
            // Если точка находится справа от врага, повернуть его вправо
            transform.localScale = originalScale;
            healthBar.rectTransform.localScale = originalHealthScale;
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = points[waypointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    void Die()
    {
        Destroy(gameObject);
    }

}

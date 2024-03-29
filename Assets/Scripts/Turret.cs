using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;


    [Header("Attributes")]

    public float damage = 50f;
    public float range = 3f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 1000f;

    public GameObject bulletPrefab;
    public Transform firePoint;



    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        StatsUpdate();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            return;
        }



        Vector3 dir = target.position - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, dir);
        partToRotate.transform.rotation = Quaternion.RotateTowards(partToRotate.transform.rotation, toRotation, turnSpeed * Time.deltaTime);

        float scaleX = Mathf.Sign(dir.x);
        transform.localScale = new Vector3(scaleX, 1f, 1f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }



    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {

            bullet.Seek(target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void StatsUpdate()
    {

        if (PlayerPrefs.GetFloat("Turret1Range") == 0f)
        {
            range = 3f;
        }
        else
        {
            range = PlayerPrefs.GetFloat("Turret1Range");
        }


    }
}

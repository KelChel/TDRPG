using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 15f;  //velosity of bullet
    public int damage = 50;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public GameObject bulletPrefab;

    private void Start()
    {
        StatsUpdate();
    }
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        StatsUpdate();
        
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame,Space.World);

        float angle = Vector3.SignedAngle(transform.up, dir, transform.forward);
        transform.Rotate(0f,0f, angle+90f);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);

        if (explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }

        Destroy(effectIns, 2f);

        Destroy(gameObject);
    }


    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if(collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }

    }


    void Damage (Transform enemy)
    {
       Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public void StatsUpdate()
    {
        if (PlayerPrefs.GetInt("Turret1Damage")== 0)
        {
            damage = 50;
        }
        else
        {
            damage = PlayerPrefs.GetInt("Turret1Damage");
        }
        
    }

}

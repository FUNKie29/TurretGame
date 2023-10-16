using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    [SerializeField]
    private float projectileSpeed = 5f;

    [SerializeField]
    private Object projectileObject;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRoutine());
        StartCoroutine(LifeTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            ShootProjectile();
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator LifeTimer()
    {

        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void ShootProjectile()
    {
        GameObject bullet = Instantiate((GameObject)projectileObject, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletBehavior>().setDirection(FindNearestEnemy());
    }
    private Vector3 FindNearestEnemy()
    {
        Vector3 directionToShoot;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
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

        directionToShoot = (nearestEnemy.transform.position - transform.position).normalized;
        return directionToShoot;
    }
}

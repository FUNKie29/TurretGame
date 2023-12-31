using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    [SerializeField]
    private float projectileSpeed = 5f;

    [SerializeField]
    private Object projectileObject;

    private TurretManager turretManager;

    // Start is called before the first frame update
    void Start()
    {
        turretManager = GameObject.Find("TurretManager").GetComponent<TurretManager>();

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
            FindNearestEnemy();
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator LifeTimer()
    {

        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
        turretManager.Number_Of_Active_Turrets -= 1;
    }

    private void ShootProjectile(Vector3 bulletDirection)
    {
        GameObject bullet = Instantiate((GameObject)projectileObject, transform.position, Quaternion.identity);
        bullet.GetComponent<BulletBehavior>().setDirection(bulletDirection);
    }

    private void FindNearestEnemy()
    {
        Vector3 directionToShoot;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        if (enemies.Length > 0)
        {
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
            ShootProjectile(directionToShoot);

        }

        else return;
    }
}

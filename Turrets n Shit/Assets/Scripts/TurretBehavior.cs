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
        Instantiate(projectileObject, transform.position, Quaternion.identity);
    }
}

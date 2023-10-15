using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{

    [SerializeField]
    private float projectileSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRoutine());
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

    private void ShootProjectile()
    {

    }
}

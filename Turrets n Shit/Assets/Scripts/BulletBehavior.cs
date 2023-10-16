using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private int damage;

    [SerializeField]
    private float bulletSpeed;

    private Vector3 bulletDirection;

    

    // Start is called before the first frame update
    void Start()
    {
        Vector3 vec = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        bulletDirection = vec.normalized;

        StartCoroutine(BulletLifetime());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDirection * Time.deltaTime * bulletSpeed;
    }

    IEnumerator BulletLifetime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

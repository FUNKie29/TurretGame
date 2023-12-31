using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public int health;
    private int maxHealth = 5;
    private int damage = 10;
    private float movementSpeed = 2.5f;

    [SerializeField]
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 directionToMove = (playerPosition - transform.position).normalized;
        transform.position += directionToMove * movementSpeed * Time.deltaTime;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement character = collision.gameObject.GetComponent<PlayerMovement>();

        if (character)
        {
            player.GetComponent<PlayerMovement>().playerHealth -= damage;
            player.GetComponent<Rigidbody2D>().transform.position += (player.transform.position - transform.position).normalized * 2f;
        }
    }
}


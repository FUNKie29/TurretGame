using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Object turretObject;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        rb.transform.position += movement * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown("space")){
            CreateTurret();
        }
    }

    private void CreateTurret()
    {
        Instantiate(turretObject, new Vector2(transform.position.x + 5f, transform.position.y), Quaternion.identity);
    }
}
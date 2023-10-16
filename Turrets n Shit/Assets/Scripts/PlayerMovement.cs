using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private TurretManager turretManager;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Object turretObject;

    private int maxHealth = 50;
    public int playerHealth; 

    // Start is called before the first frame update
    void Start()
    {
        turretManager = GameObject.FindObjectOfType<TurretManager>().GetComponent<TurretManager>();

        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        rb.transform.position += movement * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown("space")){
            CreateTurret();
        }

        if(playerHealth <= 0)
        {
            Debug.Log("Lose State");
        }
    }

    private void CreateTurret()
    {
        if (turretManager.Number_Of_Active_Turrets < turretManager.Number_Of_Allowed_Turrets) {
            Instantiate(turretObject, new Vector2(transform.position.x + 5f, transform.position.y), Quaternion.identity);
            turretManager.Number_Of_Active_Turrets++;
        }
    }
}
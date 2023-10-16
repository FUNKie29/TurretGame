using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{

    public int Number_Of_Active_Turrets;
    public int Number_Of_Allowed_Turrets;

    // Start is called before the first frame update
    void Start()
    {
        Number_Of_Active_Turrets = 0;
        Number_Of_Allowed_Turrets = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

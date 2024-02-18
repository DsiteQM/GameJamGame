using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2 : MonoBehaviour
{
    public VehicleSpawner[] spawners;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            foreach (VehicleSpawner spawner in spawners)
            {
                spawner.StartRoom();
            }
        }
    }
}

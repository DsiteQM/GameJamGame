using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{

    public GameObject vehiclePrefab;
    public Transform spawnPos;
    public float minSeparationTime;
    public float maxSeparationTime;

    public bool inRoomTwo;
    public bool isRightSide;


 
    public void StartRoom()
    {
        inRoomTwo= true;
        StartCoroutine(SpawnVehicle());
    }
    IEnumerator SpawnVehicle()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            GameObject go = Instantiate(vehiclePrefab, spawnPos.position, Quaternion.identity);

            if (!isRightSide)
            {
                go.transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.forward* speed *Time.deltaTime);    
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

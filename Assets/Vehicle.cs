using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
    }
}

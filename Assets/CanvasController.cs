using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject roomTest;
    public GameObject player;
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            roomTest.SetActive(true);
            player.GetComponent<PlayerMovement>().setCanMove(false);
        }
    }
}

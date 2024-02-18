using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Interact : MonoBehaviour
{

    public Transform equipmentTransform;

    public float open = 100f;
    public float range = 10f;

    public GameObject door;
    public GameObject equipment;
    public GameObject info;
    public bool isOpening = false;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            Shoot();
        }

        if(equipment == null) { return; }
        if(equipment.transform.name == "Flashlight" && Input.GetMouseButtonDown(0))
        {
            equipment.GetComponentInChildren<Light>().enabled = true;
        }
        else if(equipment.transform.name == "Flashlight" && Input.GetMouseButtonUp(0))
        {
            equipment.GetComponentInChildren<Light>().enabled = false;
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Door")
            {
                door = hit.transform.gameObject;
                StartCoroutine(OpenDoor());
            }
            
            if (hit.transform.tag == "Equipment")
            {
                equipment = hit.transform.gameObject;
                EquipObject();
            }
        }
    }

    IEnumerator OpenDoor()
    {
        isOpening = true;
        door.GetComponent<Animator>().Play("doorOpen");
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(5.0f);
        door.GetComponent<Animator>().Play("doorClose");
        isOpening = false;
    }

    void EquipObject()
    {
        equipment.transform.position = equipmentTransform.transform.position;
        equipment.transform.rotation = equipmentTransform.transform.rotation;
        equipment.transform.SetParent(equipmentTransform);
        info.gameObject.SetActive(false);
    }
/*
    void UnequipObject()
    {
        if (equipment == null)
            return;

        equipmentTransform.DetachChildren();
        equipment.transform.eulerAngles = new Vector3(equipment.transform.eulerAngles.x, equipment.transform.eulerAngles.y, equipment.transform.eulerAngles.z - 45);
        equipment.GetComponent<Rigidbody>().isKinematic = false;
        equipment = null;
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Room1Trigger")
        {
            RenderSettings.ambientLight = Color.black;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Vehicle")
        {
            SceneManager.LoadScene(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Interact : MonoBehaviour
{

    public Transform equipmentTransform;

    public float open = 100f;
    public float range = 10f;

    public GameObject door;
    public GameObject equipment;
    public bool isOpening = false;

    public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            UnequipObject();
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            

            if (hit.transform.name == "Door")
            {
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
    }

    void UnequipObject()
    {
        if (equipment == null)
            return;

        equipmentTransform.DetachChildren();
        equipment.transform.eulerAngles = new Vector3(equipment.transform.eulerAngles.x, equipment.transform.eulerAngles.y, equipment.transform.eulerAngles.z - 45);
        equipment.GetComponent<Rigidbody>().isKinematic = false;
        equipment = null;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject scopeOverlay;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private float scopedFOV = 15f;
    [SerializeField]
    private float defaultFOV;
    private float weaponUpAnimationTime = 1f;

    private bool isScoped = false;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("Scoped", isScoped);

            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnScoped();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the camera through the mouse position
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("target"))
                {
                    //scopeOverlay.position = hit.point;
                    Debug.Log("Success");
                }
                else
                {
                    Debug.Log(hit.collider.tag);
                }
            }
        }
    }

    void OnUnScoped()
    {
       // scopeOverlay.SetActive(false);

        mainCamera.fieldOfView = defaultFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(weaponUpAnimationTime);

       //  scopeOverlay.SetActive(true);

        defaultFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }
}

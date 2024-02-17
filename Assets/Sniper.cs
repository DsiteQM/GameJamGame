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
    private GameObject weaponCamera;
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
    }

    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);
        weaponCamera.SetActive(true);

        mainCamera.fieldOfView = defaultFOV;
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(weaponUpAnimationTime);

        scopeOverlay.SetActive(true);
        weaponCamera.SetActive(false);

        defaultFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public GameObject scripts;
    public Transform playerCamera;
    public float hitDistance = 5;

    void Update()
    {
        //clicking
        if (Input.GetButtonDown("Fire1"))
        {
            LayerMask blockMask = LayerMask.GetMask("Blocks");
            LayerMask trapMask = LayerMask.GetMask("Traps");
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit targetedBlock, hitDistance, blockMask))
            {
                Destroy(targetedBlock.transform.gameObject);
                //don't use raycast, ask if there is a trap at the same position
                if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, hitDistance, trapMask))
                {
                    //its a Trap
                    Debug.Log("TRAP!!!");
                    scripts.GetComponent<HealthManager>().TakeDamage();
                }
            }
        }
    }
}

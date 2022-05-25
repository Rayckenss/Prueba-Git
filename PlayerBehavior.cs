using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior  : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Door")
        {
            other.GetComponentInParent<animacionpuerta>().ActionOpenDoor();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}

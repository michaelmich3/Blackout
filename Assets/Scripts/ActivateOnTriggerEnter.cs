using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private Collider trigger;
    [SerializeField] private GameObject objectToActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnableObject();
        }
    }

    private void EnableObject()
    {
        objectToActivate.SetActive(true);
    }
}

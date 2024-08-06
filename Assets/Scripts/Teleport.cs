using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform tp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            transform.position = tp.position;
        }
    }
}

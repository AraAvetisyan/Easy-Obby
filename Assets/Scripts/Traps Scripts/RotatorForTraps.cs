using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorForTraps : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    void FixedUpdate()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}

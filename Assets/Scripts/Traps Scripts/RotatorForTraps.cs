using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotatorForTraps : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private bool isHorizontal;
    [SerializeField] private bool isCoin;
    [SerializeField] private bool ads;
    Vector3 point1, point2;

    private void Start()
    {
        if (ads)
        {
            point1 = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            point2 = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            StartCoroutine(Move());
        }
    }

    void FixedUpdate()
    {
        if (isCoin)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        if (isHorizontal)
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
    }

    IEnumerator Move()
    {
        while (true)
        {
            transform.DOMove(point1, 1);
            yield return new WaitForSeconds(1);
            transform.DOMove(point2, 1);
            yield return new WaitForSeconds(1);
        }
    }
}

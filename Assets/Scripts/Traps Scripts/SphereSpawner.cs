using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;
    private GameObject sphere;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3);
        sphere = Instantiate(spherePrefab,transform.position,transform.rotation);
        StartCoroutine(DestroyObject());
        StartCoroutine(Spawn());
    }
    public IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(sphere);
    }
}

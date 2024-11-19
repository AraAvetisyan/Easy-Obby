using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mesh;

public class CheckShop : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] private Renderer renderer;
    [SerializeField] private Material[] meshMats;
    [SerializeField] private Material[] materials;
    [Header("Accessories")]
    [SerializeField] private GameObject[] accessories;
    [Header("Caps")]
    [SerializeField] private GameObject[] caps;
    [Header("Faces")]
    [SerializeField] private GameObject[] faces;

    void Start()
    {
        meshMats = renderer.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.HeadEquiped[i])
            {

                meshMats[0] = materials[i];
                meshMats[4] = materials[i];
                renderer.materials = meshMats;
            }
            if (Geekplay.Instance.PlayerData.BodyBoght[i])
            {
                meshMats[1] = materials[i];
                renderer.materials = meshMats;
            }
            if (Geekplay.Instance.PlayerData.LegEquiped[i])
            {
                meshMats[2] = materials[i];
                renderer.materials = meshMats;
            }
            if (Geekplay.Instance.PlayerData.FootEquiped[i])
            {
                meshMats[3] = materials[i];
                renderer.materials = meshMats;
            }
        }
        for (int i = 0; i < accessories.Length; i++)
        {
            accessories[i].SetActive(false);
            if (Geekplay.Instance.PlayerData.AccessoryEquiped[i])
            {
                accessories[i].SetActive(true);
            }
        }
        for (int i = 0; i < caps.Length; i++)
        {
            caps[i].SetActive(false);
            if (Geekplay.Instance.PlayerData.CapEquiped[i])
            {
                caps[i].SetActive(true);
            }
        }
        for(int i  = 0; i<faces.Length; i++)
        {
            faces[i].SetActive(false);
            if (Geekplay.Instance.PlayerData.FaceEquiped[i])
            {
                faces[i].SetActive(true);
            }
        }
    }

}


using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SprintButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float SprintSpeed;
    [SerializeField] private float SprintSpeedMultiplier;
    private void Start()
    {
        SprintSpeed = 1;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        SprintSpeed = SprintSpeedMultiplier;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        SprintSpeed = 1f;
    }
}

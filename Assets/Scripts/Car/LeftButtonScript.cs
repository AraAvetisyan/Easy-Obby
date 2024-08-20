
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class LeftButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float Speed;
    [SerializeField] private float SprintSpeedMultiplier;
    [SerializeField] private CarController _carController;
    public bool ReversePressed;
    private void Start()
    {
        Speed = 1;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        _carController.HorizontalAxes = -1;
        ReversePressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _carController.HorizontalAxes
            = 0;
        ReversePressed = false;
    }
}
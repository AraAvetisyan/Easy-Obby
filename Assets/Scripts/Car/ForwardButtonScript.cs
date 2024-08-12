
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
public class ForwardButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float Speed;
    [SerializeField] private float SprintSpeedMultiplier;
    [SerializeField] private CarController _carController;
    public bool ForwardPressed;
    private void Start()
    {
        Speed = 1;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Speed = SprintSpeedMultiplier;
        ForwardPressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Speed = 0f;
        ForwardPressed = false;
    }
}

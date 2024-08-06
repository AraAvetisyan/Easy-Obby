
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject player;

    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (_playerController.IsGrounded)
        {
            _playerController.IsGrounded = false;
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            rb.AddForce(jumpForce * player.transform.up);
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {

    }
   
    

}

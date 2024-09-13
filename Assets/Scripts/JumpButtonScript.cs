
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler
{


    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject player;

    [SerializeField] private bool gamemodeRunning;
    public void OnPointerDown(PointerEventData eventData)
    {
        
        if (_playerController.IsGrounded)
        {
            _playerController.IsGrounded = false;
            //rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
             rb.AddForce(jumpForce * player.transform.up);
          //  player.transform.Translate(transform.up * jumpForce * Time.deltaTime, Space.World);
            _playerController.Jumping = true;
            if (gamemodeRunning)
            {
                _playerController.Animator.SetTrigger("Jump");
            }
            StartCoroutine(OnJump());
        }
    }
    public IEnumerator OnJump()
    {
        yield return new WaitForSeconds(0.7f);
        _playerController.Jumping = false;
    }


   
    

}



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
            rb.AddForce(jumpForce * player.transform.up);
            _playerController.IsGrounded = false;

            _playerController.IsJumping = true;
            //rb.AddForce(jumpForce * player.transform.up);
            if (gamemodeRunning)
            {
                _playerController.Animator.SetTrigger("Jump");
            }
            StartCoroutine(OnJump());
        }
    }
    public IEnumerator OnJump()
    {
        yield return new WaitForSeconds(0.5f);
        _playerController.IsJumping = false;
    }
}


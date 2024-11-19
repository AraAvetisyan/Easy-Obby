

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
    [SerializeField] private AudioSource jumpAudio;
    [SerializeField] private AudioSource jumpAudio2;
    private IEnumerator jumingFalseTimer;
    public int jumpCounter;
    public int DoubleJump;
    public int DoubleJumpCounter;
    private IEnumerator doubleCor;
    private void Update()
    {
        if (_playerController._teleport.CanMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(_playerController._teleport.CanJump)
                    Jump();
            }
           
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_playerController._teleport.CanJump)
            Jump();
    }
    public void Jump()
    {
        if (_playerController._teleport.DoubleJump && DoubleJump == 0 && DoubleJumpCounter == 1)
        {
            rb.velocity = Vector3.zero;
            DoubleJump = 1;
            _playerController.IsGrounded = true;

            DoubleJumpCounter = 0;
            jumpCounter = 0;
            if (_playerController.IsCoyot && !_playerController.IsJumping)
            {
                rb.velocity = Vector3.zero;
                jumpForce = 750;
            }
        }

        if (_playerController.IsGrounded && jumpCounter == 0 && DoubleJumpCounter == 0)
        {

            if (_playerController.IsCoyot && !_playerController.IsJumping)
            {
                rb.velocity = Vector3.zero;
                jumpForce = 750;
            }
            else if (!_playerController.IsCoyot && !_playerController.IsJumping)
            {
                jumpForce = 750;
            }

            DoubleJumpCounter = 1;
            jumpCounter = 1;

            rb.AddForce(jumpForce * player.transform.up);
            _playerController.IsGrounded = false;
            _playerController.Animator.SetBool("OnGround", false);
            _playerController.IsJumping = true;
            jumpAudio2.Play();
            jumpAudio.Play();
            if (gamemodeRunning)
            {
                _playerController.Animator.SetTrigger("Jump");
                _playerController.CanPlaySound = false;
            }
            if (jumingFalseTimer != null)
            {
                StopCoroutine(jumingFalseTimer);
            }
            jumingFalseTimer = OnJump();
            StartCoroutine(jumingFalseTimer);

            if (doubleCor != null)
            {
                StopCoroutine(doubleCor);
            }
            doubleCor = DoubleJumpCorutine();
            StartCoroutine(doubleCor);
        }
    }
    public IEnumerator DoubleJumpCorutine()
    {
        yield return new WaitForSeconds(1);
        DoubleJumpCounter = 0;
    }
    public IEnumerator OnJump()
    {
        yield return new WaitForSeconds(.5f);

        _playerController.IsJumping = false;
        jumpCounter = 0;

    }
}


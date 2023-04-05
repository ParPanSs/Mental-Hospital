using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _rb;
    public Rigidbody2D rb => _rb;
    private Animator _animator;

    private bool _isTouchingWall;
    public bool isTouchingWall => _isTouchingWall;
    
    public Dialog momsDialog;
    
    private readonly float _speed = 4.5f;
    private float _horizontal;
    private float _vertical;

    private bool _isFacingRight;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal") * _speed;
        _vertical = Input.GetAxis("Vertical") * _speed;
        
        if (_rb.bodyType != RigidbodyType2D.Static)
        {
            Flip();
            _rb.velocity = new Vector2(_horizontal, _vertical);
            if (_horizontal != 0 || _vertical != 0)
                _animator.SetBool("isWalk", true);
            else
                _animator.SetBool("isWalk", false);
        }
    }

    private void Flip()
    {
        if (_isFacingRight && _horizontal < 0 || !_isFacingRight && _horizontal > 0)
        {
            Vector3 localScale = transform.localScale;
            _isFacingRight = !_isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Wall"))
            _isTouchingWall = true;
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Wall"))
            _isTouchingWall = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Mom"))
        {
            FindObjectOfType<DialogManager>().StartDialogue(momsDialog);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Mom"))
            FindObjectOfType<DialogManager>().EndDialogue();
    }
}

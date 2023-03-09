using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    private float _speed = 5.0f;
    private float _horizontal;
    private float _vertical;

    private bool _isFacingRight;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Flip();
    }

    void FixedUpdate()
    {
        _horizontal = Input.GetAxis("Horizontal") * _speed;
        _vertical = Input.GetAxis("Vertical") * _speed;
        _rb.velocity = new Vector2(_horizontal, _vertical);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovementController : MonoBehaviour
{
    public CharacterController _controller;
    
    public float _speed = 12f;
    public float _gravity = -9.81f;
    Vector3 _velocity;

    [SerializeField] private bool _canJump = true;
    public float _jumpHeight = 1;

    public Transform _groundCheck;
    public float _groundDistance = .4f;
    public LayerMask _groundMask;

    bool _isGrounded;

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = 20;
            _jumpHeight = 3;
        }
        else
        {
            _speed = 12f;
            _jumpHeight = 1;
        }

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if(_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        if (_canJump == true)
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }
        }



        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}

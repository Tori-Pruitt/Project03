using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class ShipMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private float _turnSpeed = 3f;

    Rigidbody _rb = null;

    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        SideBoost();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        MoveShip();
        TurnShip();
    }

    void MoveShip()
    {
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        _rb.AddForce(moveDirection);
    }
    void TurnShip()
    {
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }
    void SideBoost()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 boostRight = this.gameObject.transform.right * 200;
            _rb.AddForce(boostRight);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 boostLeft = -(this.gameObject.transform.right) * 200;
            _rb.AddForce(boostLeft);
        }
    }
}
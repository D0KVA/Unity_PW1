using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovmentSpeed = 2.5f;

    public float JumpForce = 4.5f;

    private Rigidbody _Rigidbody;

    private bool IsGrounded;

    public float DistationToGround = 0.1f;

    private void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
    }

    private void Jump()
    {
        _Rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    private void GroundCheck()
    {
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, DistationToGround);
    }

    private Vector3 CalculateMovment()
    {
        float HorizontalDirection = Input.GetAxis("Horizontal");
        float VerticalDirection = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * HorizontalDirection + transform.forward * VerticalDirection;

        return _Rigidbody.transform.position + Move * Time.fixedDeltaTime * MovmentSpeed;
    }

    private void FixedUpdate()
    {
        GroundCheck();

        if (Input.GetKey(KeyCode.Space) && IsGrounded) Jump();

        _Rigidbody.MovePosition(CalculateMovment());
    }

    private void OnDrawnGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * DistationToGround));
    }

}
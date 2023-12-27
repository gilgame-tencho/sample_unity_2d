using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float _moveSpeed;

    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;

    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
    }

    private void _Move()
    {
        _rigid.velocity = new Vector2(_inputDirection.x * _moveSpeed, _rigid.velocity.y);
    }

    public void _OnMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
    }
    public void _OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) return;

        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }
}

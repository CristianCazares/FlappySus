using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2DClass : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _jumpForce = 8;
    [SerializeField] float _heaviness = 2;

    bool _jump;
    bool _started;
    // Start is called before the first frame update
    void Start()
    {
        _rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jump = true;
            if (_started == false)
            {
                _animator.SetBool("isRunning", true);
                _started = true;
            }
        }

    }

    void FixedUpdate()
    {
        if (_jump == true) Jump();
    }

    void Jump()
    {
        _rb.gravityScale = 1;
        _rb.AddForce(-_rb.velocity, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _jump = false;
        _rb.gravityScale = _heaviness;
    }
}

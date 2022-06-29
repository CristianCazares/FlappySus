using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
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
            if(_started == false)
            {
                _animator.SetBool("isRunning", true);
                _started = true;
            }
        }

    }

    void FixedUpdate()
    {
        if (_jump == true) Jump();   
        RotationAnimDown();
    }

    void Jump()
    {
        RotationAnim();
        _rb.gravityScale = 1;
        _rb.AddForce(-_rb.velocity, ForceMode2D.Impulse);
        _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        _jump = false;
        _rb.gravityScale = _heaviness;
    }

    [SerializeField] Vector3 _rotationUp = new Vector3(0, 0, 60);
    [SerializeField] float _rotationUpSpeed = 1;
    void RotationAnim()
    {
        transform.rotation = Quaternion.Euler(
            new Vector3(
                transform.rotation.eulerAngles.x,
                transform.rotation.eulerAngles.y,
                _rotationUp.z
        ));
    }

    [SerializeField] string state = "";
    [SerializeField] float rotation = 0;
    void RotationAnimDown()
    {

        if (_rb.velocity.y <= 0)
        {
            rotation = transform.rotation.eulerAngles.z;
            if(
                !(transform.rotation.eulerAngles.z >= _rotationUp.z + 10 && transform.rotation.eulerAngles.z < 270)
                )
            {
                transform.Rotate(
                    new Vector3(
                        transform.rotation.eulerAngles.x,
                        transform.rotation.eulerAngles.y,
                        _rb.velocity.y
                ));
                state = "under";
            }
            else
            {
                state = "over";
            }
        }
    }
}

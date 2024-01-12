using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Transform _camera; 
    private float _horizontal;
    private float _vertical;

    //variables para velocidad, salto y gravedad
    [SerializeField] private float _playerSpeed = 5;
    [SerializeField] private float _jumpHeight = 1;
    private float _gravity = -9.81f;
    private Vector3 _playerGravity;

    //variables para rotacion
    private float turnSmoothVelocity;
    [SerializeField] float turnSmoothTime = 0.1f;

    //varibles para sensor
    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private float _sensorRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    private bool _isGrounded;

    Manager _manager;
    
    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camera = Camera.main.transform;

        _manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");

        if(Input.GetButton("Fire2"))
       {
        AimMovement();
       }
       else
       {
        Movement();
       }
    }

    void Movement()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);

        if(direction != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            _controller.Move(moveDirection.normalized * _playerSpeed * Time.deltaTime);
        }
    }

    void AimMovement()
    {
        Vector3 direction = new Vector3(_horizontal, 0, _vertical);

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
        float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _camera.eulerAngles.y, ref turnSmoothVelocity, turnSmoothTime);

        transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

        if(direction != Vector3.zero)
        {
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            _controller.Move(moveDirection.normalized * _playerSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            _manager.numberPoint = 1;
            _manager.SaveData();

        }
          if (other.gameObject.layer == 6)
        {
            _manager.numberPoint = 2;
            _manager.SaveData();

        }
          if (other.gameObject.layer == 7)
        {
            _manager.numberPoint = 3;
            _manager.SaveData();

        }
    }
}
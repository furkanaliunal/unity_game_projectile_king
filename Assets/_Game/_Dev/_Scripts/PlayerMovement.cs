using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private FloatingJoystick _joystick;
    private PlayerController _playerController; 
    

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _joystick = CanvasManager.Instance.joystick;
    }

    private void Update()
    {
        ApplyJoystick();
        ApplyKeyboard();
    }


    private void ApplyKeyboard()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        Move(new Vector3(horizontal, 0, vertical));
    }

    private void ApplyJoystick()
    {
        if (_joystick.Direction != Vector2.zero)
        {
            Move(new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y));
        }
    }

    private void Move(Vector3 movement)
    {
        transform.position += movement * (Time.deltaTime * _playerController.data.speed);
    }
}

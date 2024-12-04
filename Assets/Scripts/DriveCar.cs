using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DriveCar : MonoBehaviour
{
[SerializeField] private Rigidbody2D _frontTireRB;
[SerializeField] private Rigidbody2D _backTireRB;
//RB means rigidbody
[SerializeField] private Rigidbody2D _carRB;

[SerializeField] private float _speed = 150f;
[SerializeField] private float _rotationSpeed = 300f;
[SerializeField] private AudioSource hornSound;
private float _moveInput;

private void Update(){
    _moveInput = Input.GetAxisRaw("Horizontal");

    if(_moveInput == 0 && Input.touchCount > 0){
        Touch touch = Input.GetTouch(0);
        if(touch.position.x < Screen.width/2){
            _moveInput = -1;
        }
        else{
            _moveInput = 1;
        }

    }


    if(Input.GetKeyDown(KeyCode.H)){
        hornSound.Play();
    }
}

//فیکس اپدیت را ما انجام می دهیم و اپدیت را سیستم انجام می دهد.

private void FixedUpdate(){
    //گشتاور را اضافه می کنیم
    
    _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
    _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
    _carRB.AddTorque(-_moveInput * _rotationSpeed * Time.fixedDeltaTime);

}
}
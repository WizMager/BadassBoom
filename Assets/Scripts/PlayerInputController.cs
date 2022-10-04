using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
       [SerializeField] private Transform playerTransform;
       [SerializeField] private Camera playerCamera;
       [SerializeField] private float moveSpeed;
       [SerializeField] private float aimSensitive;
       private InputActions _input;
    

       private void Awake()
       {
              _input = new InputActions();
       }

       private void OnEnable()
       {
             _input.MouseAndKeyboard.Enable();
       }

       private void PlayerMove()
       {
           if (_input.MouseAndKeyboard.Move.phase != InputActionPhase.Started) return;
           var inputVector = _input.MouseAndKeyboard.Move.ReadValue<Vector2>();
           var moveVector = new Vector3(inputVector.x, 0f, inputVector.y);
           playerTransform.Translate( moveVector * moveSpeed * Time.deltaTime);
       }

       private void PlayerAimX()
       {
           if (_input.MouseAndKeyboard.MouseY.phase != InputActionPhase.Started) return;
           var inputAim = _input.MouseAndKeyboard.MouseY.ReadValue<float>();
           playerCamera.transform.Rotate(playerTransform.right * inputAim * aimSensitive);
       }
       
       private void PlayerAimY()
       {
           if (_input.MouseAndKeyboard.MouseX.phase != InputActionPhase.Started) return;
           var inputAim = _input.MouseAndKeyboard.MouseX.ReadValue<float>();
           playerTransform.Rotate(playerTransform.up * inputAim * aimSensitive);
       }
       
       private void Update()
       {
           PlayerMove();
           PlayerAimX();
           PlayerAimY();
       }

       private void OnDisable()
       {
           _input.MouseAndKeyboard.Disable();
       }
}
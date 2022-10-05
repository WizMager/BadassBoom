using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
       [SerializeField] private Transform playerTransform;
       [SerializeField] private Camera playerCamera;
       [SerializeField] private float moveSpeed;
       [SerializeField] private float sensitiveVertical;
       [SerializeField] private float sensitiveHorizontal;
       [SerializeField] private float rotateXClamp;
       private InputActions _input;
       private Vector2 _horizontalInput;
       private float _rotationX;
       private float _rotationY;


       private void Awake()
       {
              _input = new InputActions();
       }

       private void OnEnable()
       {
             _input.MouseAndKeyboard.Enable();
       }

       private void PlayerMove(float deltaTime)
       {
           if(_input.MouseAndKeyboard.Move.phase != InputActionPhase.Started) return;
           _horizontalInput = _input.MouseAndKeyboard.Move.ReadValue<Vector2>();
           var moveVector = (playerTransform.forward * _horizontalInput.y +
                             playerTransform.right * _horizontalInput.x) * moveSpeed;
           playerTransform.Translate(moveVector * deltaTime);
       }

       private void PlayerAimX()
       {
           if (_input.MouseAndKeyboard.MouseY.phase != InputActionPhase.Started) return;
           _rotationX -= _input.MouseAndKeyboard.MouseY.ReadValue<float>() * sensitiveVertical;
           _rotationX = Mathf.Clamp(_rotationX, -rotateXClamp, rotateXClamp);
           var playerRotation = playerTransform.eulerAngles;
           playerRotation.x = _rotationX;
           playerCamera.transform.eulerAngles = playerRotation;
       }
       
       private void PlayerAimY(float deltaTime)
       {
           if (_input.MouseAndKeyboard.MouseX.phase != InputActionPhase.Started) return;
           _rotationY = _input.MouseAndKeyboard.MouseX.ReadValue<float>() * sensitiveHorizontal;
           playerTransform.Rotate(playerTransform.up * _rotationY * deltaTime);
       }
       
       private void Update()
       {
           var deltaTime = Time.deltaTime;
           PlayerMove(deltaTime);
           PlayerAimX();
           PlayerAimY(deltaTime);
       }

       private void OnDisable()
       {
           _input.MouseAndKeyboard.Disable();
       }
}
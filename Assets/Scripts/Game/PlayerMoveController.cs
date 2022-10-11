using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Game
{
    public class PlayerMoveController : MonoBehaviour
    {
        [SerializeField] private PhotonTransformView photonTransformView;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float sensitiveVertical;
        [SerializeField] private float sensitiveHorizontal;
        [SerializeField] private float rotateXClamp;
        private PhotonView _photonView;
        private InputActions _input;
        private Vector2 _horizontalInput;
        private float _rotationX;
        private float _rotationY;

        [Inject]
        private void Construct(PhotonView photonView)
        {
            _photonView = photonView;
            _photonView.ObservedComponents.Add(photonTransformView);
        }
    
        private void Awake()
        {
            _input = new InputActions();
        }

        private void OnEnable()
        {
            _input.KeybordAndMouse.Enable();
        }

        private void PlayerMove(float deltaTime)
        {
            if (_input.KeybordAndMouse.Move.phase != InputActionPhase.Started) return;
            _horizontalInput = _input.KeybordAndMouse.Move.ReadValue<Vector2>();
            var moveVector = new Vector3(_horizontalInput.x, 0f, _horizontalInput.y);
            playerTransform.Translate(moveVector * moveSpeed * deltaTime);
        }

        private void PlayerAimX()
        {
            if (_input.KeybordAndMouse.MouseY.phase != InputActionPhase.Started) return;
            _rotationX -= _input.KeybordAndMouse.MouseY.ReadValue<float>() * sensitiveVertical;
            _rotationX = Mathf.Clamp(_rotationX, -rotateXClamp, rotateXClamp);
            var playerRotation = playerTransform.eulerAngles;
            playerRotation.x = _rotationX;
            cameraTransform.eulerAngles = playerRotation;
        }

        private void PlayerAimY(float deltaTime)
        {
            if (_input.KeybordAndMouse.MouseX.phase != InputActionPhase.Started) return;
            _rotationY = _input.KeybordAndMouse.MouseX.ReadValue<float>() * sensitiveHorizontal;
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
            _input.KeybordAndMouse.Disable();
        }
    }
}
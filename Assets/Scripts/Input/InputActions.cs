//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Scripts/Input/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""KeybordAndMouse"",
            ""id"": ""9a233a45-0375-4aba-93c5-0719cd574888"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8025fd40-284c-4d4f-b37d-0ec12a75082a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseX"",
                    ""type"": ""Value"",
                    ""id"": ""8c743625-de73-40cf-b641-e38e0f2ec02a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseY"",
                    ""type"": ""Value"",
                    ""id"": ""cc463715-a682-4549-a94d-9c074baa334b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""7e3a48c1-6118-4507-a663-31045ec37d4d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2f61980d-b061-4148-9e96-86cf3a98470f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f6e8a234-ae2f-47fb-aa3f-2581f8cd971e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""50cd3fbf-86d6-4dfd-bd39-583d5584698a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f70056e8-89ee-47df-8d34-c9b97923c6ea"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""12f09d77-9d05-4201-bd9c-77b48792d277"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11359422-8c62-4277-a83e-47a98a9d0c3a"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // KeybordAndMouse
        m_KeybordAndMouse = asset.FindActionMap("KeybordAndMouse", throwIfNotFound: true);
        m_KeybordAndMouse_Move = m_KeybordAndMouse.FindAction("Move", throwIfNotFound: true);
        m_KeybordAndMouse_MouseX = m_KeybordAndMouse.FindAction("MouseX", throwIfNotFound: true);
        m_KeybordAndMouse_MouseY = m_KeybordAndMouse.FindAction("MouseY", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // KeybordAndMouse
    private readonly InputActionMap m_KeybordAndMouse;
    private IKeybordAndMouseActions m_KeybordAndMouseActionsCallbackInterface;
    private readonly InputAction m_KeybordAndMouse_Move;
    private readonly InputAction m_KeybordAndMouse_MouseX;
    private readonly InputAction m_KeybordAndMouse_MouseY;
    public struct KeybordAndMouseActions
    {
        private @InputActions m_Wrapper;
        public KeybordAndMouseActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_KeybordAndMouse_Move;
        public InputAction @MouseX => m_Wrapper.m_KeybordAndMouse_MouseX;
        public InputAction @MouseY => m_Wrapper.m_KeybordAndMouse_MouseY;
        public InputActionMap Get() { return m_Wrapper.m_KeybordAndMouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeybordAndMouseActions set) { return set.Get(); }
        public void SetCallbacks(IKeybordAndMouseActions instance)
        {
            if (m_Wrapper.m_KeybordAndMouseActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMove;
                @MouseX.started -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_KeybordAndMouseActionsCallbackInterface.OnMouseY;
            }
            m_Wrapper.m_KeybordAndMouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
            }
        }
    }
    public KeybordAndMouseActions @KeybordAndMouse => new KeybordAndMouseActions(this);
    public interface IKeybordAndMouseActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
    }
}

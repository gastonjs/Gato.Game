// GENERATED AUTOMATICALLY FROM 'Assets/1-Codigos/Control.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Control : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Control()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Control"",
    ""maps"": [
        {
            ""name"": ""ControlMovimiento"",
            ""id"": ""0fbd4a1f-a9fb-4130-b76b-dd95851ac10e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f3cc22a0-049a-4592-8215-86295726e248"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""27e43016-7646-4491-9cf4-dba236e62eb8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""8e97a24f-824f-4fa3-b5f6-d910eb7344e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pelota"",
                    ""type"": ""Button"",
                    ""id"": ""0b89c46f-e177-49ed-ae8e-545091a06b08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Libro"",
                    ""type"": ""Button"",
                    ""id"": ""98c948ac-eac5-4930-84cc-3bd34a9e7b73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rugir"",
                    ""type"": ""Button"",
                    ""id"": ""25bc234e-78f9-471c-896b-bdbbc651d79a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2a8ea0fc-42b1-4fc9-b160-6e8b20b5d9eb"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""6cf1688d-4751-4311-a931-19f4ad82b7fc"",
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
                    ""id"": ""f1daa2e3-3331-4256-a546-0bce47c7c9f5"",
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
                    ""id"": ""624ce380-0436-42a3-81b5-0659231b66bd"",
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
                    ""id"": ""646bda65-a363-443d-bdab-d845b24f85a4"",
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
                    ""id"": ""e09eb3dd-33b0-4caf-922a-9b55b4181ccc"",
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
                    ""id"": ""a11733bf-f4a9-45dc-9572-a0892b9f4f73"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""573d138f-6c29-4035-b375-005276bcd448"",
                    ""path"": ""<Keyboard>/numpad5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbbe1ac8-9b4b-4ad8-a326-9ef524d88d79"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fd087a1d-b55a-40ba-992c-ff0a3fb5fc55"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9ab32afa-5a37-4d91-8448-fe750b69c339"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3cd2fb22-e4ab-4b25-9e86-ae5bc763fbed"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fca591a9-0394-410d-bec9-33a68bbb67a4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""05fc9235-117b-4307-95c7-b5b198d75434"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""328eda14-5551-493c-a74b-9e26a6e3238b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pelota"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96b9ec52-c527-4487-b1b7-dd75394f0bad"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pelota"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8798c35-d7e7-44f5-b9e4-51a1acd1959b"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Libro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f69b7ae-39b8-40e6-8686-f6652875c836"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Libro"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b0a06c3-24b0-4206-9d0c-7b4844a47d19"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rugir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67f56fd1-3be9-4165-9e9d-a3e86104b392"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rugir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ControlMovimiento
        m_ControlMovimiento = asset.FindActionMap("ControlMovimiento", throwIfNotFound: true);
        m_ControlMovimiento_Move = m_ControlMovimiento.FindAction("Move", throwIfNotFound: true);
        m_ControlMovimiento_Jump = m_ControlMovimiento.FindAction("Jump", throwIfNotFound: true);
        m_ControlMovimiento_Look = m_ControlMovimiento.FindAction("Look", throwIfNotFound: true);
        m_ControlMovimiento_Pelota = m_ControlMovimiento.FindAction("Pelota", throwIfNotFound: true);
        m_ControlMovimiento_Libro = m_ControlMovimiento.FindAction("Libro", throwIfNotFound: true);
        m_ControlMovimiento_Rugir = m_ControlMovimiento.FindAction("Rugir", throwIfNotFound: true);
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

    // ControlMovimiento
    private readonly InputActionMap m_ControlMovimiento;
    private IControlMovimientoActions m_ControlMovimientoActionsCallbackInterface;
    private readonly InputAction m_ControlMovimiento_Move;
    private readonly InputAction m_ControlMovimiento_Jump;
    private readonly InputAction m_ControlMovimiento_Look;
    private readonly InputAction m_ControlMovimiento_Pelota;
    private readonly InputAction m_ControlMovimiento_Libro;
    private readonly InputAction m_ControlMovimiento_Rugir;
    public struct ControlMovimientoActions
    {
        private @Control m_Wrapper;
        public ControlMovimientoActions(@Control wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_ControlMovimiento_Move;
        public InputAction @Jump => m_Wrapper.m_ControlMovimiento_Jump;
        public InputAction @Look => m_Wrapper.m_ControlMovimiento_Look;
        public InputAction @Pelota => m_Wrapper.m_ControlMovimiento_Pelota;
        public InputAction @Libro => m_Wrapper.m_ControlMovimiento_Libro;
        public InputAction @Rugir => m_Wrapper.m_ControlMovimiento_Rugir;
        public InputActionMap Get() { return m_Wrapper.m_ControlMovimiento; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlMovimientoActions set) { return set.Get(); }
        public void SetCallbacks(IControlMovimientoActions instance)
        {
            if (m_Wrapper.m_ControlMovimientoActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnJump;
                @Look.started -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnLook;
                @Pelota.started -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnPelota;
                @Pelota.performed -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnPelota;
                @Pelota.canceled -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnPelota;
                @Libro.started -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnLibro;
                @Libro.performed -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnLibro;
                @Libro.canceled -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnLibro;
                @Rugir.started -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnRugir;
                @Rugir.performed -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnRugir;
                @Rugir.canceled -= m_Wrapper.m_ControlMovimientoActionsCallbackInterface.OnRugir;
            }
            m_Wrapper.m_ControlMovimientoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Pelota.started += instance.OnPelota;
                @Pelota.performed += instance.OnPelota;
                @Pelota.canceled += instance.OnPelota;
                @Libro.started += instance.OnLibro;
                @Libro.performed += instance.OnLibro;
                @Libro.canceled += instance.OnLibro;
                @Rugir.started += instance.OnRugir;
                @Rugir.performed += instance.OnRugir;
                @Rugir.canceled += instance.OnRugir;
            }
        }
    }
    public ControlMovimientoActions @ControlMovimiento => new ControlMovimientoActions(this);
    public interface IControlMovimientoActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnPelota(InputAction.CallbackContext context);
        void OnLibro(InputAction.CallbackContext context);
        void OnRugir(InputAction.CallbackContext context);
    }
}

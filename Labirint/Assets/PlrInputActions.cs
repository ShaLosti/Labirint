// GENERATED AUTOMATICALLY FROM 'Assets/PlrInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlrInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlrInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlrInputActions"",
    ""maps"": [
        {
            ""name"": ""Plr"",
            ""id"": ""66735467-f1d0-4f92-ac51-3ed54e4c0b63"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c37ef9ab-2e93-48f9-82c9-5c3cd8454f18"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MouseAim"",
                    ""type"": ""Value"",
                    ""id"": ""1bdc6de3-b6dd-4ca4-bd0f-a0e694083cd7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu"",
                    ""type"": ""Button"",
                    ""id"": ""713fd129-2410-41fd-a4f0-f68f85243fbc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e53c18e1-7a4c-4f80-86e3-65c3286d935f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c482094b-b36c-4349-b44b-6757abdbe7f4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a8901d67-114e-46b9-a0c1-07ff3f1b1629"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1369a7a3-2319-4337-b43c-3829bd0a3fcc"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d0e3792a-25b6-4e95-aeae-8f91773b4eda"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""7e5cd6ab-366c-4ff9-a0e4-572bdc6ec6d6"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""4e3cc5ec-b125-4e62-9308-2ef32b55c24c"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9ff0f409-905e-4e58-9d78-d2d018167610"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4acca8b2-276b-487e-809c-0a1de503358a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cbed71fd-155d-4a42-b86f-6f112c5ac410"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""54bade0b-5923-4f70-8e41-5b77eca03cdf"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50954eed-047f-4c6d-8841-69984215d1c3"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Plr
        m_Plr = asset.FindActionMap("Plr", throwIfNotFound: true);
        m_Plr_Movement = m_Plr.FindAction("Movement", throwIfNotFound: true);
        m_Plr_MouseAim = m_Plr.FindAction("MouseAim", throwIfNotFound: true);
        m_Plr_Menu = m_Plr.FindAction("Menu", throwIfNotFound: true);
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

    // Plr
    private readonly InputActionMap m_Plr;
    private IPlrActions m_PlrActionsCallbackInterface;
    private readonly InputAction m_Plr_Movement;
    private readonly InputAction m_Plr_MouseAim;
    private readonly InputAction m_Plr_Menu;
    public struct PlrActions
    {
        private @PlrInputActions m_Wrapper;
        public PlrActions(@PlrInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Plr_Movement;
        public InputAction @MouseAim => m_Wrapper.m_Plr_MouseAim;
        public InputAction @Menu => m_Wrapper.m_Plr_Menu;
        public InputActionMap Get() { return m_Wrapper.m_Plr; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlrActions set) { return set.Get(); }
        public void SetCallbacks(IPlrActions instance)
        {
            if (m_Wrapper.m_PlrActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlrActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlrActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlrActionsCallbackInterface.OnMovement;
                @MouseAim.started -= m_Wrapper.m_PlrActionsCallbackInterface.OnMouseAim;
                @MouseAim.performed -= m_Wrapper.m_PlrActionsCallbackInterface.OnMouseAim;
                @MouseAim.canceled -= m_Wrapper.m_PlrActionsCallbackInterface.OnMouseAim;
                @Menu.started -= m_Wrapper.m_PlrActionsCallbackInterface.OnMenu;
                @Menu.performed -= m_Wrapper.m_PlrActionsCallbackInterface.OnMenu;
                @Menu.canceled -= m_Wrapper.m_PlrActionsCallbackInterface.OnMenu;
            }
            m_Wrapper.m_PlrActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @MouseAim.started += instance.OnMouseAim;
                @MouseAim.performed += instance.OnMouseAim;
                @MouseAim.canceled += instance.OnMouseAim;
                @Menu.started += instance.OnMenu;
                @Menu.performed += instance.OnMenu;
                @Menu.canceled += instance.OnMenu;
            }
        }
    }
    public PlrActions @Plr => new PlrActions(this);
    public interface IPlrActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMouseAim(InputAction.CallbackContext context);
        void OnMenu(InputAction.CallbackContext context);
    }
}

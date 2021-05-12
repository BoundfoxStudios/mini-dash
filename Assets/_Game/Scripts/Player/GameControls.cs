// GENERATED AUTOMATICALLY FROM 'Assets/_Game/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace BoundfoxStudios.MiniDash.Player
{
    public class @GameControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @GameControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Player Ground"",
            ""id"": ""0909479f-0bb6-4ad0-8076-e6d0799e2b17"",
            ""actions"": [
                {
                    ""name"": ""Left/Right"",
                    ""type"": ""Value"",
                    ""id"": ""8972e8e9-fdb0-4286-b795-20e3b6d3d7a8"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump/Dash"",
                    ""type"": ""Button"",
                    ""id"": ""bbca1f8e-24bc-4b16-aa61-ef8c01f4619e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""AD"",
                    ""id"": ""1ded8abb-81f3-4db3-a13b-642cc4cfc49c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left/Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""14a70c10-607c-46f8-b60e-f2b2f5c44431"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left/Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a9f8b41a-2f83-40f0-8548-ac53514828f3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left/Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Left/Right"",
                    ""id"": ""4ef3c3ce-ca66-41a3-a172-611801010a98"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left/Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d8dcb813-1a44-4c51-bad7-034305154818"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left/Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4cff1790-9604-4110-99d3-a6819788d6ea"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Left/Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4ee9fb4d-31a7-4522-8708-609597a29e5e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump/Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae2f32a9-5fac-40e1-a76b-d7da7e346127"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump/Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Player Ground
            m_PlayerGround = asset.FindActionMap("Player Ground", throwIfNotFound: true);
            m_PlayerGround_LeftRight = m_PlayerGround.FindAction("Left/Right", throwIfNotFound: true);
            m_PlayerGround_JumpDash = m_PlayerGround.FindAction("Jump/Dash", throwIfNotFound: true);
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

        // Player Ground
        private readonly InputActionMap m_PlayerGround;
        private IPlayerGroundActions m_PlayerGroundActionsCallbackInterface;
        private readonly InputAction m_PlayerGround_LeftRight;
        private readonly InputAction m_PlayerGround_JumpDash;
        public struct PlayerGroundActions
        {
            private @GameControls m_Wrapper;
            public PlayerGroundActions(@GameControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @LeftRight => m_Wrapper.m_PlayerGround_LeftRight;
            public InputAction @JumpDash => m_Wrapper.m_PlayerGround_JumpDash;
            public InputActionMap Get() { return m_Wrapper.m_PlayerGround; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerGroundActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerGroundActions instance)
            {
                if (m_Wrapper.m_PlayerGroundActionsCallbackInterface != null)
                {
                    @LeftRight.started -= m_Wrapper.m_PlayerGroundActionsCallbackInterface.OnLeftRight;
                    @LeftRight.performed -= m_Wrapper.m_PlayerGroundActionsCallbackInterface.OnLeftRight;
                    @LeftRight.canceled -= m_Wrapper.m_PlayerGroundActionsCallbackInterface.OnLeftRight;
                    @JumpDash.started -= m_Wrapper.m_PlayerGroundActionsCallbackInterface.OnJumpDash;
                    @JumpDash.performed -= m_Wrapper.m_PlayerGroundActionsCallbackInterface.OnJumpDash;
                    @JumpDash.canceled -= m_Wrapper.m_PlayerGroundActionsCallbackInterface.OnJumpDash;
                }
                m_Wrapper.m_PlayerGroundActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @LeftRight.started += instance.OnLeftRight;
                    @LeftRight.performed += instance.OnLeftRight;
                    @LeftRight.canceled += instance.OnLeftRight;
                    @JumpDash.started += instance.OnJumpDash;
                    @JumpDash.performed += instance.OnJumpDash;
                    @JumpDash.canceled += instance.OnJumpDash;
                }
            }
        }
        public PlayerGroundActions @PlayerGround => new PlayerGroundActions(this);
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IPlayerGroundActions
        {
            void OnLeftRight(InputAction.CallbackContext context);
            void OnJumpDash(InputAction.CallbackContext context);
        }
    }
}

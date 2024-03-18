//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/InputSystem/Pause/Pause.inputactions
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

public partial class @Pause : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Pause()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Pause"",
    ""maps"": [
        {
            ""name"": ""appearPause"",
            ""id"": ""74890abf-ce63-463a-9efc-1cc44b4fd35e"",
            ""actions"": [
                {
                    ""name"": ""pausePanel"",
                    ""type"": ""Button"",
                    ""id"": ""d502ec3e-727a-4ec7-a16a-3d09a74f6da0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ba093dd5-fe08-4658-b6c6-7c3008ff3d30"",
                    ""path"": ""<OculusTouchController>/menu"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pausePanel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // appearPause
        m_appearPause = asset.FindActionMap("appearPause", throwIfNotFound: true);
        m_appearPause_pausePanel = m_appearPause.FindAction("pausePanel", throwIfNotFound: true);
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

    // appearPause
    private readonly InputActionMap m_appearPause;
    private IAppearPauseActions m_AppearPauseActionsCallbackInterface;
    private readonly InputAction m_appearPause_pausePanel;
    public struct AppearPauseActions
    {
        private @Pause m_Wrapper;
        public AppearPauseActions(@Pause wrapper) { m_Wrapper = wrapper; }
        public InputAction @pausePanel => m_Wrapper.m_appearPause_pausePanel;
        public InputActionMap Get() { return m_Wrapper.m_appearPause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AppearPauseActions set) { return set.Get(); }
        public void SetCallbacks(IAppearPauseActions instance)
        {
            if (m_Wrapper.m_AppearPauseActionsCallbackInterface != null)
            {
                @pausePanel.started -= m_Wrapper.m_AppearPauseActionsCallbackInterface.OnPausePanel;
                @pausePanel.performed -= m_Wrapper.m_AppearPauseActionsCallbackInterface.OnPausePanel;
                @pausePanel.canceled -= m_Wrapper.m_AppearPauseActionsCallbackInterface.OnPausePanel;
            }
            m_Wrapper.m_AppearPauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @pausePanel.started += instance.OnPausePanel;
                @pausePanel.performed += instance.OnPausePanel;
                @pausePanel.canceled += instance.OnPausePanel;
            }
        }
    }
    public AppearPauseActions @appearPause => new AppearPauseActions(this);
    public interface IAppearPauseActions
    {
        void OnPausePanel(InputAction.CallbackContext context);
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;


namespace EasyShortcuts
{
    [Serializable]
    public class InputActionShortcut
    {
        public bool Enabled = true;
        public InputActionProperty Input;
        public Action<InputAction.CallbackContext> UserAction;

        public InputActionShortcut(Action<InputAction.CallbackContext> act) { UserAction = act; }

        public InputActionShortcut() { }

        public void Enable() => Input.action.performed += UserAction;

        public void Disable() => Input.action.performed -= UserAction;
    }

    [Serializable]
    public class InputActionShortcut<T0> : InputActionShortcut
    {
        public new Action<InputAction.CallbackContext, T0> UserAction;

        [HideInInspector] public string[] ArgumentNames = new string[1] { "Argument 0" };
        public T0 Data0;

        public InputActionShortcut(Action<InputAction.CallbackContext, T0> act) => UserAction = act;
    }

    [Serializable]
    public class InputActionShortcut<T0, T1> : InputActionShortcut
    {
        public new Action<InputAction.CallbackContext, T0, T1> UserAction;

        [HideInInspector] public string[] ArgumentNames = new string[2] { "Argument 0", "Argument 1" };
        public T0 Data0;
        public T1 Data1;

        public InputActionShortcut(Action<InputAction.CallbackContext, T0, T1> act) => UserAction = act;
    }

    [Serializable]
    public class InputActionShortcut<T0, T1, T2> : InputActionShortcut
    {
        public new Action<InputAction.CallbackContext, T0, T1, T2> UserAction;

        [HideInInspector] public string[] ArgumentNames = new string[3] { "Argument 0", "Argument 1", "Argument 2" };
        public T0 Data0;
        public T1 Data1;
        public T2 Data2;

        public InputActionShortcut(Action<InputAction.CallbackContext, T0, T1, T2> act) => UserAction = act;
    }

    [Serializable]
    public class InputActionShortcut<T0, T1, T2, T3> : InputActionShortcut
    {
        public new Action<InputAction.CallbackContext, T0, T1, T2, T3> UserAction;

        [HideInInspector] public string[] ArgumentNames = new string[4] { "Argument 0", "Argument 1", "Argument 2", "Argument 3" };
        public T0 Data0;
        public T1 Data1;
        public T2 Data2;
        public T3 Data3;

        public InputActionShortcut(Action<InputAction.CallbackContext, T0, T1, T2, T3> act) => UserAction = act;
    }
}



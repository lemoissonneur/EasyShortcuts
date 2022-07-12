using System;
using UnityEngine;
using UnityEngine.InputSystem;

using Context = UnityEngine.InputSystem.InputAction.CallbackContext;


namespace EasyShortcuts
{
    [Serializable]
    public class InputActionShortcut
    {
        [SerializeField] protected InputActionProperty m_Input;
        [SerializeField] protected InputActionPhase m_Phase;

        public InputActionShortcut(Action<Context> act)
            => SetListener(act);

        public InputActionShortcut(Action act)
            => SetListener((Context c) => { act(); });

        public InputActionShortcut() { }

        public void Enable() => m_Input.action.Enable();

        public void Disable() => m_Input.action.Disable();

        protected void SetListener(Action<Context> act)
        {
            switch (m_Phase)
            {
                case InputActionPhase.Started:
                    m_Input.action.started += act;
                    break;
                case InputActionPhase.Performed:
                    m_Input.action.performed += act;
                    break;
                case InputActionPhase.Canceled:
                    m_Input.action.canceled += act;
                    break;
            }
        }
    }

    [Serializable]
    public class InputActionShortcut<T1> : InputActionShortcut
    {
        public string[] ArgumentNames = new string[1] { "Argument 1" };
        public T1 Data1;

        public InputActionShortcut(Action<T1, Context> act)
            => SetListener((Context c) => { act(Data1, c); });

        public InputActionShortcut(Action<T1> act)
            => SetListener((Context c) => { act(Data1); });
    }

    [Serializable]
    public class InputActionShortcut<T1, T2> : InputActionShortcut
    {
        public string[] ArgumentNames = new string[2] { "Argument 1", "Argument 2" };
        public T1 Data1;
        public T2 Data2;

        public InputActionShortcut(Action<T1, T2, Context> act)
            => SetListener((Context c) => { act(Data1, Data2, c); });

        public InputActionShortcut(Action<T1, T2> act)
            => SetListener((Context c) => { act(Data1, Data2); });
    }

    [Serializable]
    public class InputActionShortcut<T1, T2, T3> : InputActionShortcut
    {
        public string[] ArgumentNames = new string[3] { "Argument 1", "Argument 2", "Argument 3" };
        public T1 Data1;
        public T2 Data2;
        public T3 Data3;

        public InputActionShortcut(Action<T1, T2, T3, Context> act)
            => SetListener((Context c) => { act(Data1, Data2, Data3, c); });

        public InputActionShortcut(Action<T1, T2, T3> act)
            => SetListener((Context c) => { act(Data1, Data2, Data3); });
    }

    [Serializable]
    public class InputActionShortcut<T1, T2, T3, T4> : InputActionShortcut
    {
        public string[] ArgumentNames = new string[4] { "Argument 1", "Argument 2", "Argument 3", "Argument 4" };
        public T1 Data1;
        public T2 Data2;
        public T3 Data3;
        public T4 Data4;

        public InputActionShortcut(Action<T1, T2, T3, T4, Context> act)
            => SetListener((Context c) => { act(Data1, Data2, Data3, Data4, c); });

        public InputActionShortcut(Action<T1, T2, T3, T4> act)
            => SetListener((Context c) => { act(Data1, Data2, Data3, Data4); });
    }
}



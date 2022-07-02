using System.Reflection;
using System.Collections.Generic;
using UnityEngine;


namespace EasyShortcuts
{
    public abstract class InputActionShortcutSet : MonoBehaviour
    {
        private HashSet<InputActionShortcut> _shortcuts = new HashSet<InputActionShortcut>();

        private void Awake()
        {
            FieldInfo[] fields = GetType().GetFields();

            foreach (FieldInfo f in fields)
            {
                if (f.FieldType == typeof(InputActionShortcut) || f.FieldType.IsSubclassOf(typeof(InputActionShortcut)))
                    _shortcuts.Add(f.GetValue(this) as InputActionShortcut);
            }
        }

        private void OnEnable()
        {
            foreach (InputActionShortcut shortcut in _shortcuts)
                if (shortcut.Enabled) shortcut.Enable();
        }

        private void OnDisable()
        {
            foreach (InputActionShortcut shortcut in _shortcuts)
                shortcut.Disable();
        }

        private void OnValidate()
        {
            OnDisable();
            OnEnable();
        }
    }
}
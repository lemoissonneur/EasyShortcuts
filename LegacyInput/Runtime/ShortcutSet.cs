using UnityEngine;
using System.Reflection;
using System.Collections.Generic;


namespace EasyShortcuts
{
    public abstract class ShortcutSet : MonoBehaviour
    {
        private HashSet<Shortcut> _shortcuts = new HashSet<Shortcut>();

        private void Awake()
        {
            FieldInfo[] fields = GetType().GetFields();

            foreach(FieldInfo f in fields)
            {
                if (f.FieldType == typeof(Shortcut) || f.FieldType.IsSubclassOf(typeof(Shortcut)))
                    _shortcuts.Add(f.GetValue(this) as Shortcut);
            }
        }

        private void Update()
        {
            foreach (Shortcut shortcut in _shortcuts)
                shortcut.Check();
        }
    }
}




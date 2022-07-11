using System;
using UnityEngine;


namespace EasyShortcuts
{
    [Serializable]
    public class Shortcut
    {
        public enum KeyType { SINGLEKEY = 0, DUALKEY = 1 }

        public bool Enabled = true;
        public KeyType KeyMode = KeyType.SINGLEKEY;
        public KeyCode HoldKey = KeyCode.None;
        public KeyCode DownKey = KeyCode.None;
        public Action ShortcutAction = () => { };

        public bool Triggered => Enabled && Input.GetKeyDown(DownKey) && ( KeyMode == KeyType.SINGLEKEY || Input.GetKey(HoldKey));

        public Shortcut(Action act) => ShortcutAction = act;

        public Shortcut() { }

        public void ActIfTriggered() { if (Triggered) ShortcutAction();  }
    }

    [Serializable]
    public class Shortcut<T1> : Shortcut
    {
        public string[] ArgumentNames = new string[1] { "Argument 1" };
        public T1 Data1;

        public Shortcut(Action<T1> act) => ShortcutAction = () => { act(Data1); };
    }

    [Serializable]
    public class Shortcut<T1, T2> : Shortcut
    {
        public string[] ArgumentNames = new string[2] { "Argument 1", "Argument 2" };
        public T1 Data1;
        public T2 Data2;

        public Shortcut(Action<T1, T2> act) => ShortcutAction = () => { act(Data1, Data2); };
}

    [Serializable]
    public class Shortcut<T1, T2, T3> : Shortcut
    {
        public string[] ArgumentNames = new string[3] { "Argument 1", "Argument 2", "Argument 3" };
        public T1 Data1;
        public T2 Data2;
        public T3 Data3;

        public Shortcut(Action<T1, T2, T3> act) => ShortcutAction = () => { act(Data1, Data2, Data3); };
    }

    [Serializable]
    public class Shortcut<T1, T2, T3, T4> : Shortcut
    {
        public string[] ArgumentNames = new string[4] { "Argument 1", "Argument 2", "Argument 3", "Argument 4" };
        public T1 Data1;
        public T2 Data2;
        public T3 Data3;
        public T4 Data4;

        public Shortcut(Action<T1, T2, T3, T4> act) => ShortcutAction = () => { act(Data1, Data2, Data3, Data4); };
    }
}

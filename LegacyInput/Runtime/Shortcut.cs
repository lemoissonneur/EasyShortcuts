using System;
using UnityEngine;


namespace CobayeStudio.Shortcuts
{
    [Serializable]
    public class Shortcut
    {
        public enum KeyType { SINGLEKEY = 0, DUALKEY = 1 }
        public delegate void Function();
        public delegate void Trigger();

        public bool Enabled = true;
        public KeyType KeyMode = KeyType.SINGLEKEY;
        public KeyCode HoldKey = KeyCode.None;
        public KeyCode DownKey = KeyCode.None;
        public Trigger CallFunction;

        public bool Triggered => Enabled && Input.GetKeyDown(DownKey) && ( KeyMode == KeyType.SINGLEKEY || Input.GetKey(HoldKey));

        public Shortcut(Function act) => CallFunction = delegate () { act(); };

        public Shortcut() { }

        public void Check() { if (Triggered) CallFunction();  }
    }

    [Serializable]
    public class Shortcut<T0> : Shortcut
    {
        public new delegate void Function(T0 input);

        public string[] ArgumentNames = new string[1] { "Argument 0" };
        public T0 Data0;

        public Shortcut(Function act) => CallFunction = delegate () { act(Data0); };
    }

    [Serializable]
    public class Shortcut<T0, T1> : Shortcut
    {
        public new delegate void Function(T0 input0, T1 input1);

        public string[] ArgumentNames = new string[2] { "Argument 0", "Argument 1 " };
        public T0 Data0;
        public T1 Data1;

        public Shortcut(Function act) => CallFunction = delegate () { act(Data0, Data1); };
}

    [Serializable]
    public class Shortcut<T0, T1, T2> : Shortcut
    {
        public new delegate void Function(T0 input0, T1 input1, T2 input2);

        public string[] ArgumentNames = new string[3] { "Argument 0", "Argument 1", "Argument 2" };
        public T0 Data0;
        public T1 Data1;
        public T2 Data2;

        public Shortcut(Function act) => CallFunction = delegate () { act(Data0, Data1, Data2); };
    }

    [Serializable]
    public class Shortcut<T0, T1, T2, T3> : Shortcut
    {
        public new delegate void Function(T0 input0, T1 input1, T2 input2, T3 input3);

        public string[] ArgumentNames = new string[4] { "Argument 0", "Argument 1", "Argument 2", "Argument 3" };
        public T0 Data0;
        public T1 Data1;
        public T2 Data2;
        public T3 Data3;

        public Shortcut(Function act) => CallFunction = delegate () { act(Data0, Data1, Data2, Data3); };
    }
}

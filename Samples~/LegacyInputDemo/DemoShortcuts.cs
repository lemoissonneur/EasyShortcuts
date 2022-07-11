using UnityEngine;


namespace EasyShortcuts.Samples
{
    public class DemoShortcuts : ShortcutSet
    {
        [Header("Create shortcut with up to 4 parameters")]
        public Shortcut VoidShortcut =
            new Shortcut(
                () =>
                {
                    Debug.Log("shortcut !");
                });

        public Shortcut<Vector3> Input1Shortcut =
            new Shortcut<Vector3>(
                (Vector3 data) =>
                {
                    Debug.Log(data);
                });

        public Shortcut<Object, Vector3> Input2Shortcut =
            new Shortcut<Object, Vector3>(
                (Object data0, Vector3 data1) =>
                {
                    Debug.Log(data0.name);
                    Debug.Log(data1);
                });

        public Shortcut<Object, MonoBehaviour, ScriptableObject> Input3Shortcut =
            new Shortcut<Object, MonoBehaviour, ScriptableObject>(
                (Object data0, MonoBehaviour data1, ScriptableObject data2) =>
                {
                    Debug.Log(data0.name);
                    Debug.Log(data1.name);
                    Debug.Log(data2.name);
                });

        public Shortcut<Object, MonoBehaviour, ScriptableObject, Transform> Input4Shortcut =
            new Shortcut<Object, MonoBehaviour, ScriptableObject, Transform>(
                (Object data0, MonoBehaviour data1, ScriptableObject data2, Transform data3) =>
                {
                    Debug.Log(data0.name);
                    Debug.Log(data1.name);
                    Debug.Log(data2.name);
                    Debug.Log(data3.name);
                });



        [Header("You can also renames the parameters")]
        public Shortcut<Camera, int> FOVdown =
            new Shortcut<Camera, int>(
                (Camera foo, int bar) =>
                {
                    Debug.Log("new TimeScale = " + Time.timeScale);
                })
            { ArgumentNames = new string[] { "foo", "bar" } };



        // Re-use the same code for multiple shortcut with methods
        public Shortcut<Transform, Vector3> ShortcutA =
            new Shortcut<Transform, Vector3>(
                (Transform foo, Vector3 bar) =>
                {
                    Method(foo, bar);
                })
            { ArgumentNames = new string[] { "foo", "bar" } };

        public Shortcut<Transform, Vector3> ShortcutB =
            new Shortcut<Transform, Vector3>(Method)
            { ArgumentNames = new string[] { "foo", "bar" } };

        public static void Method(Transform foo, Vector3 bar)
        {
            // do stuff
        }
    }
}

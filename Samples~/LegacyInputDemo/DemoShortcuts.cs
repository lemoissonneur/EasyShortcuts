using UnityEngine;


namespace EasyShortcuts.Samples
{
    public class DemoShortcuts : ShortcutSet
    {
        public Shortcut VoidShortcut =
            new Shortcut(
                delegate ()
                {
                    Debug.Log("shortcut !");
                });

        public Shortcut<Vector3> Input1Shortcut =
            new Shortcut<Vector3>(
                delegate (Vector3 data)
                {
                    Debug.Log(data);
                });

        public Shortcut<Object, Vector3> Input2Shortcut =
            new Shortcut<Object, Vector3>(
                delegate (Object data0, Vector3 data1)
                {
                    Debug.Log(data0.name);
                    Debug.Log(data1);
                });

        public Shortcut<Object, MonoBehaviour, ScriptableObject> Input3Shortcut =
            new Shortcut<Object, MonoBehaviour, ScriptableObject>(
                delegate (Object data0, MonoBehaviour data1, ScriptableObject data2)
                {
                    Debug.Log(data0.name);
                    Debug.Log(data1.name);
                    Debug.Log(data2.name);
                });

        public Shortcut<Object, MonoBehaviour, ScriptableObject, Transform> Input4Shortcut =
            new Shortcut<Object, MonoBehaviour, ScriptableObject, Transform>(
                delegate (Object data0, MonoBehaviour data1, ScriptableObject data2, Transform data3)
                {
                    Debug.Log(data0.name);
                    Debug.Log(data1.name);
                    Debug.Log(data2.name);
                    Debug.Log(data3.name);
                });

        [Header("Examples :")]
        public Shortcut<Camera, int> FOVup =
            new Shortcut<Camera, int>(
                delegate (Camera data, int value)
                {
                    data.fieldOfView = value;
                    Debug.Log("new TimeScale = " + Time.timeScale);
                });

        public Shortcut<Camera, int> FOVdown =
            new Shortcut<Camera, int>(
                delegate (Camera data, int value)
                {
                    data.fieldOfView = value;
                    Debug.Log("new TimeScale = " + Time.timeScale);
                })
            { ArgumentNames = new string[] { "Camera", "truc" } };
    }
}

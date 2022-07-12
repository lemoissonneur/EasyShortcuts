using UnityEngine;
using UnityEngine.InputSystem;


namespace EasyShortcuts.Samples
{
    public class DemoActionShortcuts : InputActionShortcutSet
    {
        public InputActionShortcut voidShortcut = new InputActionShortcut(
            delegate (InputAction.CallbackContext context)
            {
                Debug.Log("Void");
            });

        [Space]
        public InputActionShortcut<Camera> T1Shortcut = new InputActionShortcut<Camera>(
            delegate (Camera cam, InputAction.CallbackContext context)
            {
                Debug.Log("cam");
            });

        [Space]
        public InputActionShortcut<Camera> OtherT1Test = new InputActionShortcut<Camera>(T1Test);
        public static void T1Test(Camera cam, InputAction.CallbackContext context)
        {
            Debug.Log("Meth");
        }

        [Space]
        public InputActionShortcut<Object, Object, Object, Object> T4Test =
            new InputActionShortcut<Object, Object, Object, Object>(
                delegate (Object a, Object b, Object c, Object d)
                {
                Debug.Log($"{a}, {b}, {c}, {d}");
                }
            );


    }
}
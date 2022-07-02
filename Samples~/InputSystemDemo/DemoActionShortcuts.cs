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

        public InputActionShortcut<Camera> T0Shortcut = new InputActionShortcut<Camera>(
            delegate (InputAction.CallbackContext context, Camera cam)
            {
                Debug.Log("cam");
            });

        public InputActionShortcut<Camera> OtherT0Test = new InputActionShortcut<Camera>(T0Test);
        public static void T0Test(InputAction.CallbackContext context, Camera cam)
        {
            Debug.Log("Meth");
        }
    }
}
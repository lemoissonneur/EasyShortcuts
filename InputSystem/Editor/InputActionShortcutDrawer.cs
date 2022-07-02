using UnityEditor;
using UnityEngine;

namespace Shortcuts.Editor
{
    //[CustomPropertyDrawer(typeof(InputActionShortcut), true)]
    public class InputActionShortcutDrawer : PropertyDrawer
    {
        //public override float GetPropertyHeight(SerializedProperty property, GUIContent label) { return base.GetPropertyHeight(property, label); }// - EditorGUIUtility.singleLineHeight; }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty _enabledProperty = property.FindPropertyRelative(nameof(InputActionShortcut.Enabled));
            SerializedProperty _inputProperty = property.FindPropertyRelative(nameof(InputActionShortcut.Input));
            SerializedProperty _data0Property = property.FindPropertyRelative(nameof(InputActionShortcut<object>.Data0));
            SerializedProperty _data1Property = property.FindPropertyRelative(nameof(InputActionShortcut<object, object>.Data1));
            SerializedProperty _data2Property = property.FindPropertyRelative(nameof(InputActionShortcut<object, object, object>.Data2));
            SerializedProperty _data3Property = property.FindPropertyRelative(nameof(InputActionShortcut<object, object, object, object>.Data3));
            SerializedProperty _argumentsNamesProperty = property.FindPropertyRelative(nameof(InputActionShortcut<object>.ArgumentNames));

            Debug.Log(property.name + "   " + position);

            _enabledProperty.boolValue = EditorGUILayout.ToggleLeft(label, _enabledProperty.boolValue, EditorStyles.boldLabel);

            //base.OnGUI()

            /*
            EditorGUILayout.PropertyField(_inputProperty);

            if (_data0Property != null)
                EditorGUILayout.PropertyField(_data0Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(0).stringValue));
            if (_data1Property != null)
                EditorGUILayout.PropertyField(_data1Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(1).stringValue));
            if (_data2Property != null)
                EditorGUILayout.PropertyField(_data2Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(2).stringValue));
            if (_data3Property != null)
                EditorGUILayout.PropertyField(_data3Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(3).stringValue));

            EditorGUILayout.EndVertical();

            property.serializedObject.ApplyModifiedProperties();
            */
            
        }
    }
}

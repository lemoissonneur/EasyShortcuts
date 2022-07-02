using UnityEditor;
using UnityEngine;


namespace Shortcuts
{
    [CustomPropertyDrawer(typeof(Shortcut), true)]
    public class ShortcutDrawer : PropertyDrawer
    {
        private readonly string[] _PopupOption = { "Single Key", "Dual Key" };

        private readonly GUIStyle _PopupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
        {
            imagePosition = ImagePosition.ImageOnly
        };

        private Rect _labelRect(Rect position) => new Rect()
        {
            x = position.x,
            y = position.y,
            width = position.width * 0.4f - _PopupStyle.fixedWidth - _PopupStyle.margin.right,
            height = EditorGUIUtility.singleLineHeight,
        };

        private Rect _buttonRect(Rect position) => new Rect()
        {
            x = position.x + position.width * 0.4f - _PopupStyle.fixedWidth - _PopupStyle.margin.right,
            y = position.y + _PopupStyle.margin.top,
            width = _PopupStyle.fixedWidth + _PopupStyle.margin.right,
            height = EditorGUIUtility.singleLineHeight,
        };

        private Rect _keysRect(Rect position) => new Rect()
        {
            x = position.x + position.width * 0.4f,
            y = position.y,
            width = position.width * 0.6f,
            height = EditorGUIUtility.singleLineHeight,
        };

        private Rect _dataRect(Rect position, int index) => new Rect()
        {
            x = position.x,
            y = position.y + (EditorGUIUtility.singleLineHeight + 2) * (index+1),
            width = position.width,
            height = EditorGUIUtility.singleLineHeight
        };

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            int lineCount;

            if (property.FindPropertyRelative(nameof(Shortcut<object, object, object, object>.Data3)) != null) lineCount = 5;
            else if (property.FindPropertyRelative(nameof(Shortcut<object, object, object>.Data2)) != null) lineCount = 4;
            else if (property.FindPropertyRelative(nameof(Shortcut<object, object>.Data1)) != null) lineCount = 3;
            else if (property.FindPropertyRelative(nameof(Shortcut<object>.Data0)) != null) lineCount = 2;
            else lineCount = 1;

            return EditorGUIUtility.singleLineHeight * lineCount + 15;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty _enabledProperty = property.FindPropertyRelative(nameof(Shortcut.Enabled));
            SerializedProperty _keyModeProperty = property.FindPropertyRelative(nameof(Shortcut.KeyMode));
            SerializedProperty _holdKeyProperty = property.FindPropertyRelative(nameof(Shortcut.HoldKey));
            SerializedProperty _downKeyProperty = property.FindPropertyRelative(nameof(Shortcut.DownKey));
            SerializedProperty _data0Property = property.FindPropertyRelative(nameof(Shortcut<object>.Data0));
            SerializedProperty _data1Property = property.FindPropertyRelative(nameof(Shortcut<object, object>.Data1));
            SerializedProperty _data2Property = property.FindPropertyRelative(nameof(Shortcut<object, object, object>.Data2));
            SerializedProperty _data3Property = property.FindPropertyRelative(nameof(Shortcut<object, object, object, object>.Data3));
            SerializedProperty _argumentsNamesProperty = property.FindPropertyRelative(nameof(Shortcut<object, object>.ArgumentNames));

            // FIRST LINE

            // draw label with enable toggle on the left
            _enabledProperty.boolValue = EditorGUI.ToggleLeft(_labelRect(position), label, _enabledProperty.boolValue, EditorStyles.boldLabel);

            // draw mode button
            _keyModeProperty.enumValueIndex = EditorGUI.Popup(_buttonRect(position), _keyModeProperty.enumValueIndex, _PopupOption, _PopupStyle);

            // draw one or two KeyCode input depending on mode
            if ((Shortcut.KeyType)_keyModeProperty.enumValueIndex == Shortcut.KeyType.DUALKEY)
            {
                GUIContent[] guiString = { new GUIContent("Hold Key"), new GUIContent("Down Key") };

                EditorGUI.MultiPropertyField(_keysRect(position), guiString, _holdKeyProperty);
            }
            else
            {
                GUIContent[] guiString = { new GUIContent("Down Key") };

                EditorGUI.MultiPropertyField(_keysRect(position), guiString, _downKeyProperty);
            }

            // If input needed
            if (_data0Property != null)
                EditorGUI.PropertyField(_dataRect(position, 0), _data0Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(0).stringValue));
            if (_data1Property != null)
                EditorGUI.PropertyField(_dataRect(position, 1), _data1Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(1).stringValue));
            if (_data2Property != null)
                EditorGUI.PropertyField(_dataRect(position, 2), _data2Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(2).stringValue));
            if (_data3Property != null)
                EditorGUI.PropertyField(_dataRect(position, 3), _data3Property, new GUIContent(_argumentsNamesProperty.GetArrayElementAtIndex(3).stringValue));
            
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}

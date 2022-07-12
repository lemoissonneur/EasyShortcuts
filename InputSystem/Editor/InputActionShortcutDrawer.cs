using UnityEditor;
using UnityEngine;

namespace EasyShortcuts.Editor
{
    [CustomPropertyDrawer(typeof(InputActionShortcut), true)]
    public class InputActionShortcutDrawer : PropertyDrawer
    {
        private Rect _useRefRect(Rect position) => new Rect()
        {
            x = position.x + position.width * 0.7f,
            y = position.y,
            width = position.width * 0.3f,
            height = EditorGUIUtility.singleLineHeight,
        };

        private Rect _phaseRect(Rect position) => new Rect()
        {
            x = position.x + position.width * 0.4f,
            y = position.y,
            width = position.width * 0.3f,
            height = EditorGUIUtility.singleLineHeight,
        };

        private Rect _titleRect(Rect position) => new Rect()
        {
            x = position.x,
            y = position.y,
            width = position.width * 0.4f,
            height = EditorGUIUtility.singleLineHeight,
        };

        private Rect _dataRect(Rect position, int index) => new Rect()
        {
            x = position.x,
            y = position.y + (EditorGUIUtility.singleLineHeight + 2) * index,
            width = position.width,
            height = EditorGUIUtility.singleLineHeight
        };

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var height = 0f;

            // Field label + options
            height += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;

            SerializedProperty _inputProperty = property.FindPropertyRelative("m_Input");

            // We show either the InputAction property drawer or InputAssetReferenceDrawer.
            SerializedProperty _useRefProperty = _inputProperty.FindPropertyRelative("m_UseReference");
            if (!_useRefProperty.boolValue)
            {
                SerializedProperty actionProperty = _inputProperty.FindPropertyRelative("m_Action");
                height += EditorGUI.GetPropertyHeight(actionProperty);
            }
            else
            {
                SerializedProperty referenceProperty = _inputProperty.FindPropertyRelative("m_Reference");
                height += EditorGUI.GetPropertyHeight(referenceProperty);
            }

            int lineCount = 0;

            if (property.FindPropertyRelative(nameof(InputActionShortcut<object, object, object, object>.Data4)) != null) lineCount = 4;
            else if (property.FindPropertyRelative(nameof(InputActionShortcut<object, object, object>.Data3)) != null) lineCount = 3;
            else if (property.FindPropertyRelative(nameof(InputActionShortcut<object, object>.Data2)) != null) lineCount = 2;
            else if (property.FindPropertyRelative(nameof(InputActionShortcut<object>.Data1)) != null) lineCount = 1;

            height += (EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing) * lineCount;

            return height;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            SerializedProperty _inputProperty = property.FindPropertyRelative("m_Input");
            SerializedProperty _phaseProperty = property.FindPropertyRelative("m_Phase");
            SerializedProperty _useRefProperty = _inputProperty.FindPropertyRelative("m_UseReference");

            SerializedProperty _data1Property = property.FindPropertyRelative(nameof(InputActionShortcut<object>.Data1));
            SerializedProperty _data2Property = property.FindPropertyRelative(nameof(InputActionShortcut<object, object>.Data2));
            SerializedProperty _data3Property = property.FindPropertyRelative(nameof(InputActionShortcut<object, object, object>.Data3));
            SerializedProperty _data4Property = property.FindPropertyRelative(nameof(InputActionShortcut<object, object, object, object>.Data4));

            SerializedProperty _argumentsNamesProperty = property.FindPropertyRelative(nameof(InputActionShortcut<object>.ArgumentNames));


            EditorGUI.LabelField(_titleRect(position), label, EditorStyles.boldLabel);

            float labelWidth = EditorGUIUtility.labelWidth;
            float fieldWidth = EditorGUIUtility.fieldWidth;

            Rect phaseRect = _phaseRect(position);
            EditorGUIUtility.labelWidth = phaseRect.width * 0.4f;
            EditorGUIUtility.fieldWidth = phaseRect.width * 0.6f;

            EditorGUI.PropertyField(phaseRect, _phaseProperty, new GUIContent("Phase"), true);


            Rect useRefRect = _useRefRect(position);
            EditorGUIUtility.fieldWidth = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing * 4;
            EditorGUIUtility.labelWidth = useRefRect.width - EditorGUIUtility.fieldWidth;

            EditorGUI.PropertyField(useRefRect, _useRefProperty, new GUIContent("Use Reference"));

            EditorGUIUtility.labelWidth = labelWidth;
            EditorGUIUtility.fieldWidth = fieldWidth;


            float _inputActionHeight;
            const int kIndent = 16;

            if (!_useRefProperty.boolValue)
            {
                SerializedProperty actionProperty = _inputProperty.FindPropertyRelative("m_Action");

                Rect actionDrawerRect = position;
                actionDrawerRect.x += kIndent;
                actionDrawerRect.width -= kIndent;
                actionDrawerRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                _inputActionHeight = actionDrawerRect.height = EditorGUI.GetPropertyHeight(actionProperty);

                EditorGUI.PropertyField(actionDrawerRect, actionProperty);
            }
            else
            {
                SerializedProperty referenceProperty = _inputProperty.FindPropertyRelative("m_Reference");

                Rect referenceRect = position;
                referenceRect.x += kIndent;
                referenceRect.width -= kIndent;
                referenceRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                _inputActionHeight = referenceRect.height = EditorGUI.GetPropertyHeight(referenceProperty);

                EditorGUI.PropertyField(referenceRect, referenceProperty);
            }

            position.yMin += _inputActionHeight + EditorGUIUtility.standardVerticalSpacing *2;

            EditorGUI.indentLevel++;

            // If input needed
            if (_data1Property != null)
                DrawDataField(position, _data1Property, _argumentsNamesProperty, 1);
            if (_data2Property != null)
                DrawDataField(position, _data2Property, _argumentsNamesProperty, 2);
            if (_data3Property != null)
                DrawDataField(position, _data3Property, _argumentsNamesProperty, 3);
            if (_data4Property != null)
                DrawDataField(position, _data4Property, _argumentsNamesProperty, 4);

            EditorGUI.indentLevel--;

            property.serializedObject.ApplyModifiedProperties();
            
            EditorGUI.EndProperty();
        }

        private void DrawDataField(Rect position, SerializedProperty data, SerializedProperty names, int index)
        {
            EditorGUI.PropertyField(
                _dataRect(position, index),
                data,
                new GUIContent(names.GetArrayElementAtIndex(index - 1).stringValue));
        }
    }
}

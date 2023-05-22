using System;
using System.Globalization;
using UnityEditor;
using UnityEngine;
using Utils.Drawers.Key;

namespace Game.Utils.Drawers
{
    [CustomPropertyDrawer(typeof(KeyValueFormatAttribute))]
     public class KeyValueFormatPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            => EditorGUI.GetPropertyHeight(property, label, true);

        protected virtual KeyValueFormatAttribute Attribute => (KeyValueFormatAttribute)attribute;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var args = new string[Attribute.Args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                var fullPathName = property.propertyPath + "." + Attribute.Args[i];
                var titleNameProp = property.serializedObject.FindProperty(fullPathName);
                var newLabel = GetTitle(titleNameProp);
                if (string.IsNullOrEmpty(newLabel))
                    newLabel = label.text;

                args[i] = newLabel;
            }

            EditorGUI.PropertyField(position, property,
                new GUIContent(string.Format(Attribute.Format, args), label.tooltip), true);
        }

        private static string GetTitle(SerializedProperty titleNameProp)
        {
            if (titleNameProp == null)
                return "KeyValue -> Null";

            try
            {
                switch (titleNameProp.propertyType)
                {
                    case SerializedPropertyType.Integer:
                        return titleNameProp.intValue.ToString();
                    case SerializedPropertyType.Boolean:
                        return titleNameProp.boolValue.ToString();
                    case SerializedPropertyType.Float:
                        return titleNameProp.floatValue.ToString(CultureInfo.InvariantCulture);
                    case SerializedPropertyType.String:
                        return titleNameProp.stringValue;
                    case SerializedPropertyType.Color:
                        return titleNameProp.colorValue.ToString();
                    case SerializedPropertyType.ObjectReference:
                        return titleNameProp.objectReferenceValue?.ToString();
                    case SerializedPropertyType.Enum:
                        return titleNameProp.enumNames[titleNameProp.enumValueIndex];
                    case SerializedPropertyType.Vector2:
                        return titleNameProp.vector2Value.ToString();
                    case SerializedPropertyType.Vector3:
                        return titleNameProp.vector3Value.ToString();
                    case SerializedPropertyType.Vector4:
                        return titleNameProp.vector4Value.ToString();
                    default:
                        return $"{titleNameProp.propertyType} Key not Implemented";
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError($"[{nameof(KeyValuePropertyDrawer)}] {e}");
                return "KeyValue -> Exception";
            }
        }
    }
}
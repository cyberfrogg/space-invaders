﻿using System;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Editor.Settings
{
    [CustomPropertyDrawer(typeof(RainbowFolder))]
    public class RainbowFolderDrawer : PropertyDrawer
    {
        private const float PADDING = 8f;
        private const float SPACING = 1f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 100f;
        private const float PREVIEW_SIZE_SMALL = 16f;
        private const float PREVIEW_SIZE_LARGE = 64f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var originalPosition = position;

            var folderKey = property.FindPropertyRelative("Key");
            var folderKeyType = property.FindPropertyRelative("Type");
            var folderRecursive = property.FindPropertyRelative("IsRecursive");
            var smallIcon = property.FindPropertyRelative("SmallIcon");
            var largeIcon = property.FindPropertyRelative("LargeIcon");

            // Labels

            position.y += PADDING;
            position.width = LABELS_WIDTH - PADDING;
            position.height = LINE_HEIGHT;

            var typeSelected = (RainbowFolder.KeyType) Enum.GetValues(typeof(RainbowFolder.KeyType)).GetValue(folderKeyType.enumValueIndex);
            folderKeyType.enumValueIndex = (int)(RainbowFolder.KeyType) EditorGUI.EnumPopup(position, typeSelected);

            position.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(position, "Recursive");

            position.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(position, "Small Icon");

            position.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(position, "Large Icon");

            // Values

            position.x += LABELS_WIDTH;
            position.y = originalPosition.y + PADDING;
            position.width = originalPosition.width - LABELS_WIDTH;
            EditorGUI.PropertyField(position, folderKey, GUIContent.none);

            position.width = originalPosition.width - LABELS_WIDTH - PREVIEW_SIZE_LARGE - PADDING;
            position.y += LINE_HEIGHT + (EditorGUIUtility.isProSkin ?  0f : SPACING) ;
            EditorGUI.PropertyField(position, folderRecursive, GUIContent.none);

            position.y += LINE_HEIGHT + SPACING + (EditorGUIUtility.isProSkin ? SPACING : 0f);
            EditorGUI.PropertyField(position, smallIcon, GUIContent.none);

            position.y += LINE_HEIGHT + SPACING;
            EditorGUI.PropertyField(position, largeIcon, GUIContent.none);
            

            // Preview

            position.x += position.width + PADDING;
            position.y = originalPosition.y + LINE_HEIGHT + SPACING + 5f;
            position.width = position.height = PREVIEW_SIZE_LARGE;
            GUI.DrawTexture(position, (Texture2D) largeIcon.objectReferenceValue ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());

            position.y += PREVIEW_SIZE_LARGE - PREVIEW_SIZE_SMALL - 4f;
            position.width = position.height = PREVIEW_SIZE_SMALL;
            GUI.DrawTexture(position, (Texture2D) smallIcon.objectReferenceValue ?? RainbowFoldersEditorUtility.GetDefaultFolderIcon());
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return PREVIEW_SIZE_LARGE + LINE_HEIGHT + 4f;
        }
    }
}
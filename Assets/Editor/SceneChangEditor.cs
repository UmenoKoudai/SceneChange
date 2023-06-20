using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneName))]
public class SceneChangEditor: PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var scene = EditorBuildSettings.scenes;
        string[] sceneNames = new string[scene.Length];
        for(int i = 0; i < scene.Length; i++)
        {
            string s = scene[i].path.Replace("Assets/Scenes/", "").Replace(".unity", "");
            sceneNames[i] = s;
        }
        Debug.Log(string.Join(" ", sceneNames));
        EditorGUI.LabelField(position, "ŽŸ‚ÌƒV[ƒ“");
        position.y += EditorGUIUtility.singleLineHeight + 15;
        var sceneProperty = property.FindPropertyRelative("_sceneName");
        Debug.Log(sceneProperty);
        var previous = Array.IndexOf(scene, sceneProperty.stringValue);

        var selectIndex = EditorGUI.Popup(position, previous, sceneNames);
        if(selectIndex != previous)
        {
            previous = selectIndex;
            sceneProperty.stringValue = sceneNames[previous];
            sceneProperty.serializedObject.ApplyModifiedProperties();
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight + 15;
    }
}

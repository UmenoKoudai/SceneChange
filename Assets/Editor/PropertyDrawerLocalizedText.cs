using System;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomPropertyDrawer(typeof(LocalizedText))]
public class PropertyDrawerLocalizedText : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // 現在格納されているキーデータをもとに、ポップアップに必要なデータを取得
        var keys = TextMaster.Instance.Data.Keys.ToArray();
        Debug.Log(string.Join(" ", keys));
        EditorGUI.LabelField(position, "テキストキー");
        position.y += EditorGUIUtility.singleLineHeight + 8;
        var textKeyProperty = property.FindPropertyRelative("_textKey"); // カスタムしているプロパティがもつ"_textKey"変数のSerializedPropertyを取得する
        var previousIndex = Array.IndexOf(keys, textKeyProperty.stringValue);

        // ポップアップを表示
        var selectedIndex = EditorGUI.Popup(position, previousIndex, TextMaster.Instance.Data.Values.ToArray());

        // ポップアップで値を変えていれば、キーを取得してシリアライズ情報を更新
        if (selectedIndex != previousIndex)
        {
            previousIndex = selectedIndex;
            textKeyProperty.stringValue = keys[previousIndex];

            // 修正があったらシリアライズしてあるオブジェクトに変更を反映
            textKeyProperty.serializedObject.ApplyModifiedProperties(); // これがないとデータが何も変更されない
        }
    }
    /// プロパティの高さを取得する。カスタムによって高さが変わるなら必須
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight + 10;
    }

}

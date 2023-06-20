using System;
using UnityEditor;
using UnityEngine;
using System.Linq;

[CustomPropertyDrawer(typeof(LocalizedText))]
public class PropertyDrawerLocalizedText : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // ���݊i�[����Ă���L�[�f�[�^�����ƂɁA�|�b�v�A�b�v�ɕK�v�ȃf�[�^���擾
        var keys = TextMaster.Instance.Data.Keys.ToArray();
        Debug.Log(string.Join(" ", keys));
        EditorGUI.LabelField(position, "�e�L�X�g�L�[");
        position.y += EditorGUIUtility.singleLineHeight + 8;
        var textKeyProperty = property.FindPropertyRelative("_textKey"); // �J�X�^�����Ă���v���p�e�B������"_textKey"�ϐ���SerializedProperty���擾����
        var previousIndex = Array.IndexOf(keys, textKeyProperty.stringValue);

        // �|�b�v�A�b�v��\��
        var selectedIndex = EditorGUI.Popup(position, previousIndex, TextMaster.Instance.Data.Values.ToArray());

        // �|�b�v�A�b�v�Œl��ς��Ă���΁A�L�[���擾���ăV���A���C�Y�����X�V
        if (selectedIndex != previousIndex)
        {
            previousIndex = selectedIndex;
            textKeyProperty.stringValue = keys[previousIndex];

            // �C������������V���A���C�Y���Ă���I�u�W�F�N�g�ɕύX�𔽉f
            textKeyProperty.serializedObject.ApplyModifiedProperties(); // ���ꂪ�Ȃ��ƃf�[�^�������ύX����Ȃ�
        }
    }
    /// �v���p�e�B�̍������擾����B�J�X�^���ɂ���č������ς��Ȃ�K�{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight + 10;
    }

}

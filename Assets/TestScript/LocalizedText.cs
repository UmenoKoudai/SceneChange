using System;
using UnityEngine;

[Serializable]
public class LocalizedText
{
    // �}�X�^�[����ǂݍ��ނ̂Ɏg���L�[
    [SerializeField] private string _textKey;
    // View�Ŏg���e�L�X�g�f�[�^
    public string Value => _textKey;
}
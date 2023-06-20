using System;
using UnityEngine;

[Serializable]
public class LocalizedText
{
    // マスターから読み込むのに使うキー
    [SerializeField] private string _textKey;
    // Viewで使うテキストデータ
    public string Value => _textKey;
}
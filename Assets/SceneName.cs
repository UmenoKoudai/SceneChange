using System;
using UnityEngine;

[Serializable]
public class SceneName
{
    [SerializeField]string _sceneName;
    public string NextName => _sceneName;
}

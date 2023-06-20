using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceSystem<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if(_instance == null)
                {
                    Debug.LogWarning($"{typeof(T)}�����݂��܂���");
                }
            }
            return _instance;
        }
    }
}

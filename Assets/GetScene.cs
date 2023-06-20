using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetScene
{
    static GetScene _instance; 
    public static GetScene Instance => _instance ?? (_instance = new GetScene());

    public readonly string[] Scenes = new string[10];
}

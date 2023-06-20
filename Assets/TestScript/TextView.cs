using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextView : MonoBehaviour
{
    [SerializeField] private LocalizedText _text;

    private void Awake()
    {
        GetComponent<Text>().text = _text.Value;
    }
}
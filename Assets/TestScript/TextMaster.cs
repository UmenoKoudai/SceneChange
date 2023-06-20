using System.Collections.Generic;

public class TextMaster
{
    private static TextMaster _instance = null;
    public static TextMaster Instance => _instance ?? (_instance = new TextMaster());

    public readonly Dictionary<string, string> Data = new Dictionary<string, string>();

    public TextMaster()
    {
        // TODO: ����ݒ�ɍ��킹���e�L�X�g�}�X�^�[���擾����
        for (int i = 0; i < 10; i++)
        {
            Data[$"key{i}"] = $"�e�L�X�g�f�[�^ {i}";
        }
        
    }

    /// �}�X�^�[����e�L�X�g�f�[�^���擾����
    public string GetText(string key) => Data[key];
}
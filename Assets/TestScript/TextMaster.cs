using System.Collections.Generic;

public class TextMaster
{
    private static TextMaster _instance = null;
    public static TextMaster Instance => _instance ?? (_instance = new TextMaster());

    public readonly Dictionary<string, string> Data = new Dictionary<string, string>();

    public TextMaster()
    {
        // TODO: 言語設定に合わせたテキストマスターを取得する
        for (int i = 0; i < 10; i++)
        {
            Data[$"key{i}"] = $"テキストデータ {i}";
        }
        
    }

    /// マスターからテキストデータを取得する
    public string GetText(string key) => Data[key];
}
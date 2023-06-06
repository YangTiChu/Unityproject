using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageMgr : MonoBehaviour
{
    private static LanguageMgr instance = null;
    public static LanguageMgr Instance
    {
        get { return instance; }
    }
    /// <summary>
    /// �y��
    /// </summary>
    [SerializeField]
    private SystemLanguage language;
    /// <summary>
    /// �ۦP��key ���� ���P��a��value
    /// </summary>
    private Dictionary<string, string> dict = new Dictionary<string, string>();
    /// <summary>
    /// �[���w½Ķ���y��
    /// </summary>
    private void LoadLanguage()
    {
        //�[�����
        TextAsset ta = Resources.Load<TextAsset>(language.ToString());
        if (ta == null)
        {
            Debug.LogWarning("�S���o�ӻy����½Ķ���");
            return;
        }
        //����C�@��
        string[] lines = ta.text.Split('\n');
        //���key value
        for (int i = 0; i < lines.Length; i++)
        {
            //�˴�
            if (string.IsNullOrEmpty(lines[i]))
                continue;
            //��� key:kv[0] value kv[1]
            string[] kv = lines[i].Split(':');
            //�O�s��r��
            dict.Add(kv[0], kv[1]);
            Debug.Log(string.Format("key:{0}, value:{1}", kv[0], kv[1]));
        }
    }
    void Awake()
    {
        instance = this;
        LoadLanguage();
    }
    /// <summary>
    /// ���������value
    /// </summary>
    /// <param name="key">��</param>
    /// <returns>��^������value �p�G���s�b�o��key �N��^�Ŧ�</returns>
    public string GetText(string key)
    {
        if (dict.ContainsKey(key))
            return dict[key];
        else//�S���o��key
        {
            return string.Empty;
        }
    }
}


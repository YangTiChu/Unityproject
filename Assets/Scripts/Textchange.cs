using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Textchange : MonoBehaviour
{
    [SerializeField]
    private string key;
    // Use this for initialization
    void Start()
    {
        if (!string.IsNullOrEmpty(key))
        {
            string value = LanguageMgr.Instance.GetText(key);
            if (!string.IsNullOrEmpty(value))
            {
                gameObject.GetComponent<Text>().text = value;
            }
        }
    }
}

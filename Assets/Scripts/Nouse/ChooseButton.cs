using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lv1Click()
    {
        SceneManager.LoadScene(2);
    }
    public void Lv2Click()
    {
        SceneManager.LoadScene(3);
    }
    public void Lv3Click()
    {
        SceneManager.LoadScene(4);
    }
}

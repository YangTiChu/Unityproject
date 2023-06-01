using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startbutton : MonoBehaviour
{
    public GameObject setPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClick()
    {
        SceneManager.LoadScene(1);
    }
    public void PracticeClick()
    {
        setPanel.SetActive(true);
    }
    public void SetClick()
    {
        setPanel.SetActive(true);
    }
    public void BackClick()
    {
        setPanel.SetActive(false);
    }
    public void ExitClick()
    {
        Application.Quit();
    }
    
}

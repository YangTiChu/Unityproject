using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVMenuButton : MonoBehaviour
{
    public GameObject MenuPage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HPClick()
    {
        SceneManager.LoadScene(0);
    }
    public void LCClick()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuClick()
    {
        Time.timeScale = 0f;
        MenuPage.SetActive(true);
    }
    public void CancelClick()
    {
        MenuPage.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ExitClick()
    {
        Application.Quit();
    }
}

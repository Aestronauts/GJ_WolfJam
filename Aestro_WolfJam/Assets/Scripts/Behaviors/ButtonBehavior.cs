using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(("MainMenu"));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelTutorial");
    }
}

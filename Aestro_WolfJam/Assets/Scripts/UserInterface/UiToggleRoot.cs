using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiToggleRoot : MonoBehaviour
{
    public List<GameObject> uiRoots;
    public bool toggleUiAlsoPauses = true;
    public KeyCode toggleKey1 = KeyCode.Escape, toggleKey2 = KeyCode.P;

    private bool uiIsActive = true;

    // Start is called before the first frame update
    void Start()
    {
        ToggleUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(toggleKey1) || Input.GetKeyDown(toggleKey2))
            ToggleUI();

    }

    public void ToggleUI()
    {
        if (uiRoots.Count > 0)
        {
            foreach (GameObject uiHolder in uiRoots)
                uiHolder.SetActive(!uiIsActive);
        }

        uiIsActive = !uiIsActive;

        if (toggleUiAlsoPauses)
        {
            if (uiIsActive)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }
        
    }

}// end of UiToggleRoot class

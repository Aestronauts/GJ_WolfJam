using UnityEngine;
using System;
using TMPro;

public class UiKeybinder : MonoBehaviour
{
    // movement
    public TMP_InputField inputField_Forward, inputField_Backwards, inputField_Right, inputField_Left;
    public KeyCode input_Forward, input_Backwards, input_Right, input_Left;
    // interact
    public TMP_InputField inputField_InteractMain;
    public KeyCode input_InteractMain;

    private void OnEnable()
    {
        inputField_Forward.text = input_Forward.ToString();
        inputField_Backwards.text = input_Backwards.ToString();
        inputField_Right.text = input_Right.ToString();
        inputField_Left.text = input_Left.ToString();

        inputField_InteractMain.text = input_InteractMain.ToString();
    }


    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            // move
            if (inputField_Forward.isFocused)
            {
                inputField_Forward.text = e.keyCode.ToString();
                input_Forward = e.keyCode;
            }
            if (inputField_Backwards.isFocused)
            {
                inputField_Backwards.text = e.keyCode.ToString();
                input_Backwards = e.keyCode;
            }

            if (inputField_Right.isFocused)
            {
                inputField_Right.text = e.keyCode.ToString();
                input_Right = e.keyCode;
            }
            if (inputField_Left.isFocused)
            {
                inputField_Left.text = e.keyCode.ToString();
                input_Left = e.keyCode;
            }
            // interact
            if (inputField_InteractMain.isFocused)
            {
                inputField_InteractMain.text = e.keyCode.ToString();
                input_InteractMain = e.keyCode;
            }
        }
    }

}// end of UiKeybinder class

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button[] keyboardButtons;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            char keyPressed = char.ToLower(GetKeyPressed());
            if (keyPressed != '\0')
            {
                ClickButton(keyPressed);
            }
        }   
    }

    private char GetKeyPressed()
    {
        foreach(KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (IsLetterKey(keyCode) || keyCode == KeyCode.Return)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    return GetLetterFromKeyCode(keyCode);
                }
            }
        }
        return '\0';
    }

    private bool IsLetterKey(KeyCode keyCode)
    {
        return (keyCode >= KeyCode.A && keyCode <= KeyCode.Z);
    }

    private char GetLetterFromKeyCode(KeyCode keyCode)
    {
        if (IsLetterKey(keyCode))
        {
            return keyCode.ToString()[0];
        }
        return '\0';
    }
    private void ClickButton(char key)
    {
        foreach(var button in keyboardButtons)
        {
            if (button.tag == key.ToString())
            {
                button.onClick.Invoke();
                break;
            }
        }
    }
}

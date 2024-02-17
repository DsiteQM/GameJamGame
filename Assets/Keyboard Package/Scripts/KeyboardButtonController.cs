using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardButtonController : MonoBehaviour
{
    [SerializeField] Image containerBorderImage;
    [SerializeField] Image containerFillImage;
    [SerializeField] Image containerIcon;
    [SerializeField] TextMeshProUGUI containerText;
    [SerializeField] TextMeshProUGUI containerActionText;
    private TextMeshProUGUI buttonText;

    private void Start() {
        SetContainerBorderColor(ColorDataStore.GetKeyboardBorderColor());
        SetContainerFillColor(ColorDataStore.GetKeyboardFillColor());
        SetContainerTextColor(ColorDataStore.GetKeyboardTextColor());
        SetContainerActionTextColor(ColorDataStore.GetKeyboardActionTextColor());
        buttonText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetContainerBorderColor(Color color) => containerBorderImage.color = color;
    public void SetContainerFillColor(Color color) => containerFillImage.color = color;
    public void SetContainerTextColor(Color color) => containerText.color = color;
    public void SetContainerActionTextColor(Color color) { 
        containerActionText.color = color;
        containerIcon.color = color;
    }

    public void AddLetter() {
        if(GameManager.Instance != null) {
            GameManager.Instance.AddLetter(containerText.text);
        } else {
            Debug.Log(containerText.text + " is pressed");
            ChangeTextColor(Color.red);
            Invoke("ChangeTextColorDelay", 0.1f);
        }
    }
    public void DeleteLetter() { 
        if(GameManager.Instance != null) {
            GameManager.Instance.DeleteLetter();
        } else {
            Debug.Log("Last char deleted");
        }
    }
    public void SubmitWord() {
        if(GameManager.Instance != null) {
            GameManager.Instance.SubmitWord();
        } else {
            Debug.Log("Submitted successfully!");
        }
    }
    private void ChangeTextColor(Color color)
    {
        buttonText.color = color;
    }
    private void ChangeTextColorDelay()
    {
        buttonText.color = Color.white;
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    public List<TMP_InputField> inputFields;
    public List<string> answers = new List<string>();
    public GameObject roomTest;
    public GameObject player;

    public void Start()
    {
        answers.Add("weather");
        answers.Add("library");
        answers.Add("sandals");
    }
    public void checkIfCorrect()
    {
        for (int i = 0; i < inputFields.Count; i++)
        {
            Debug.Log(answers[i]);
            Debug.Log(inputFields[i].text);
            Debug.Log("--------------");
            if (!(inputFields[i].text.ToLower().Contains(answers[i])))
            {
                Debug.Log("failed");
                Debug.Log(answers[i]);
                Debug.Log(inputFields[i].text);
                SceneManager.LoadScene(1);
                return;
            }
            
        }
        roomTest.SetActive(false);
        player.GetComponent<PlayerMovement>().setCanMove(true);
        SceneManager.LoadScene(2);
        Debug.Log("passed");
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerController : MonoBehaviour
{
    public List<TMP_InputField> inputFields;
    public List<string> answers = new List<string>();
    // Start is called before the first frame update

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
            if (!(inputFields[i].text.ToLower().Contains(answers[i])))
            {
                Debug.Log("failed");
            }
            
        }
        Debug.Log("passed");
    }
}

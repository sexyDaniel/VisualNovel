using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueItemManager : MonoBehaviour
{
    public DialogueItem answerNode;
    public Text TextQuestion;
    public Text NameCharacter;
    public GameObject Continue;
    public GameObject Back;
    public Image imagecontaner;
    public GUISkin skin;

    void Start()
    {
        UpdateUi();
    }
    void OnGUI()
    {
        GUIStyle a = skin.button;
        if (answerNode.questions.Length != 0)
        {
            for (int i = 0; i < answerNode.questions.Length; i++)
            {
                if (GUI.Button(new Rect(Screen.width/2- Screen.width / 4, 600 + i * 50, Screen.width / 2, 50), answerNode.questions[i].text,a))
                {
                    answerNode = answerNode.questions[i].question;
                    UpdateUi();
                }
            }
        }
    }
    public void UpdateUi()
    {
        StartCoroutine(GetChar(answerNode.text));
        imagecontaner.sprite = answerNode.Bckground;
        if (answerNode.Next != null)
        {
            Continue.SetActive(true);
            NameCharacter.text = answerNode.NameCharacter;
            if (answerNode.Back != null)
            {
                Back.SetActive(true);
            }
            else Back.SetActive(false);
        }
        else if (answerNode.Back != null)
        {
            NameCharacter.text = answerNode.NameCharacter;
            Continue.SetActive(false);
            Back.SetActive(true);
        }
        else
        {
            Continue.SetActive(false);
            Back.SetActive(false);
        }
    }

    IEnumerator GetChar(string s)
    {
        TextQuestion.text = "";
        foreach (var c in s)
        {
            TextQuestion.text += c;
            yield return null;
        }
    }

    public void OnClickContinue()
    {
        answerNode = answerNode.Next;
        UpdateUi();
    }

    public void OnClickBack()
    {
        answerNode = answerNode.Back;
        UpdateUi();
    }
}

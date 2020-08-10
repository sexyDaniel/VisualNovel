using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueItemManager : MonoBehaviour
{
    public DialogueItem answerNode;
    public Text NameCharacter;
    public GameObject Continue;
    public GameObject Back;
    public Image Background;
    public Image CharacterBackground;
    public GUISkin skin;
    public Text text;
    public Animator[] animators;
    public AudioClip audio;

    void Start()
    {
        Background.sprite = answerNode.Background;
        CharacterBackground.sprite = answerNode.CharacterImage;
        UpdateUi();
    }
    void OnGUI()
    {
        GUIStyle a = skin.button;
        if (answerNode.questions.Length != 0)
        {
            for (int i = 0; i < answerNode.questions.Length; i++)
            {
                if (GUI.Button(new Rect(Screen.width / 2-Screen.width / 10, Screen.height- Screen.height/5+ i * 45, Screen.width / 5, 45), answerNode.questions[i].text,a))
                {
                    answerNode = answerNode.questions[i].question;
                    UpdateUi();
                }
            }
        }
    }
    public void UpdateUi()
    {
        if (answerNode.Background!=null)
            Background.sprite = answerNode.Background;
        if (answerNode.CharacterImage != null)
            CharacterBackground.sprite = answerNode.CharacterImage;
        Animation();
        StartCoroutine(GetChar(answerNode.HeroText));
        //imagecontaner.sprite = answerNode.Bckground;
        if (answerNode.Next != null)
        {
            Continue.SetActive(true);
            NameCharacter.text = answerNode.Name;
            if (answerNode.Back != null)
            {
                Back.SetActive(true);
            }
            else Back.SetActive(false);
        }
        else if (answerNode.Back != null)
        {
            NameCharacter.text = answerNode.Name;
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
        text.text = "";
        var i = 0;
        foreach (var c in s)
        {
            i++;
            if (i % 5 == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(audio);
            }
            text.text += c;
            yield return new WaitForSeconds((float)0.015);
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

    public void Animation()
    {
        for (int i = 0; i < answerNode.ShowHeros.Length; i++)
        {
            animators[i].SetBool("ShowCharacter", answerNode.ShowHeros[i]);
        }
    }
}

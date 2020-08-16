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
    public Image CharacterBackground1;
    public GUISkin skin;
    public Text text;
    public Animator[] animators;
    public AudioClip audio;

    void Start()
    {
        Background.sprite = answerNode.Background;
        CharacterBackground.sprite = answerNode.CharacterImage;
        CharacterBackground1.sprite = answerNode.CharacterImage2;
        UpdateUi();
    }
    void OnGUI()
    {
        if (answerNode.questions.Length != 0)
        {
            ShowReplica(skin);
        }
        ShowButtons();
    }
    public void UpdateUi()
    {
        NameCharacter.text = answerNode.Name;
        if (answerNode.Background!=null)
            Background.sprite = answerNode.Background;
        if (answerNode.CharacterImage != null)
            CharacterBackground.sprite = answerNode.CharacterImage;
        if (answerNode.CharacterImage2 != null)
            CharacterBackground1.sprite = answerNode.CharacterImage2;
        Animation();
        StartCoroutine(GetChar(answerNode.HeroText));
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

    public bool CheckLength()
    {
        return answerNode.HeroText.Length == text.text.Length;
    }

    public void Animation()
    {
        for (int i = 0; i < answerNode.ShowHeros.Length; i++)
        {
            animators[i].SetBool("ShowCharacter", answerNode.ShowHeros[i]);
        }
    }

    public void ShowReplica(GUISkin skin)
    {
        for (int i = 0; i < answerNode.questions.Length; i++)
        {
            if (CheckLength() && GUI.Button(new Rect(Screen.width / 10, Screen.height - Screen.height / 5 + i * 45, Screen.width - Screen.width / 5, 45), answerNode.questions[i].text, skin.button))
            {
                answerNode = answerNode.questions[i].question;
                UpdateUi();
            }
        }
    }

    public void ShowButtons()
    {
        if (answerNode.Next != null&& CheckLength())
        {
            Continue.SetActive(true);
            if (answerNode.Back != null)
            {
                Back.SetActive(true);
            }
            else Back.SetActive(false);
        }
        else if (answerNode.Back != null&& CheckLength())
        {
            Continue.SetActive(false);
            Back.SetActive(true);
        }
        else
        {
            Continue.SetActive(false);
            Back.SetActive(false);
        }
    }
}

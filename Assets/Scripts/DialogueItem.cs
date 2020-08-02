using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogItem", menuName = "Create New DialogItem")]
public class DialogueItem : ScriptableObject
{
    public string Name;
    public string HeroText;
    public DialogueItem Back;
    public DialogueItem Next;
    public Question[] questions;
    public bool[] ShowHeros;
}
[System.Serializable]
public class Question
{
    public string text;
    public DialogueItem question;
}
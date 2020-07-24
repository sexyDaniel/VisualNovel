using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogItem", menuName = "Create New DialogItem")]
public class DialogueItem : ScriptableObject
{
    public string NameCharacter;
    public string text;
    public Sprite Bckground;
    public DialogueItem Back;
    public DialogueItem Next;
    public Question[] questions;
}
[System.Serializable]
public class Question
{
    public string text;
    public DialogueItem question;
}
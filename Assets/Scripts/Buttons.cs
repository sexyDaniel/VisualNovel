using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public AudioSource audio;

    public void OnClick()
    {
        audio.Play();
    }
}

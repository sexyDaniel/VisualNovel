using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BackSound;
    public AudioSource ButtonSound;

    private void Start()
    {
        BackSound.Play();
    }
    public void OnClick()
    {
        ButtonSound.Play();
    }
}

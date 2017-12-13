using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClickManger : MonoBehaviour {
    public Button[] buttons;

    public AudioClip[] audioClips;
    //public AudioSource audioSourse;
    public AudioSource[] audioSources;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        audioClips = Resources.LoadAll<AudioClip>("Audio/");

        //audioSourse = GetComponent<AudioSource>();

        audioSources = new AudioSource[buttons.Length];
        for (int i=0; i<buttons.Length; i++)
        {
            audioSources[i] = buttons[i].GetComponent<AudioSource>();
            audioSources[i].clip = ((i < audioClips.Length) ? audioClips[i] : null);

            SetButtonLisitener(i);
        }
        
        //audioSources = Resources.LoadAll<AudioSource>("AudioSource/");
    }

    public void SetButtonLisitener(int num)
    {
        buttons[num].onClick.AddListener(() => BottonClieked(num));
    }

    public void BottonClieked(int num)
    {
        if (audioSources[num].isPlaying)
        {
            audioSources[num].Stop();
        }
        else
        {
            audioSources[num].Play();
        }
    }
}
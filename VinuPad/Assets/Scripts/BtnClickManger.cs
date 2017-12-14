using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BtnClickManger : MonoBehaviour{
    public Button[] buttons;

    public AudioClip[] audioClips;
    public AudioSource[] audioSources;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
        audioClips = Resources.LoadAll<AudioClip>("Audio/");

        audioSources = new AudioSource[buttons.Length];
        for (int i=0; i<buttons.Length; i++)
        {
            audioSources[i] = buttons[i].GetComponent<AudioSource>();
            audioSources[i].clip = ((i < audioClips.Length) ? audioClips[i] : null);

            //홀드를 위한 샘플
            if (i == 16)
            {
                SetButtonHold(i);
            }
            //토글(루프)을 위한 샘플
            if (i == 18)
            {
                SetButtonToggle(i);
            }
        }
    }
    
    public void SetButtonHold(int num){
        //누르고 떼는 것을 인식하는 버튼 리스너를 끄는 것으로 적용
        buttons[num].onClick.AddListener(() =>{
            if (audioSources[num].isPlaying)
            {
                audioSources[num].Stop();
            }
        });
    }

    //버튼의 ActionTrigger에 접근하지 못해서 내부에 스크립트를 추가
    public void SetButtonToggle(int num) {
        buttons[num].gameObject.AddComponent<ToggleButton>();
    }


    //bpm에 맞춰 루프하는 코루틴(현재 사용X)
    /*
    IEnumerator PlayRoof(int num)
    {
        WaitForSeconds sec = new WaitForSeconds(60.0f/123.0f);

        while (true)
        {
            audioSources[num].Play();
            yield return sec;
        }
    }
    */
}
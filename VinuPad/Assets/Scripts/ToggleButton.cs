using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleButton : EventTrigger {
    public AudioSource audioSource;

    /*이 스크립트가 실행되기 전
     * 디폴트로 만들어진 트리거가 실행되어 isPlaying이 무조건 true가 되므로
     * 루프중임을 확인할 수 없다. 따라서 따로 boolean을 둔것이다.
     */
    bool isPlaying;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnPointerDown(PointerEventData data)
    {
        if (isPlaying)
        {
            isPlaying = false;
            audioSource.Stop();
            audioSource.loop = false;
        }
        else
        {
            isPlaying = true;
            audioSource.loop = true;
        }
    }

}

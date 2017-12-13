using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metro : MonoBehaviour {

    public Image metro;

    private void Awake()
    {
        metro = GetComponentInChildren<Image>();
    }
    
    void Start () {
        StartCoroutine("BPMTimer", 246);
	}

    IEnumerator BPMTimer (float bpm)
    {
        WaitForSeconds sec = new WaitForSeconds(60/bpm);
        bool light = false;

        while(true){
            if (light) light = false;
            else light = true;

            metro.gameObject.SetActive(light);

            yield return sec;
        }
    }
}

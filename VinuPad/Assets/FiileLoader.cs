using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class FiileLoader : MonoBehaviour {
    AudioClip[] audioClips;

    BinaryFormatter bf;
    FileStream file;

    // Use this for initialization
    void Start () {
        audioClips = Resources.LoadAll<AudioClip>("Audio/");

        bf = new BinaryFormatter();

        for (int i=0; i < audioClips.Length; i++)
        {

        }
    }
}

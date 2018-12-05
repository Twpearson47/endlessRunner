using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckSoundState : MonoBehaviour
{
  //    public GameObject cameraAudio;
  //  bool audioOn;

    void Start()
    {
        GetComponent<AudioListener>().enabled = SoundController.audioState;
    }

    void Update()
    {
        GetComponent<AudioListener>().enabled = SoundController.audioState;
    }

    public void ToggleAudio()
    {
        Debug.Log("AudioState " + SoundController.audioState);
        SoundController.audioState = !SoundController.audioState;
        Debug.Log("AudioState " + SoundController.audioState);
        GetComponent<AudioListener>().enabled = SoundController.audioState;
    }
}
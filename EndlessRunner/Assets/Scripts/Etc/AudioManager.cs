using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Start()
    {
        foreach (Sound sound in sounds){
            sound.audioSource=gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void PlaySound(string name ){
        foreach (Sound sound in sounds)
        {
            if (sound.name.Equals(name)){
                sound.audioSource.Play();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public AudioClip GetAudio(int i)
    {
        return clip[i];
    }

    public void CreateAudio(AudioClip clip, Transform pos, float volume)
    {
        AudioSource audioS = Instantiate(audioSource, pos.position, Quaternion.identity);
        audioS.clip = clip;
        audioS.volume = volume;
        audioS.Play();
        float length = audioS.clip.length;
        Destroy(audioS.gameObject, length);

    }
}

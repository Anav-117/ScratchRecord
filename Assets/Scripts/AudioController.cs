using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    int LoopLength;

    [SerializeField]
    AudioClip[] Audio;

    public int LoopPoint;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public bool Loop;

    public bool resume = false;

    AudioSource AuxillaryAudio;

    // Start is called before the first frame update
    void Start()
    {
        LoopPoint = 0;
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
        Loop = false;
        AuxillaryAudio = GameObject.Find("Audio Source (Auxillary)").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Loop) {
            if (audioSource.timeSamples > LoopPoint * audioClip.frequency) {
                AuxillaryAudio.clip = Audio[0];
                AuxillaryAudio.Play();
                audioSource.timeSamples -= Mathf.RoundToInt(LoopLength * audioClip.frequency);
            }
        }

        if (resume) {
            resume = false;
            AuxillaryAudio.clip = Audio[1];
            AuxillaryAudio.volume = 1;
            audioSource.volume = 0;
            AuxillaryAudio.Play();
        }

        if (!resume) {
            audioSource.volume = 0.75f;
        }
    }
}

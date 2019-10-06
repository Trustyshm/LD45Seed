using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRandomizer : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;
    private AudioClip clip;
    private int clipSelectorInt;
    public int countdownMinimum;
    public int countdownMaximum;



    private float clipCountdown;
    private float clipSelector;

    // Start is called before the first frame update
    void Start()
    {
        clipCountdown = Random.Range(countdownMinimum, countdownMaximum);
        clipSelector = 0;

    }

    // Update is called once per frame
    void Update()
    {
        clipCountdown -= Time.deltaTime;
        if (clipCountdown <= 0)
        {

            SoundRandomizerRoll();
            PlayClip();

        }


    }

    void PlayClip()
    {
        clipSelectorInt = Mathf.RoundToInt(clipSelector);
        clip = clips[clipSelectorInt];
        source.clip = clip;
        PlayActive();

    }

    void SoundRandomizerRoll()
    {
        clipCountdown = Random.Range(countdownMinimum, countdownMaximum);
        clipSelector = Random.Range(0, clips.Length);
    }

    public void PlayActive()
    {
        source.PlayOneShot(source.clip);

    }

    public void PlayRandomClip()
    {
        clipSelector = Random.Range(0, clips.Length);
        clipSelectorInt = Mathf.RoundToInt(clipSelector);
        clip = clips[clipSelectorInt];
        source.clip = clip;
        source.PlayOneShot(source.clip);
    }



}

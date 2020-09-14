using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    fire, hit, click, jump, walk, sneak, landing, enter, text,
    door,
    kiwi,
    death,
    checkpoint,
    saved
}
public class SoundManager : MonoBehaviour
{
    public static AudioClip playerHitSound, fireSound, jumpSound, clickSound, sneakSound, 
        landingSound, enterPressSound, textSound, doorSound, kiwiSound, deathSound, checkpointSound,
        savedSound;
    public static List<AudioClip> walkSounds = new List<AudioClip>();
    string path = "Sound/";
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>(path + "hit");
        fireSound = Resources.Load<AudioClip>(path + "fireSound");
        jumpSound = Resources.Load<AudioClip>(path + "jump");
        clickSound = Resources.Load<AudioClip>(path + "click");
        walkSounds.AddRange(Resources.LoadAll<AudioClip>(path +"Floor"));
        landingSound = Resources.Load<AudioClip>(path + "landing");
        enterPressSound = Resources.Load<AudioClip>(path + "enter");
        textSound = Resources.Load<AudioClip>(path + "text");
        doorSound = Resources.Load<AudioClip>(path + "door");
        kiwiSound = Resources.Load<AudioClip>(path + "kiwi");
        deathSound = Resources.Load<AudioClip>(path + "death");
        checkpointSound = Resources.Load<AudioClip>(path + "checkpoint");
        savedSound = Resources.Load<AudioClip>(path + "saved");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static bool isPlaying()
    {
        return audioSrc.isPlaying;
    }

    public static void PlaySound(Sounds clip)
    {
        switch (clip)
        {
            case Sounds.fire:
                audioSrc.PlayOneShot(fireSound);
                break;
            case Sounds.click:
                audioSrc.PlayOneShot(clickSound);
                break;
            case Sounds.hit:
                audioSrc.PlayOneShot(playerHitSound);
                break;
            case Sounds.jump:
                audioSrc.PlayOneShot(jumpSound);
                break;
            case Sounds.walk:
                //audioSrc.PlayOneShot(walkSounds[UnityEngine.Random.Range(0,walkSounds.Count)]);
                break;
            case Sounds.sneak:
                audioSrc.PlayOneShot(sneakSound);
                break;
            case Sounds.landing:
                audioSrc.PlayOneShot(landingSound);
                break;
            case Sounds.enter:
                audioSrc.PlayOneShot(enterPressSound);
                break;
            case Sounds.text:
                audioSrc.PlayOneShot(textSound);
                break;
            case Sounds.door:
                audioSrc.PlayOneShot(doorSound);
                break;
            case Sounds.kiwi:
                audioSrc.PlayOneShot(kiwiSound);
                break;
            case Sounds.death:
                audioSrc.PlayOneShot(deathSound);
                break;
            case Sounds.checkpoint:
                audioSrc.PlayOneShot(checkpointSound);
                break;
            case Sounds.saved:
                audioSrc.PlayOneShot(savedSound);
                break;
        }

    }
}

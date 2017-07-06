using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

    public bool reloadRunning = false;

    public List<AudioClip> gun1Sounds = new List<AudioClip>();
    public List<AudioClip> movementSounds = new List<AudioClip>();

    float normalVolume = 0.5f;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void PlayGunShot()
    {
        aSource.PlayOneShot(gun1Sounds[0]);  
    }

    IEnumerator PlayReloadSound()
    {
        reloadRunning = true;
        aSource.PlayOneShot(gun1Sounds[1]);
        yield return new WaitForSeconds(gun1Sounds[1].length);
        aSource.PlayOneShot(gun1Sounds[2]);
        yield return new WaitForSeconds(gun1Sounds[2].length);
    }

    void PlayStep()
    {
        aSource.volume = 0.2f;
        aSource.PlayOneShot(movementSounds[0]);
        aSource.volume = normalVolume;
    }


    void OnEnable()
    {
        PlayerCombat.onShoot += PlayGunShot;
        PlayerCombat.onReload += PlayReloadSound;

        Footstep.onStep += PlayStep;

    }

    void OnDisable()
    {
        PlayerCombat.onShoot -= PlayGunShot;
        PlayerCombat.onReload -= PlayReloadSound;

        Footstep.onStep -= PlayStep;


    }
}

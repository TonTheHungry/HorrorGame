using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    //Theresa. This keeps track of previous sound played
    private string prevname = null;
    private AudioSource previousSource = null;

    void Awake()
    {
        //AudioManager from first scene still exists due to DontDestroyOnLoad command
        if (instance != null)
        {
            //previous scene created an instance. We don't want two audiomanagers or more..
            //See Brackey tutorial 12:36 "Intro to Audio in unity" on youtube.
            //AudioManagers have multiple AudioSources (they are hidden in inspector)
            //since they are contained as part of the array sounds, which consists of
            //the fields in the Sound class.
            // See fields above to see what consists in the gameObject AudioManager.
            //Each scene must contain the prefab AudioManager
            //Destroy the new scene's static AudioManager created
            //in the scene's gameObject called AudioManager. gameObject refers
            //to the new scene's AudioManager linked to this AudioManager.cs. It hasn't
            //been assigned to instance yet.
            Destroy(gameObject);
            //return is not in downloaded code  
            //return;
        }
        else
        {
            //first time here. instance will be the AudioManager gameObject from first scene
            //AudioManager.cs is a component of the AudioManager gameObject
            instance = this;  
            //instance = (AudioManager)FindObjectOfType(typeof(AudioManager));
            //Don't destroy this AudioManager even if the game is changing scenes. we
            //want the music to continue and not to restart
            DontDestroyOnLoad(gameObject);
        }
        //theresa -source is defined in Sound.cs as the AudioSource which is hidden in inspector.
        //Creating several AudioSource components based on how large sounds array is in inspector.
        //sounds array is part of the AudioManager component which is a prefab.  AudioManager must
        //be placed in each scene.
        //Note: AudioSource components do not have names. name is only in the Sound class
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound)
    {
        //declaring object s and filling it with correct fields by searching sounds array 
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //what's difference between s.source.volume and s.volume? Source is Audiosource in Sound class
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        //THERESA ADD
        if (sound == prevname)
        { 
        //do nothing
        }
        else
        {
            //first time here
            if (prevname == null)
            {
                s.source.Play();
                prevname = sound;
                previousSource = s.source;
            }
            else
            {
                previousSource.Stop();
                s.source.Play();
                prevname = sound;
                previousSource = s.source;
            }
        }

        //s.source.Play();
        // Theresa try  s.source.PlayOneShot(s.source.clip,1.0f);
    }
    
}
 

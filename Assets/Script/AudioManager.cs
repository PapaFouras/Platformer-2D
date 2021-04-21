using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;

    public AudioMixerGroup soundEffectMixer;

    private int musicIndex = 0;

     public static AudioManager instance;

    private void Awake() {
        if(instance != null){
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }
        instance = this;
    
    }
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying){
            PlayNextSong();
        }
        
    }

    void PlayNextSong(){
musicIndex  = (musicIndex + 1)% playlist.Length;
audioSource.clip = playlist[musicIndex];
audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip audioClip, Vector3 pos){
        
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();

        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO,audioClip.length);

        return audioSource;
    }
} 

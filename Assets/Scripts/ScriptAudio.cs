using UnityEngine;

public class ScriptAudio : MonoBehaviour
{
    [SerializeField] private AudioSource musicLevels;
    [SerializeField] private AudioClip[] music;
    
    void Start()
    {
        onRandomMusic();
    }

    public void onRandomMusic()
    {
        int i = Random.Range(0, 1);
        musicLevels.clip = music[i];
        musicLevels.Play();
    }
}

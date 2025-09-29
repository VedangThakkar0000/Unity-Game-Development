using UnityEngine;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [Header("Clips")]
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip reelSpin;
    [SerializeField] private AudioClip winSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }
    public void PlayButton()
    {
        PlaySFX(buttonClick);
    }
    public void PlaySpin()
    {
        if (sfxSource != null && reelSpin != null)
        {
            sfxSource.clip = reelSpin;
            sfxSource.loop = true;  
            sfxSource.Play();
        }
    }
    public void StopSpin()
    {
        if (sfxSource != null && sfxSource.isPlaying)
        {
            sfxSource.loop = false;
            sfxSource.Stop();
        }
    }
    public void PlayWin()
    {
        PlaySFX(winSound);
    }
    private void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
            sfxSource.PlayOneShot(clip);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioClip buttonHoverSound;
    public AudioClip buttonClickSound;
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        PlayMainMenuMusic();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            PlayGameMusic();
        }
        else if (scene.name == "MainMenu")
        {
            PlayMainMenuMusic();
        }
    }

    public void PlayHoverSound()
    {
        if (audioSource != null && buttonHoverSound != null)
        {
            audioSource.PlayOneShot(buttonHoverSound);
        }
    }

    public void PlayClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    public void PlayMainMenuMusic()
    {
        if (audioSource != null && mainMenuMusic != null)
        {
            audioSource.clip = mainMenuMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlayGameMusic()
    {
        if (audioSource != null && gameMusic != null)
        {
            audioSource.clip = gameMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Button backButton;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = volumeSlider.value;

        volumeSlider.onValueChanged.AddListener(SetVolume);
        backButton.onClick.AddListener(BackToMenu);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("newMainMenu");
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public Button backButton;

    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        AudioListener.volume = volumeSlider.value;

        volumeSlider.onValueChanged.AddListener(SetVolume);
        backButton.onClick.AddListener(() => { AudioManager.instance.PlayClickSound(); BackToMenu(); });

        AddHoverEffect(backButton);
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

    void AddHoverEffect(Button button)
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        entry.callback.AddListener((eventData) => { AudioManager.instance.PlayHoverSound(); });
        trigger.triggers.Add(entry);
    }
}

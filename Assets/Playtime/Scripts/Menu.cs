using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;

    void Start()
    {
        startButton.onClick.AddListener(() => { AudioManager.instance.PlayClickSound(); StartGame(); });
        optionsButton.onClick.AddListener(() => { AudioManager.instance.PlayClickSound(); OpenOptions(); });
        exitButton.onClick.AddListener(() => { AudioManager.instance.PlayClickSound(); Quit(); });

        AddHoverEffect(startButton);
        AddHoverEffect(optionsButton);
        AddHoverEffect(exitButton);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    void Quit()
    {
        Application.Quit();
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



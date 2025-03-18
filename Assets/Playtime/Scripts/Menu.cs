using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public Button optionsButton;
    public Button exitButton;


    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        optionsButton.onClick.AddListener(OpenOptions);
        exitButton.onClick.AddListener(Quit);
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
}



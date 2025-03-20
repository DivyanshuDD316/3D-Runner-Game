using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsMenuPanel;
    void Start()
    {
        mainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
    }
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SettingButton()
    {
        mainMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MainMenuButton()
    {
        mainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
    }
}

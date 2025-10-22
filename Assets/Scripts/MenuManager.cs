using UnityEngine;
using UnityEngine.SceneManagement;  // <-- Needed to load other scenes

public class MenuManager : MonoBehaviour
{
    public GameObject homePanel;
    public GameObject settingsPanel;
    public GameObject howToPlayPanel;
    public GameObject aboutPanel;

    private void Start()
    {
        ShowHome();  // Make sure we start with HomePanel active
    }

    // ---------------- Panel Navigation Methods ----------------

    public void ShowHome()
    {
        homePanel.SetActive(true);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        homePanel.SetActive(false);
        settingsPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void ShowHowToPlay()
    {
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void ShowAbout()
    {
        homePanel.SetActive(false);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    // ---------------- Start Game Method ----------------

    public void StartGame()
    {
        // Make sure your game scene is named exactly "GameScene"
        SceneManager.LoadScene("GameScene");
    }

    // ---------------- Exit Game Method ----------------
    public void QuitGame()
    {
        Application.Quit(); // Closes the game in a built application
        Debug.Log("Game has been exited"); // Optional: shows a message in the Editor
    }

}

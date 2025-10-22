using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Enum for choices
    public enum Choice { None, Rock, Paper, Scissors }

    [Header("Choices")]
    public Choice playerChoice = Choice.None;
    public Choice computerChoice = Choice.None;

    [Header("UI Elements")]
    public TextMeshProUGUI playerChoiceText;
    public TextMeshProUGUI computerChoiceText;
    public TextMeshProUGUI resultText;

    [Header("Buttons")]
    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Button shootButton;
    public Button replayButton;

    private void Start()
    {
        // Hide Replay button initially
        replayButton.gameObject.SetActive(false);

        // Button listeners
        rockButton.onClick.AddListener(ChooseRock);
        paperButton.onClick.AddListener(ChoosePaper);
        scissorsButton.onClick.AddListener(ChooseScissors);
        shootButton.onClick.AddListener(OnShoot);
        replayButton.onClick.AddListener(OnReplay);

        // Initialize UI
        ResetUI();
    }

    // ---------------- Player Choice Methods ----------------
    public void ChooseRock() => SetPlayerChoice(Choice.Rock);
    public void ChoosePaper() => SetPlayerChoice(Choice.Paper);
    public void ChooseScissors() => SetPlayerChoice(Choice.Scissors);

    private void SetPlayerChoice(Choice choice)
    {
        if (shootButton.interactable == false) return; // anti-cheat: can't change after Shoot
        playerChoice = choice;
        playerChoiceText.text = "Player: " + choice.ToString();
    }

    // ---------------- Shoot Logic ----------------
    public void OnShoot()
    {
        if (playerChoice == Choice.None) return; // no choice selected

        // Random computer choice
        computerChoice = (Choice)Random.Range(1, 4); // 1 to 3
        computerChoiceText.text = "Computer: " + computerChoice.ToString();

        // Determine winner using switch
        switch (playerChoice)
        {
            case Choice.Rock:
                resultText.text = (computerChoice == Choice.Scissors) ? "You Win!" :
                                  (computerChoice == Choice.Rock) ? "Draw!" : "Computer Wins!";
                break;
            case Choice.Paper:
                resultText.text = (computerChoice == Choice.Rock) ? "You Win!" :
                                  (computerChoice == Choice.Paper) ? "Draw!" : "Computer Wins!";
                break;
            case Choice.Scissors:
                resultText.text = (computerChoice == Choice.Paper) ? "You Win!" :
                                  (computerChoice == Choice.Scissors) ? "Draw!" : "Computer Wins!";
                break;
        }

        // Disable shoot & choice buttons to prevent cheating
        shootButton.interactable = false;
        rockButton.interactable = false;
        paperButton.interactable = false;
        scissorsButton.interactable = false;

        // Show Replay button
        replayButton.gameObject.SetActive(true);
    }

    // ---------------- Replay Logic ----------------
    public void OnReplay()
    {
        // Reset choices
        playerChoice = Choice.None;
        computerChoice = Choice.None;

        // Reset UI
        ResetUI();

        // Enable buttons again
        shootButton.interactable = true;
        rockButton.interactable = true;
        paperButton.interactable = true;
        scissorsButton.interactable = true;

        // Hide Replay button
        replayButton.gameObject.SetActive(false);
    }

    // ---------------- Helper to Reset UI ----------------
    private void ResetUI()
    {
        playerChoiceText.text = "Player: ";
        computerChoiceText.text = "Computer: ";
        resultText.text = "";
    }
}

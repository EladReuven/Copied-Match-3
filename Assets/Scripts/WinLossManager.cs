using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinLossManager : MonoBehaviour 
{
    public GameObject WinImage;
    public GameObject LoseImage;
    public GameObject EndOfRoundButtons;

    public int movesPerLevel = 10;
    public int scoreToWin;

    public static int score = 0;
    public static int movesRemaining = 0;
    public static bool movedThisTurn = false;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI MovesRemainingText;
    [SerializeField] TextMeshProUGUI EndScore;

    private void Awake()
    {
        WinImage.SetActive(false);
        LoseImage.SetActive(false);
        EndOfRoundButtons.SetActive(false);
    }
    private void Start()
    {
        ResetWinLossManager();
    }
    private void Update()
    {
        ScoreText.text = "Score: " + score;
        MovesRemainingText.text = "Moves: " + movesRemaining;
        EndScore.text = $"Score: {score}/{scoreToWin}";
        if(movesRemaining <= 0)
        {
            EndGame();
        }
    }

    public bool Won()
    {
        return score >= scoreToWin;
    }

    public void ResetWinLossManager()
    {
        score = 0;
        movesRemaining = movesPerLevel;
        movedThisTurn = false;
    }

    public void EndGame()
    {
        if (Won())
        {
            WinImage.SetActive(true);
        }
        else
        {
            LoseImage.SetActive(true);
        }
        EndOfRoundButtons.SetActive(true);
    }
}

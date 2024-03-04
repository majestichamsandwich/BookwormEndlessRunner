using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreDisplay;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreDisplay.text = ("score") + gameManager.ScoreDisplay();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreDisplay;

    public GameObject playButton;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnGUI()
    {
        scoreDisplay.text = ("Score: ") + gameManager.ScoreDisplay();
    }
}

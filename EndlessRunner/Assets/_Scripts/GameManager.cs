using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region

    public static GameManager Instance;



    public void Awake()
    {
        if (Instance == null) Instance = this;
    }


    #endregion

    public float currentScore = 0f;

    public bool isPlaying = false;

    public string ScoreDisplay()
    {
        return Mathf.RoundToInt(currentScore).ToString();
    }


    private void Update()
    {
        if(isPlaying == true)
        {
            currentScore += Time.deltaTime;
        }

        if(Input.GetKeyDown("p"))
        {
            isPlaying = true;
        }

    }

    public void GameOver()
    {

    }
}

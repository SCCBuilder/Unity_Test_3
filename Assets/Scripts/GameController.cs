﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;
    private int moveCount;

    public void Awake()
    {
        SetControllerRefernceButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
    }

    public void SetControllerRefernceButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        //Debug.Log("EndTurn metod not made yet.");
        if(buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide)
        {
            GameOver();
        }
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide)
        {
            GameOver();
        }

        moveCount++;

        if(moveCount >= 9)
        {
            SetGameOverText("It's a draw!");
        }
        ChangeSides();
    }

    private void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    private void GameOver()
    {
        Debug.Log("in GameOver method in GameController");
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText(playerSide + " Wins!");
    }

    private void SetGameOverText(string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }
}

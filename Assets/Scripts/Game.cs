using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public static List<Cow> cows = new List<Cow>();

    public GameObject userPanel;
    public GameObject winnerPanel;
    public GameObject firstTurnPanel;
    public GameObject forfeitPanel;

    public TMP_Text playerNameText;
    public TMP_Text playerWinnerText;
    public StringData p1Name;
    public StringData p2Name;
    public StringData winnerName;

    private bool isP1Turn = true;
    int visiableCows;

    private static Game instance = new Game();
    public static Game Instance() 
    {
        return instance; 
    }

    public void OnToGame()
    {
        userPanel.SetActive(true);
        visiableCows = 9;

        if (isP1Turn) playerNameText.text = p1Name;
        if (!isP1Turn) playerNameText.text = p2Name;
    }

    public void OnFinish()
    {
        foreach(Cow c in cows)
        {
            if(c.Type == Cow.eType.Selected)
            {
                c.Type = Cow.eType.Deleted;
                visiableCows--;
            }
        }
        Debug.Log(visiableCows);
        if(visiableCows == 0)
        {
            if (isP1Turn) winnerName = p2Name;
            else winnerName = p1Name;
            winnerPanel.SetActive(true);
            userPanel.SetActive(false);
            playerWinnerText.text = winnerName;
        }

        isP1Turn = !(isP1Turn);
        if (isP1Turn) playerNameText.text = p1Name;
        if (!isP1Turn) playerNameText.text = p2Name;

        Debug.Log(isP1Turn);
    }

    public void OnForfeit()
    {
        forfeitPanel.SetActive(true);
        userPanel.SetActive(false);
    }

    public void OnForfeitNot()
    {
        forfeitPanel.SetActive(false);
        OnToGame();
    }

    public void OnForfeitYes()
    {
        if (isP1Turn) winnerName = p2Name;
        else winnerName = p1Name;
        winnerPanel.SetActive(true);
        userPanel.SetActive(false);
        playerWinnerText.text = winnerName;
    }

    public void AddCow(Cow c)
    {
        cows.Add(c);
    }
}

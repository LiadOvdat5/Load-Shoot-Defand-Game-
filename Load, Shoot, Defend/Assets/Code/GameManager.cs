using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    SceneLoader sceneLoader;

    Enemy enemy;

    Player[] players;

    public static int winningPlayer;
    public int GameEndedTimes;

    // Start is called before the first frame update
    void Start()
    {
        GameEndedTimes = 0;
        sceneLoader = FindObjectOfType<SceneLoader>();

        players = FindObjectsOfType<Player>();
        

        enemy = FindObjectOfType<Enemy>();

        PlayerNum();
    }

    

    public void GameEnded(bool win, int numberOfPlayer)
    {

        if(win == true)
        {
            winningPlayer = numberOfPlayer;
            sceneLoader.LoadGameOverScene();
            return;
        }
        else if(win == false)
        {
            if (players.Length > 1)
            {
                if (numberOfPlayer == 1)
                {
                    players[1].GameWon();
                }
                if (numberOfPlayer == 2)
                {
                    players[0].GameWon();
                }

            }
            if (players.Length == 1)
            {
                if (numberOfPlayer == 0)
                {
                    players[0].GameWon();
                }
                if (numberOfPlayer == 1)
                {
                    enemy.GameWon();
                }

            }

        
        }
        

        GameEndedTimes += 1;

    }


    void PlayerNum()
    {
        
        players[0].playerNum = 1;
        

        if (players.Length > 1)
        {
            players[1].playerNum = 2;
        }
    }
}

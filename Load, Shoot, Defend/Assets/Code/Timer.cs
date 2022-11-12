using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Button shoot1, reload1, defend1, shoot2, reload2, defend2;

    [SerializeField] float startingTime = 5;
    public float currentTime;

    [SerializeField] Text timerText;

    Player[] players;
    Player player, player2;

    

    // Start is called before the first frame update
    void Start()
    {
        players = FindObjectsOfType<Player>();

        if(players.Length == 2)
        {
            player = players[0];
            player2 = players[1];
        }
        if(players.Length == 1)
        {
            player = players[0];
        }

        currentTime = startingTime;

        ButtonsSetActivePlayer1(false);


    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        if (timerText != null && currentTime < 4)
        {
            timerText.text = currentTime.ToString("0");

            if (player.playerChose == false)
            { ButtonsSetActivePlayer1(true); }
            else
            { ButtonsSetActivePlayer1(false); }

            if(player2 != null)
            {
                if (player2.playerChose == false)
                { ButtonsSetActivePlayer2(true); }
                else
                { ButtonsSetActivePlayer2(false); }
            }

        }
        else
        {
            timerText.text = ("");

            ButtonsSetActivePlayer1(false);
            player.playerChose = false;

            if(player2 != null)
            {
                ButtonsSetActivePlayer2(false);
                player2.playerChose = false;
            }

        }
        
        if(((int)currentTime) == 0)
        {
            currentTime = startingTime;
        }
    }


    void ButtonsSetActivePlayer1(bool isActive)
    {
        shoot1.gameObject.SetActive(isActive);
        reload1.gameObject.SetActive(isActive);
        defend1.gameObject.SetActive(isActive);
    }

    void ButtonsSetActivePlayer2(bool isActive)
    {

        shoot2.gameObject.SetActive(isActive);
        reload2.gameObject.SetActive(isActive);
        defend2.gameObject.SetActive(isActive);
    }

    
}

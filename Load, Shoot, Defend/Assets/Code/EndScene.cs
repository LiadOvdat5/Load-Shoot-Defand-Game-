using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndScene : MonoBehaviour
{
    [SerializeField] Text whoWonTXT;
    [SerializeField] Text mainWinTXT;

    int playerWonNum = GameManager.winningPlayer;

    // Start is called before the first frame update
    void Start()
    {
        if (playerWonNum != 0)
        {
            whoWonTXT.text = playerWonNum.ToString("0");
        }
        else
        {
            whoWonTXT.text = "";
            mainWinTXT.text = "Enemy Won";
        }
    }

}

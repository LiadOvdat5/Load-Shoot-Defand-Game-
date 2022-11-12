using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    


    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
    }


    public void LoadPVP()
    {
        SceneManager.LoadScene("PVP");
    }

    public void LoadPVC()
    {
        SceneManager.LoadScene("PVC");
    }


   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Objects of the game
    [SerializeField] Transform shieldPoint, gunPoint, reloadPoint;
    [SerializeField] GameObject gun, reload, shield;
    Timer timer;


    //Enemy choosing system
    bool shoot, load, defend;
    int actionPick;
    bool enemyChose;
    

    //Bullets
    [SerializeField] int bullets;

    //Life
    [SerializeField] int health;
    [SerializeField] GameObject hearthPrefab;
    [SerializeField] Transform heart1Transform, heart2Transform, heart3Transform;
    GameObject heart1, heart2, heart3;
    GameManager gameManager;



    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        bullets = 3;
        enemyChose = false;

        health = 3;
        heart1 = Instantiate(hearthPrefab, heart1Transform.position, transform.rotation) as GameObject;
        heart2 = Instantiate(hearthPrefab, heart2Transform.position, transform.rotation) as GameObject;
        heart3 = Instantiate(hearthPrefab, heart3Transform.position, transform.rotation) as GameObject;

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timer.currentTime > 4 || timer.currentTime < 1)
        {
            Action();
        }

        if(((int)timer.currentTime) == 3 && enemyChose == false)
        {
            RandomChoose();
            enemyChose = true;
        }
        if(((int)timer.currentTime) == 2)
        {
            enemyChose = false;
        }

        if (health == 0)
        {
            Die();
        }
        

    }

    void RandomChoose() //Pick random action (depends also on bullets)
    {
        
        if (bullets > 0)
        {
            actionPick = Random.Range(0, 3);
        }
        if (bullets == 0)
        {
            actionPick = Random.Range(1, 2);
        }

        if (actionPick == 0) { Shoot(); }
        if (actionPick == 1) { Reload(); }
        if (actionPick == 2) { Defend(); }


    }


    public void Shoot()
    {
        if (bullets > 0)
        {
            shoot = true;
            bullets -= 1;
        }
    }

    public void Reload()
    {
        load = true;
    }

    public void Defend()
    {
        defend = true;
    }


    void Action()
    {
        if (shoot == true)
        {
            GameObject myGun = Instantiate(gun, gunPoint.position, gunPoint.rotation) as GameObject;
            Destroy(myGun, 2f);
            shoot = false;
        }

        if (load == true)
        {
            GameObject myLoad = Instantiate(reload, reloadPoint.position, reloadPoint.rotation) as GameObject;
            Destroy(myLoad, 2f);
            load = false;
            bullets += 1;
        }

        if (defend == true)
        {
            GameObject myShield = Instantiate(shield, shieldPoint.position, shieldPoint.rotation) as GameObject;
            Destroy(myShield, 2f);
            defend = false;
        }
    }


    public void GotHit()
    {
        if (health == 3) Destroy(heart1);
        if (health == 2) Destroy(heart2);
        if (health == 1) Destroy(heart3);
        health -= 1;

    }

    void Die()
    {
        gameManager.GameEnded(false, 0);
        Destroy(gameObject);
        //Do Game end in Game manager (Print you Lose/win and Load next screen)

    }
    public void GameWon()
    {
        gameManager.GameEnded(true, 0);
        Destroy(gameObject);
    }

}

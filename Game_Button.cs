using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Button : MonoBehaviour
{
    public void RestartLevel()
    {
        Application.LoadLevel(1);
        //PlayerController.PlayerDead = false;
       // coll.GetComponent<Enemy>().EnemyDead = false;
        //ColisionDamage.colDamage = false;

    }

    public void GoToMenu()
    {
        Application.LoadLevel(0);
        //PlayerController.PlayerDead = false;
      //  coll.GetComponent<Enemy>().EnemyDead = false;
       // ColisionDamage.colDamage = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerShip : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject gameOverUI;
    public GameObject wonUI;

    public void EndGame() 
    {
        // Hvis spillet ikke allerede er stoppet, fordi man er d�d stoppes spillet og gameover sk�rmbilledet kommer frem  
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            gameOverUI.SetActive(true);
        }
    }
    // Hvis spillet er vundet kommer sk�rmbilledet op hvor man kan komme videre i spillet 
    
    public void CompleteLevel()
    {
        wonUI.SetActive(true);
    }



}

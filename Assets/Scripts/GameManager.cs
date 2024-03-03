using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        numEnemies = 0;
    }

    public void addEnemy()
    {
        numEnemies++;
    }

    public void killEnemy()
    {
        numEnemies--;
        if (numEnemies == 0) {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int connectedPieces = 0;
    private int gameLevel = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (connectedPieces == 2 && gameLevel != 3)
        {
            connectedPieces = 0;
            gameLevel++;
            
            loadLevel(gameLevel);
        }

        if (gameLevel == 3 && connectedPieces == 2)
        {
            connectedPieces = 0;
            gameLevel = 1;

            loadLevel(gameLevel);
        }
    }

    void loadLevel(int level)
    {
        SceneManager.LoadScene(level.ToString());
    }

    public void addPiece()
    {
        connectedPieces++;
    }
}

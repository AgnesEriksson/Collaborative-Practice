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
        if (connectedPieces == 3 && gameLevel != 3 && SceneManager.GetActiveScene().buildIndex != 4)
        {
            connectedPieces = 0;
            gameLevel++;

            StartCoroutine(loadLevel(gameLevel));
        }

        if (gameLevel == 3 && connectedPieces == 3)
        {
            connectedPieces = 0;
            gameLevel = 1;

            SceneManager.LoadScene("EndMenu");
        }
    }

    IEnumerator loadLevel(int level)
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("FactScreen");

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene(level.ToString());
    }

    public void addPiece()
    {
        connectedPieces++;
    }
}

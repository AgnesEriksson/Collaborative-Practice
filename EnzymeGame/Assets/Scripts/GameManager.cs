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

    public float timeoutTime = 60f;
    private float lastInputTime;

    private void Start()
    {
        lastInputTime = Time.time;
    }

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
        // Check if the player has been inactive for a certain amount of time
        if (Input.anyKey || Input.anyKeyDown || Input.mousePosition != new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0))
        {
            lastInputTime = Time.time;
        }

        if (Time.time - lastInputTime > timeoutTime)
        {
            connectedPieces = 0;
            gameLevel = 1;

            SceneManager.LoadScene("MainMenu");
        }

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
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("FactScreen");

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(level.ToString());
    }

    public void addPiece()
    {
        connectedPieces++;
    }
}

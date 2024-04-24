using System.Collections;
using System.Collections.Generic;
using System.Threading;
/*using UnityEditor.SearchService;*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int connectedPieces = 0;
    private int gameLevel = 1;

    float elapsedTimer;
    bool inputtrue;

    private void Start()
    {
      
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
        inputtrue = false;
        if (Input.anyKey || Input.anyKeyDown || Input.mousePosition != new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0))
        {
            inputtrue = true;
        }
        Debug.Log(elapsedTimer);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (elapsedTimer >= 30f && SceneManager.GetActiveScene().buildIndex != 0)
        {
            elapsedTimer = 0;
            StartCoroutine(timeOut());

        }

        if (connectedPieces == 3 && gameLevel != 3 && SceneManager.GetActiveScene().buildIndex != 4)
        {
            connectedPieces = 0;
            gameLevel++;

            StartCoroutine(loadLevel(gameLevel));
        }

        if (gameLevel == 3 && connectedPieces == 3)
        {
                StartCoroutine(end());

        }
        if (SceneManager.GetActiveScene().buildIndex != 0 && !inputtrue)
        {

            elapsedTimer += Time.deltaTime;
        }
        else
        {
            elapsedTimer = 0;
        }
    }

    IEnumerator loadLevel(int level)
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("FactScreen");

        yield return new WaitForSeconds(7);

        SceneManager.LoadScene(level.ToString());
    }

    IEnumerator end()
    {

        connectedPieces = 0;
        gameLevel = 1;

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("EndMenu");

    }

    IEnumerator timeOut()
    {

        connectedPieces = 0;
        gameLevel = 1;

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenu");

    }

    public void addPiece()
    {
        connectedPieces++;
    }
}

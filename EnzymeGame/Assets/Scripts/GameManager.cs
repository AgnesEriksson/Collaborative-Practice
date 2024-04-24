using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int connectedPieces = 0;
    private int gameLevel = 1;

    public float timeoutTime = 5f;

    float Timer;
    bool functionran = false;

    private void Start()
    {
        Timer = Time.realtimeSinceStartup;
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

/*    IEnumerator CheckIdleTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (Time.time - lastInputTime >= timeoutTime)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        // Check if the player has been inactive for a certain amount of time
        if (Input.anyKey || Input.anyKeyDown || Input.mousePosition != new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0))
        {
            
            Timer = Time.realtimeSinceStartup;
        }
        
        if (Time.realtimeSinceStartup - Timer >= 5f)
        {
            /*            connectedPieces = 0;
                        gameLevel = 1;

                        SceneManager.LoadScene("MainMenu");*/
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
            if (!functionran)
            {
                functionran = true;
                StartCoroutine(end());
            }

        }
    }

    IEnumerator loadLevel(int level)
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("FactScreen");

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene(level.ToString());
    }

    IEnumerator end()
    {

        connectedPieces = 0;
        gameLevel = 1;

        yield return new WaitForSeconds(1);
/*        functionran = false;*/
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

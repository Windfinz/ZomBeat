using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [Header("StopWatch")]
    public float stopwatchTime;
    public TMP_Text timeDisplay;

    [Header("Points")]
    public TMP_Text scoreText;
    public TMP_Text hiScoreText;
    public TMP_Text winHiScoreText;
    public TMP_Text loseHiScoreText;
    public int score;

    [Header("Win and Lose")]
    public GameObject Win;
    public GameObject Lose;

    public FirstPersonCamera camera;
    public GameObject pauseGame;
    public GameObject time;

    private bool isPause = false;
    private bool isStop = false;

    private void Start()
    {
        isStop = false;
        Win.SetActive(false);
        Lose.SetActive(false);
        pauseGame.SetActive(false);
        camera = FindObjectOfType<FirstPersonCamera>();
        SetScore(0);
        hiScoreText.text = LoadHiscore().ToString();
        time.SetActive(true);


    }

    private void Update()
    {
        UpdateStopwatch();
        UpdateStopwatchDisplay();

        Pause();
        if (!isStop)
        {
            if (isPause)
            {
                camera.UnlockCursor();
            }
            else
            {
                camera.lockCursor();
            }

        }
        winHiScoreText.text = score.ToString();
        loseHiScoreText.text = score.ToString();
    }

    void UpdateStopwatch()
    {
        if (stopwatchTime > 0)
        {
            stopwatchTime -= Time.deltaTime;
        }

        if (stopwatchTime <= 0)
        {
            Time.timeScale = 0f;
            WinGame();
        }
    }
    void UpdateStopwatchDisplay()
    {
        int minutes = Mathf.FloorToInt(stopwatchTime / 60);
        int seconds = Mathf.FloorToInt(stopwatchTime % 60);

        timeDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void WinGame()
    {
        isStop = true;
        time.SetActive(false);
        camera.UnlockCursor();
        Win.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoseGame()
    {
        isStop = true;
        time.SetActive(false);
        camera.UnlockCursor();
        Lose.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NewGame()
    {
        Win.SetActive(false);
        Lose.SetActive(false);
        pauseGame.SetActive(false);
        Time.timeScale = 1f;
        hiScoreText.text = LoadHiscore().ToString();
        camera.lockCursor();
        SetScore(0);
        SceneManager.LoadScene("Round-1");

    }
    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            //camera.UnlockCursor();
            Time.timeScale = isPause ? 0f : 1f;
            pauseGame.SetActive(isPause);
        }
        
    }
    public void Continue()
    {
        isStop=false;
        camera.lockCursor();
        pauseGame.SetActive(false);
        Time.timeScale = 1f;
    }

    public void InscreaseScore()
    {
        SetScore(score + 5);

    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();

        SaveHiscore();
    }

    private void SaveHiscore()
    {
        int hiscore = LoadHiscore();

        if (score > hiscore)
        {
            PlayerPrefs.SetInt("hiscore", score);
        }
    }
    private int LoadHiscore()
    {
        return PlayerPrefs.GetInt("hiscore", 0);
    }
}

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject leaderboardMenu;
    [SerializeField] private Image crossfade;
    [SerializeField] private int nextLevelindex = 0;
    void Start()
    {
        gameOverMenu.SetActive(false);
        leaderboardMenu.SetActive(false);
        crossfade.CrossFadeAlpha(0, 1f, true);
    }

    public void RetryLevel()
    {
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnEnable()
    {
        FlagEvents.raceEnd += EnableGameOverUI;
        FlagEvents.Quit += Quit;
    }

    private void OnDisable()
    {
        FlagEvents.raceEnd -= EnableGameOverUI;
        FlagEvents.Quit -= Quit;
    }

    public void QuitButton()
    {
        FlagEvents.CallQuit();
    }

    private void EnableGameOverUI()
    {
        gameOverMenu.SetActive(true);
        leaderboardMenu.SetActive(true);
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCoroutine());
    }

    private IEnumerator NextLevelCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextLevelindex);
    }

    private void Quit()
    {
        StartCoroutine(QuitCoroutine());
    }

    private IEnumerator QuitCoroutine()
    {
        crossfade.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(1);
        Application.Quit();

    }
}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> timeTexts = new();
    private List<float> bestTimes = new();
    private string scenePrefix;

    private void Awake()
    {
        // Use the scene name as a prefix for PlayerPrefs keys
        scenePrefix = SceneManager.GetActiveScene().name + "_";

        bestTimes.Clear();

        // Load top 5 times for this scene
        for (int i = 0; i < 5; i++)
        {
            bestTimes.Add(PlayerPrefs.GetFloat(scenePrefix + "time" + i, 9999999));
        }

        UpdateLeaderboardUI();
    }

    public void AddTime(float time)
    {
        bestTimes.Add(time);
        bestTimes.Sort(); // Smallest (fastest) times at the top
        SaveData();
        UpdateLeaderboardUI();
    }

    private void SaveData()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < bestTimes.Count)
                PlayerPrefs.SetFloat(scenePrefix + "time" + i, bestTimes[i]);
        }

        PlayerPrefs.Save();
    }

    private void UpdateLeaderboardUI()
    {
        for (int i = 0; i < timeTexts.Count; i++)
        {
            if (i < bestTimes.Count)
            {
                timeTexts[i].text = FormatTime(bestTimes[i]);
            }
            else
            {
                timeTexts[i].text = "---";
            }
        }
    }

    private string FormatTime(float time)
    {
        if (time >= 9999999) return "---";
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return $"{minutes:00}:{seconds:00}.{milliseconds:000}";
    }
}
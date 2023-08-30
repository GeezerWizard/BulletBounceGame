using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    bool paused = false;
    float timeElapsed = 0f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI endGameText;


    private void Start() 
    {
        GameEvents.current.onPlayerDeath += StopCount;
        GameEvents.current.onGameStart += StartCount;
    }

    private void OnDestroy()
    {
        GameEvents.current.onPlayerDeath -= StopCount;
        GameEvents.current.onGameStart -= StartCount;
    }

    private void StopCount()
    {
        paused = true;
        endGamePanel.SetActive(true);
        StopCoroutine(CountTime());
    }

    private void StartCount()
    {
        paused = false;
        endGamePanel.SetActive(false);
        ResetTimer();
        StartCoroutine(CountTime());
    }

    private void ResetTimer()
    {
        timeElapsed = 0f;
    }

    IEnumerator CountTime()
    {
        while(true)
        {
            if(!paused)
            {
                timeElapsed += Time.deltaTime;
            }
            scoreText.text = timeElapsed.ToString();
            yield return null;
        }
    }
    public void SetEndGameText(string tag)
    {
        if (tag == "Enemy")
        {
            endGameText.text = "\"Got Caught in the Tide\"";
        }
        if (tag == "Bullet")
        {
            endGameText.text = "\"Too Big for your own Boots\"";
        }
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    public Bat player;
    private int points;
    private int highScore;
    public TextMeshProUGUI pointstext;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI newHighScoreText;
    public GameObject playbutton;
    public GameObject gameoverbruh;
    public GameObject getready;
    //public AudioSource audioSource;
    //public AudioClip newHighScoreClip;
    private void Awake()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        

        if (highScoreText != null)
            highScoreText.text = "High Score: " + highScore.ToString();

        if (newHighScoreText != null)
            newHighScoreText.gameObject.SetActive(false);
        gameoverbruh.SetActive(false);
        pause();
    }
    public void play()
    {
        points = 0;
        pointstext.text = points.ToString();
        pointstext.gameObject.SetActive(true);
        getready.SetActive(false);
        playbutton.SetActive(false);
        gameoverbruh.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        Spikes[] spikes = FindObjectsByType<Spikes>(FindObjectsSortMode.None);
        for (int i = 0; i < spikes.Length; i++)
        {
            Destroy(spikes[i].gameObject);
        }
    }
    public void pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void pluspoints()
    {
        points++;
        pointstext.text = points.ToString();
        
    }
    public void gameover()
    {
        gameoverbruh.SetActive(true);
        playbutton.SetActive(true);
        pause();
        if (points > highScore)
        {
            highScore = points;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            if (highScoreText != null)
                highScoreText.text = "High Score: " + highScore.ToString();

            if (newHighScoreText != null)
                newHighScoreText.gameObject.SetActive(true);

            //if (audioSource != null && newHighScoreClip != null)
            //    audioSource.PlayOneShot(newHighScoreClip);
            StartCoroutine(ShowNewHighScorePopup());
        }
        else
        {
            if (newHighScoreText != null)
                newHighScoreText.gameObject.SetActive(false);
        }
    }
    IEnumerator ShowNewHighScorePopup()
    {
        if (newHighScoreText == null)
            yield break;

        newHighScoreText.gameObject.SetActive(true);
        newHighScoreText.alpha = 0f;
            
        newHighScoreText.transform.localScale = Vector3.one * 1.5f;

        float duration = 0.5f;
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            float normalized = t / duration;
            newHighScoreText.alpha = Mathf.Lerp(0f, 1f, normalized);
            newHighScoreText.transform.localScale =
                Vector3.Lerp(Vector3.one * 1.5f, Vector3.one, normalized);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(0.5f);

        t = 0f;
        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            float normalized = t / duration;
            newHighScoreText.alpha = Mathf.Lerp(1f, 0f, normalized);
            yield return null;
        }

        newHighScoreText.gameObject.SetActive(false);
    }

}

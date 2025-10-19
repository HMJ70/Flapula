using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GManager : MonoBehaviour
{
    public Bat player;
    private int points;
    public TextMeshProUGUI pointstext;
    public GameObject playbutton;
    public GameObject gameoverbruh;
    private void Awake()
    {
        gameoverbruh.SetActive(false);
        pause();
    }
    public void play()
    {
        points = 0;
        pointstext.text = points.ToString();
        pointstext.gameObject.SetActive(true);
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
    }
}

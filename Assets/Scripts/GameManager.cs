using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public GameObject player;
    public Transform spawnPoint;
    public PlayerController playerController;
    int score;
    public TextMeshProUGUI scoreText;
    public GameObject playBtn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playBtn.SetActive(true);
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        score = playerController.score;
        Debug.Log(score);
        scoreText.text = score.ToString();
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    public void GameStart()
    {
        player.SetActive(true);
        playBtn.SetActive(false);
        StartCoroutine("SpawnObstacles");
    }
    
}

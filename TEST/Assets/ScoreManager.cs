using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int redMissCount = 0;
    public int greenMissCount = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text redText;
    [SerializeField] private Text greenText;

    private void Awake()
    {
        score = 0;
        redMissCount = 0;
        greenMissCount = 0;
        ChangeScore();
    }

    public void ChangeScore()
    {
        scoreText.text = $"score: {score.ToString()}";
        redText.text = $": {redMissCount.ToString()}";
        greenText.text = $": {greenMissCount.ToString()}";
    }
}

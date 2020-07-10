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
        if(scoreText != null)
        {
            scoreText.text = $"score: {score.ToString()}";
        }
        if(redText != null)
        {
            redText.text = $": {redMissCount.ToString()}";
        }
        if(greenText != null)
        {
            greenText.text = $": {greenMissCount.ToString()}";
        }
        
    }
}

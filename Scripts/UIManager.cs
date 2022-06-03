using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;
    [SerializeField] private Text ScoreText;
    private int Score = 0;
    void Start()
    {
        instance = this;
        ScoreText.text = Score.ToString();
    }
 
    public void UpdateSCore()
    {
        Score += 10;
        SoundManager.Instance.PlayScoreUpdateSfx();
        ScoreText.text = Score.ToString();
    }
    
}

using _Scripts.Manager;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;  
    public static UIManager Instance
    {
        get { return _instance; }
    }

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _bestScore;


    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        _scoreText.text = $"Score:{GameManager.Instance.Score}";
        _bestScore.text = $"Best:{GameManager.Instance.BestScore}";

        
    }

}


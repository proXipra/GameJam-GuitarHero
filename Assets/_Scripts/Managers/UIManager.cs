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

    [SerializeField] public TextMeshProUGUI _pInput;
    [SerializeField] public TextMeshProUGUI _sInput;
    [SerializeField] public TextMeshProUGUI _tInput;
    [SerializeField] public TextMeshProUGUI _qInput;


    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        _scoreText.text = $"Score:{GameManager.Instance.score}";
        _bestScore.text = $"Best:{GameManager.Instance.BestScore}";

        
    }

}


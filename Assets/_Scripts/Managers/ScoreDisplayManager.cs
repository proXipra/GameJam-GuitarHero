using TMPro;
using UnityEngine;

namespace _Scripts.Manager
{
    public class ScoreDisplayManager : MonoBehaviour
    {
        private TextMeshProUGUI Text => _text ??= GetComponent<TextMeshProUGUI>();
        private TextMeshProUGUI _text;

        private void Start()
        {
            InvokeRepeating(nameof(UpdateScoreDisplay), 1, 0.05f);
        }

        private void UpdateScoreDisplay()
        {
            Text.text = $"{GameManager.Instance.score}";
            // Debug.Log(GameManager.Instance.score);
        }
    }
}
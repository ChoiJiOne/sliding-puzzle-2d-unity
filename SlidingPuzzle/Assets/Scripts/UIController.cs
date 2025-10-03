using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private TextMeshProUGUI _playTimeText;
    [SerializeField] private TextMeshProUGUI _moveCountText;
    [SerializeField] private Board _board;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    public void OnResultPanel()
    {
        _resultPanel.SetActive(true);

        _playTimeText.text = $"PLAY TIME: {_board.PlayTime / 60:D2}:{_board.PlayTime % 60:D2}";
        _moveCountText.text = $"MOVE COUNT: {_board.MoveCount}";
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public int Numeric
    {
        get => _numeric;
        set
        {
            _numeric = value;
            _numericText.text = $"{_numeric}";
        }
    }
    public Vector3 LocalPosition => _rectTransform.localPosition;
    public bool IsCorrected { private set; get; }

    [SerializeField] private TextMeshProUGUI _numericText;
    [SerializeField] private Image _numericImage;
    [SerializeField] private RectTransform _rectTransform;

    private Board _board;
    private Vector3 _correctPosition;
    private int _numeric;

    public void Setup(Board board, int hideNumeric, int numeric)
    {
        _board = board;

        Numeric = numeric;
        if (numeric == hideNumeric)
        {
            _numericImage.enabled = false;
            _numericText.enabled = false;
        }
    }

    public void SetCorrectPosition()
    {
        _correctPosition = _rectTransform.localPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _board.IsMoveTile(this);
    }

    public void OnMoveTo(Vector3 end)
    {
        StartCoroutine(nameof(MoveTo), end);
    }

    private IEnumerator MoveTo(Vector3 end)
    {
        float current = 0.0f;
        float percent = 0.0f;
        float moveTime = 0.1f;

        Vector3 startPosition = _rectTransform.localPosition;
        while (percent < 1.0f)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            _rectTransform.localPosition = Vector3.Lerp(startPosition, end, percent);

            yield return null;
        }

        IsCorrected = (_correctPosition == _rectTransform.localPosition);

        _board.IsGameOver();
    }
}

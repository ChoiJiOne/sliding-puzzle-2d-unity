using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberSlotView : MonoBehaviour
{
    public int Number => _number;
    public Vector3 LocalPosition => _rectTransform.localPosition;
    public bool IsCorrected => _correctPosition == _rectTransform.localPosition;

    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private Image _numberBgImage;
    [SerializeField] private RectTransform _rectTransform;

    private int _number = 0;
    private Vector3 _correctPosition;

    public void Bind(int number, int hideNumber)
    {
        _number = number;
        _numberText.text = $"{number}";
        _correctPosition = _rectTransform.localPosition;

        bool isHide = (number == hideNumber);
        _numberText.enabled = !isHide;
        _numberBgImage.enabled = !isHide;
    }
}

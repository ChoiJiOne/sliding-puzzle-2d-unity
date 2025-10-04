using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberSlotView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberText;
    [SerializeField] private Image _numberBgImage;
    [SerializeField] private RectTransform _rectTransform;

    private int _number = 0;

    public void Bind(int number, int hideNumber)
    {
        _number = number;
        _numberText.text = $"{number}";

        if (number == hideNumber)
        {
            _numberText.enabled = false;
            _numberBgImage.enabled = false;
        }
    }
}

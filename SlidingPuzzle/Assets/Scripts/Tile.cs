using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
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

    [SerializeField] private TextMeshProUGUI _numericText;
    [SerializeField] private Image _numericImage;

    private int _numeric;

    public void Setup(int hideNumeric, int numeric)
    {
        Numeric = numeric;
        if (numeric == hideNumeric)
        {
            _numericImage.enabled = false;
            _numericText.enabled = false;
        }
    }
}

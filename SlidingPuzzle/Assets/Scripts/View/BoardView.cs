using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private NumberSlotView _numberSlotViewPrefab;

    [SerializeField, Range(3, 6)] private int _rowSize;
    [SerializeField, Range(3, 6)] private int _colSize;

    private List<NumberSlotView> _numberSlotViewList = new();
    
    private void Awake()
    {
        int count = _rowSize * _colSize;
        for (int number = 1; number <= count; ++number)
        {
            var numberSlotView = Instantiate(_numberSlotViewPrefab, _rectTransform);
            numberSlotView.Bind(number, count);
            _numberSlotViewList.Add(numberSlotView);
        }
    }
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        if (_gridLayoutGroup == null || _rectTransform == null)
        {
            Debug.Log("INVALID_BOARD_VIEW_REFERENCE");
            return;
        }

        float width = _gridLayoutGroup.cellSize.x * _colSize + _gridLayoutGroup.spacing.x * (_colSize + 1);
        float height = _gridLayoutGroup.cellSize.y * _rowSize + _gridLayoutGroup.spacing.y * (_rowSize + 1);

        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
    }
#endif
}
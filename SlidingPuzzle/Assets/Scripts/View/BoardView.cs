using UnityEngine;
using UnityEngine.UI;

public class BoardView : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField, Range(3, 6)] private int _rowSize;
    [SerializeField, Range(3, 6)] private int _colSize;

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
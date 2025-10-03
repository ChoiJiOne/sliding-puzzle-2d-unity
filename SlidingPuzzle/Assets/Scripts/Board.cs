using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private RectTransform _tilesParent;

    private Vector2Int _puzzleSize = new Vector2Int(4, 4);

    private void Awake()
    {
        SpawnTiles();
    }

    private void SpawnTiles()
    {
        for (int y = 0; y < _puzzleSize.y; ++y)
        {
            for (int x = 0; x < _puzzleSize.x; ++x)
            {
                Instantiate(_tilePrefab, _tilesParent);
            }
        }
    }
}

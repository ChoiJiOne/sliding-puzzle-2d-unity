using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private RectTransform _tilesParent;

    private Vector2Int _puzzleSize = new Vector2Int(4, 4);
    private List<Tile> _tileList = new();

    private void Awake()
    {
        SpawnTiles();
        StartCoroutine(nameof(OnSuffle));
    }

    private void SpawnTiles()
    {
        for (int y = 0; y < _puzzleSize.y; ++y)
        {
            for (int x = 0; x < _puzzleSize.x; ++x)
            {
                Tile tile = Instantiate(_tilePrefab, _tilesParent);
                _tileList.Add(tile);
                tile.Setup(_puzzleSize.x * _puzzleSize.y, y * _puzzleSize.x + x + 1);
            }
        }
    }

    private IEnumerator OnSuffle()
    {
        float current = 0.0f;
        float percent = 0.0f;
        float time = 1.5f;

        while (percent < 1.0f)
        {
            current += Time.deltaTime;
            percent = current / time;

            int index = Random.Range(0, _puzzleSize.x * _puzzleSize.y);
            _tileList[index].transform.SetAsLastSibling();

            yield return null;
        }
    }
}

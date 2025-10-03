using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public Vector3 EmptyTilePosition { get; set; }

    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private RectTransform _tilesParent;

    private Vector2Int _puzzleSize = new Vector2Int(4, 4);
    private List<Tile> _tileList = new();
    private float _neighborTileDistance = 102.0f;

    private IEnumerator Start()
    {
        SpawnTiles();

        LayoutRebuilder.ForceRebuildLayoutImmediate(_tilesParent);

        yield return new WaitForEndOfFrame();
        _tileList.ForEach(x => x.SetCorrectPosition());

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
                tile.Setup(this, _puzzleSize.x * _puzzleSize.y, y * _puzzleSize.x + x + 1);
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

        EmptyTilePosition = _tileList[_tileList.Count - 1].LocalPosition;
    }

    public void IsMoveTile(Tile tile)
    {
        if (Vector3.Distance(EmptyTilePosition, tile.LocalPosition) == _neighborTileDistance)
        {
            Vector3 goalPosition = EmptyTilePosition;
            EmptyTilePosition = tile.LocalPosition;
            tile.OnMoveTo(goalPosition);
        }
    }

    public void IsGameOver()
    {
        List<Tile> tiles = _tileList.FindAll(x => x.IsCorrected);
        if (tiles.Count == _puzzleSize.x * _puzzleSize.y - 1)
        {
            Debug.Log("GameClear");
        }
    }
}

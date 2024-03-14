using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapTileReplace : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] targetTiles; // Массив исходных тайлов
    public TileBase[] replacementTiles; // Массив заменяемых тайлов
    public float initialRadius = 1f;
    public int radiusIncreaseRate = 1;
    public Vector3Int centerTilePosition;
    public float replacementSpeed = 1f; // Скорость распространения замены тайлов

    private float timer = 0f;
    private int currentRadius = 1;

    void Update()
    {
        timer += Time.deltaTime;

        // Если прошло время, обновляем замену тайлов
        if (timer >= 1f / replacementSpeed)
        {
            currentRadius +=radiusIncreaseRate;
            ReplaceTiles();
            timer = 0f;
        }
    }

    void ReplaceTiles()
    {
        // Получаем все ячейки с текущим радиусом вокруг центрального тайла
        List<Vector3Int> cellsToCheck = GetCellsInRadius(currentRadius);

        foreach (var cell in cellsToCheck)
        {
            TileBase currentTile = tilemap.GetTile(cell);

            // Проверяем каждый исходный тайл
            for (int i = 0; i < targetTiles.Length; i++)
            {
                if (currentTile == targetTiles[i])
                {
                    // Если текущий тайл совпадает с одним из исходных тайлов, заменяем его на соответствующий ему заменяемый тайл
                    tilemap.SetTile(cell, replacementTiles[i]);
                    break; // Прерываем цикл, так как мы уже нашли совпадение
                }
            }
        }
    }

    List<Vector3Int> GetCellsInRadius(int radius)
    {
        List<Vector3Int> cells = new List<Vector3Int>();

        for (int x = -radius; x <= radius; x++)
        {
            for (int y = -radius; y <= radius; y++)
            {
                Vector3Int currentCell = new Vector3Int(centerTilePosition.x + x, centerTilePosition.y + y, centerTilePosition.z);
                cells.Add(currentCell);
            }
        }

        return cells;
    }
}

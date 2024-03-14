using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TilemapTileReplace : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] targetTiles; // ������ �������� ������
    public TileBase[] replacementTiles; // ������ ���������� ������
    public float initialRadius = 1f;
    public int radiusIncreaseRate = 1;
    public Vector3Int centerTilePosition;
    public float replacementSpeed = 1f; // �������� ��������������� ������ ������

    private float timer = 0f;
    private int currentRadius = 1;

    void Update()
    {
        timer += Time.deltaTime;

        // ���� ������ �����, ��������� ������ ������
        if (timer >= 1f / replacementSpeed)
        {
            currentRadius +=radiusIncreaseRate;
            ReplaceTiles();
            timer = 0f;
        }
    }

    void ReplaceTiles()
    {
        // �������� ��� ������ � ������� �������� ������ ������������ �����
        List<Vector3Int> cellsToCheck = GetCellsInRadius(currentRadius);

        foreach (var cell in cellsToCheck)
        {
            TileBase currentTile = tilemap.GetTile(cell);

            // ��������� ������ �������� ����
            for (int i = 0; i < targetTiles.Length; i++)
            {
                if (currentTile == targetTiles[i])
                {
                    // ���� ������� ���� ��������� � ����� �� �������� ������, �������� ��� �� ��������������� ��� ���������� ����
                    tilemap.SetTile(cell, replacementTiles[i]);
                    break; // ��������� ����, ��� ��� �� ��� ����� ����������
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

using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;

public class TilemapEraser : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3Int startPoint;
    public float initialRadius = 1f;
    public float increaseRate = 1f; // количество единиц, на которое увеличивается радиус каждую секунду
    public float timer = 5f;

    private float currentRadius;

    void Start()
    {
        currentRadius = initialRadius;
        
    }

    IEnumerator EraseTilesWithIncreasingRadius()
    {
        while (true)
        {
            EraseTilesInCircle(startPoint, Mathf.RoundToInt(currentRadius));
            //currentRadius += increaseRate;
            currentRadius += 1;
            yield return new WaitForSeconds(timer);
        }
    }

    void EraseTilesInCircle(Vector3Int start, int radius)
    {
        Queue<Vector3Int> queue = new Queue<Vector3Int>();
        HashSet<Vector3Int> visited = new HashSet<Vector3Int>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            Vector3Int current = queue.Dequeue();

            if (!visited.Contains(current) && IsWithinCircle(start, radius, current))
            {
                tilemap.SetTile(current, null);

                visited.Add(current);

                Vector3Int[] neighbors = GetNeighbors(current);

                foreach (Vector3Int neighbor in neighbors)
                {
                    queue.Enqueue(neighbor);
                }
            }
        }
    }

    bool IsWithinCircle(Vector3Int center, int radius, Vector3Int point)
    {
        return (point - center).magnitude <= radius;
    }

    Vector3Int[] GetNeighbors(Vector3Int point)
    {
        return new Vector3Int[]
        {
            new Vector3Int(point.x + 1, point.y, point.z),
            new Vector3Int(point.x - 1, point.y, point.z),
            new Vector3Int(point.x, point.y + 1, point.z),
            new Vector3Int(point.x, point.y - 1, point.z)
        };
    }

    public void StartEraser()
    {
        StartCoroutine(EraseTilesWithIncreasingRadius());
    }
}
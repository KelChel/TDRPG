using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Массивы точек для каждого пути
    public Transform[] path1Points;
    public Transform[] path2Points;

    // Метод для получения точек определенного пути
    public Transform[] GetWaypoints(int pathNumber)
    {
        return pathNumber switch
        {
            1 => path1Points,
            2 => path2Points,
            // Добавьте case для других путей при необходимости
            _ => path1Points,// По умолчанию вернуть путь 1
        };
    }
}
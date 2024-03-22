using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // ������� ����� ��� ������� ����
    public Transform[] path1Points;
    public Transform[] path2Points;

    // ����� ��� ��������� ����� ������������� ����
    public Transform[] GetWaypoints(int pathNumber)
    {
        return pathNumber switch
        {
            1 => path1Points,
            2 => path2Points,
            // �������� case ��� ������ ����� ��� �������������
            _ => path1Points,// �� ��������� ������� ���� 1
        };
    }
}
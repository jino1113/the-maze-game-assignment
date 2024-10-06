using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public int width = 10;  // �������ҧ�ͧ Grid
    public int height = 10; // �����٧�ͧ Grid
    public List<GameObject> tilePrefabs; // List ����Ѻ�� prefab ���µ��
    public float tileSpacing = 1.1f; // ������ҧ�����ҧ���� Tile

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // �ٻ����ӹǹ���ҧ����٧�ͧ Grid
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // ���͡ prefab Ẻ�����ҡ List
                GameObject randomPrefab = tilePrefabs[Random.Range(0, tilePrefabs.Count)];

                // �ӹǳ���˹觷����ҧ prefab
                Vector3 position = new Vector3(x * tileSpacing, 0, y * tileSpacing);

                // ���ҧ Tile �ҡ prefab Ẻ����㹵��˹觷��ӹǳ��
                Instantiate(randomPrefab, position, Quaternion.identity);
            }
        }
    }
}

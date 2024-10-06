using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public int X = 10; // �������ҧ�ͧ Maze
    public int Z = 10; // �����٧�ͧ Maze
    public float tileSpacing = 1.0f; // ������ҧ�����ҧ tiles
    public GameObject wallPrefab; // Prefab ����Ѻ��ᾧ
    public float boundarySpacing = 0.01f; // ������ҧ�ͧ��ᾧ
    public float wallHeight = 3.0f; // �����٧�ͧ��ᾧ
    public float wallThickness = 0.5f; // ����˹Ңͧ��ᾧ
    public GameObject exitPrefab; // Prefab ����Ѻ�ش�ҧ�͡
    public bool[,] grid; // ���������Ѻ��ʶҹТͧ Maze

    private GameObject player; // ���������Ѻ�纼�����
    private int exitX; // ���������Ѻ���˹� X �ͧ exit
    private int exitY; // ���������Ѻ���˹� Y �ͧ exit

    void Start()
    {
        grid = new bool[X, Z]; // ��˹���Ҵ�ͧ grid
        CreateBoundaryWalls();
        CreateExit(); // ���¡��ѧ��ѹ���ҧ�ش�ҧ�͡
    }

    void DrawMaze()
    {
        for (int x = 0; x < X; x++)
        {
            for (int y = 0; y < Z; y++)
            {
                if (!grid[x, y])
                {
                    Vector3 tilePosition = new Vector3(x * tileSpacing, 0, y * tileSpacing);
                    // ��Ǩ�ͺ��ҵ��˹觹���繵��˹� exit �������
                    if (!(x == exitX && y == exitY)) // ��Ǩ�ͺ���������ҧ�Ѻ���˹� exit
                    {
                        Instantiate(wallPrefab, tilePosition, Quaternion.identity);
                    }
                }
            }
        }
    }

    void CreateExit()
    {
        grid = new bool[X, Z]; // ��˹���� grid ��͹ 
                               // ... ������Ѻ���ҧ maze ...

        // ��駤����� exitX ��� exitY �繤���������
        exitX = Random.Range(0, X);
        exitY = Random.Range(0, Z);

        // ��Ǩ�ͺ���˹觨����Ҩ�����˹觷����ҧ
        while (grid[exitX, exitY]) // ��ҵ��˹觹�������ҧ �����������
        {
            exitX = Random.Range(0, X);
            exitY = Random.Range(0, Z);
        }

        Instantiate(exitPrefab, new Vector3(exitX * tileSpacing, 0, exitY * tileSpacing), Quaternion.identity);
    }

    void CreateBoundaryWalls()
    {
        // ���ҧ��ᾧ��ҹ��ҧ��д�ҹ��
        for (int x = -1; x <= X; x++)
        {
            // ���ҧ��ᾧ��ҹ��ҧ
            GameObject wallBottom = Instantiate(wallPrefab, new Vector3(x * tileSpacing, wallHeight / 2, (-1 * tileSpacing) - boundarySpacing), Quaternion.identity);
            wallBottom.transform.localScale = new Vector3(wallThickness, wallHeight, 1); // ��Ѻ����˹���Ф����٧

            // ���ҧ��ᾧ��ҹ��
            GameObject wallTop = Instantiate(wallPrefab, new Vector3(x * tileSpacing, wallHeight / 2, (Z * tileSpacing) + boundarySpacing), Quaternion.identity);
            wallTop.transform.localScale = new Vector3(wallThickness, wallHeight, 1); // ��Ѻ����˹���Ф����٧
        }

        // ���ҧ��ᾧ��ҹ������д�ҹ���
        for (int y = 0; y < Z; y++)
        {
            // ���ҧ��ᾧ��ҹ���� (��ع 90 ͧ��)
            GameObject wallLeft = Instantiate(wallPrefab, new Vector3((-1 * tileSpacing) - boundarySpacing, wallHeight / 2, y * tileSpacing), Quaternion.Euler(0, 90, 0));
            wallLeft.transform.localScale = new Vector3(wallThickness, wallHeight, 1); // ��Ѻ����˹���Ф����٧

            // ���ҧ��ᾧ��ҹ��� (��ع 90 ͧ��)
            GameObject wallRight = Instantiate(wallPrefab, new Vector3((X * tileSpacing) + boundarySpacing, wallHeight / 2, y * tileSpacing), Quaternion.Euler(0, 90, 0));
            wallRight.transform.localScale = new Vector3(wallThickness, wallHeight, 1); // ��Ѻ����˹���Ф����٧
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab; // Prefab �ͧ������
    public WallGenerator WallGenerator; // ��ҧ�ԧ
    public float tileSpacing = 1.0f;

    private GameObject player; // ���������Ѻ�纼�����

    void Start()
    {
        CreatePlayer(); // ���ҧ������
    }


     void CreatePlayer()
    {
        int playerX, playerY;

        // �������˹觼�����㹡�Դ�����ҧ
        do
        {
            playerX = Random.Range(0, WallGenerator.X);
            playerY = Random.Range(0, WallGenerator.Z);
        } while (WallGenerator.grid[playerX, playerY]); // ��Ǩ�ͺ��ҵ��˹觹��������������������

        player = Instantiate(playerPrefab, new Vector3(playerX * tileSpacing, 0, playerY * tileSpacing), Quaternion.identity);
    }
}

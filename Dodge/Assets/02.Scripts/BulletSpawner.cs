using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;
    public float spawnRateMin = 0.3f;
    public float spawnRateMax = 7f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    void Start()
    {
        //�ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ź�� ���� ������ spawnRateMin�� spawnRateMax
        // ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // PlayerController ������Ʈ�� ���� ���� ������Ʈ��
        // ã�� ���� ������� ����
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0f;

            // bulletPrefab�� ��������
            // transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            bullet.transform.LookAt(target);
            // ������ ���� ������ spawnRateMin, spawnRateMax ���̿��� ���� ����
            spawnRate = Random.Range(spawnRateMin, spawnRateMax) / 3;
            GameObject bullet2
                = Instantiate(bullet2Prefab, transform.position, transform.rotation);
            bullet2.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin*10, spawnRateMax);
        }
    }
}

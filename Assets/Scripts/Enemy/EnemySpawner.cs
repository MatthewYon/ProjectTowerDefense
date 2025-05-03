using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private EnemyPathCheckpoint firstCheckPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnCoroutine(5));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnCoroutine(int time)
    {
        while(true)
        {
            SpawnOneEnemy();
            yield return new WaitForSeconds(time);
        }
    }

    private void SpawnOneEnemy()
    {
        GameObject tmpEnemyObj = Instantiate(EnemyPrefab, transform);
        tmpEnemyObj.GetComponent<EnemyFollowPath>().SetTargetCheckPoint(firstCheckPoint);
    }
}

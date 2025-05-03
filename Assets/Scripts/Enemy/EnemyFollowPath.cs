using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowPath : MonoBehaviour
{

    [SerializeField]
    private EnemyPathCheckpoint targetCheckpoint;

    [SerializeField]
    private float speed = 1;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(this.gameObject.transform.position, targetCheckpoint.transform.position, speed * Time.deltaTime);
    }

    public void SetTargetCheckPoint(EnemyPathCheckpoint _checkpoint)
    {
        targetCheckpoint = _checkpoint;
    }

}

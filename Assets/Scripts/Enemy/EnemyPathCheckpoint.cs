using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathCheckpoint : MonoBehaviour
{
    [SerializeField]
    private bool open;

    public bool isOpen 
    {
        get {return open;}
    }

    public void SetOpen(bool _open = true)
    {
        open = _open;
    }

    [SerializeField]
    private List<EnemyPathCheckpoint> nextCheckpointPossible;

    private List<EnemyPathCheckpoint> nextCheckpointAvailable;

    void Awake()
    {
        nextCheckpointAvailable = new List<EnemyPathCheckpoint>();
    }

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < nextCheckpointPossible.Count; i++)
        {
            if(nextCheckpointPossible[i].isOpen)
            {
                nextCheckpointAvailable.Add(nextCheckpointPossible[i]);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(nextCheckpointPossible.Count < 1)
            return;
        if(other.TryGetComponent(out EnemyFollowPath enemyPath))
        {
            int indexNext = 0;
            if(nextCheckpointAvailable.Count > 1)
            {
                indexNext = Random.Range(0,2);
            }
            enemyPath.SetTargetCheckPoint(nextCheckpointAvailable[indexNext]);
        }
    }
}

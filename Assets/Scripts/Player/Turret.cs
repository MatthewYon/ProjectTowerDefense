using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 1;

    public float AttackDamage
    {
        get {return attackDamage;}
    }
    
    [SerializeField]
    private float attackRange;
    public float AttackRange
    {
        get {return attackRange;}
    }

    [SerializeField]
    private float attackSpeed;

    public float AttackSpeed 
    {
        get {return attackSpeed;}
    }

    [SerializeField]
    private List<EnemyController> enemyInRange;

    private float timer;

    private SphereCollider rangeTrigger;


    //Use for gizmos draw
    [SerializeField]
    private GameObject attackOrigin;

    private LightningBolt lightningBoltEffect;

    [SerializeField]
    private GameObject outlineGO;

    void Awake()
    {
        rangeTrigger = GetComponentInChildren<SphereCollider>();
        enemyInRange = new List<EnemyController>();
        rangeTrigger.radius = attackRange;
        lightningBoltEffect = GetComponent<LightningBolt>();
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 1 / attackSpeed)
        {
            timer = 0;
            if(enemyInRange.Count > 0)
            {
                
                AttackEnemy();
            }
        }
        timer += Time.deltaTime;
    }

    public void AttackEnemy()
    {
        if(enemyInRange[0] != null)
        {
            if(enemyInRange[0].TakeDamage(attackDamage))
            {
                lightningBoltEffect.enabled = false;
                enemyInRange.RemoveAt(0);
                return;
            }
            lightningBoltEffect.enabled = true;
            lightningBoltEffect.endPoint = enemyInRange[0].transform;
        }
        else
        {
            enemyInRange.RemoveAt(0);
            lightningBoltEffect.enabled = false;
            lightningBoltEffect.endPoint = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyController enemy))
        {
            enemyInRange.Add(enemy);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out EnemyController enemy) && enemyInRange.Contains(enemy))
        {
            enemyInRange.Remove(enemy);
        }
    }

    public void ActivateOutline()
    {
        outlineGO.SetActive(true);
    }

    public void DesactivateOutline()
    {
        outlineGO.SetActive(false);
    }

}

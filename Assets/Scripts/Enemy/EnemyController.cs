using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private int health = 10;

    [SerializeField]
    private int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out House playerHouse))
        {
            playerHouse.TakeDamage(damage);
        }
    }
}

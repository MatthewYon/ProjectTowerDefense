using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField]
    private int baseHealth = 20;
    private int baseShield = 1;

    private int currentHealth;
    private int currentShield;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = baseHealth;
        currentShield = baseShield;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetShield()
    {
        currentShield = baseShield;
    }

    public void TakeDamage(int _damage)
    {
        if(currentShield > 0)
        {
            if(currentShield < _damage)
            {
                _damage -= currentShield;
                currentShield = 0;
            }
            else
            {
                currentShield -= _damage;
            }
        }
        currentHealth -= _damage;

        Debug.Log(currentHealth);
        Debug.Log(currentShield);
    }

}

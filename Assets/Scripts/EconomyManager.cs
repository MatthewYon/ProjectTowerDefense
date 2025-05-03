using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance {private set; get;}

    [SerializeField]
    private int gold = 50;
    
    public int Gold
    {
        get {return gold;}
    }


    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanPurchase(int value)
    {
        return gold >= value;
    }

    public void Purchase(int value)
    {
        if(!CanPurchase(value))
        {
            //Todo MSG Cannot Buy
            return;
        }
        gold -= value;
    }

    public void Sell(int value)
    {
        gold += value;
    }

}

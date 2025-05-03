using TMPro;
using UnityEngine;

public class TourelleInfoUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI typeValue;
    [SerializeField]
    private TextMeshProUGUI atkValue;
    [SerializeField]
    private TextMeshProUGUI aspdValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(Turret turret)
    {
        typeValue.text = turret.gameObject.name;
        atkValue.text = turret.AttackDamage.ToString();
        aspdValue.text = turret.AttackSpeed.ToString();
    }
    
}

using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { private set; get; }

    [SerializeField]
    private TourelleInfoUI tourelleInfoUI;


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

    public void ShowInfoTurret(Turret turret)
    {
        tourelleInfoUI.UpdateUI(turret);
        tourelleInfoUI.gameObject.SetActive(true);
    }
}

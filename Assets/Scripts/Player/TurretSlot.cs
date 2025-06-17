using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    public
    bool isUsed = false;

    [SerializeField]
    GameObject OutlineGO;

    Collider tCollider;

    private void Awake()
    {
        tCollider = GetComponent<Collider>();
        OutlineGO = transform.GetChild(0).gameObject;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOutline(bool on)
    {
        if (isUsed)
            return;
        else
        {
            OutlineGO.SetActive(on);
        }
    }

    public void PlaceTurret(bool on)
    {
        tCollider.enabled = on;
        isUsed = on;
    }
}

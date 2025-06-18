using UnityEngine;

public class TurretSlot : MonoBehaviour
{
    public
    bool isUsed = false;

    [SerializeField]
    GameObject OutlineGO;
    [SerializeField]
    GameObject SelectableOutlineGO;

    Collider tCollider;

    private void Awake()
    {
        tCollider = GetComponent<Collider>();
        SelectableOutlineGO = transform.GetChild(0).gameObject;
        OutlineGO = transform.GetChild(1).gameObject;
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

    public void SetSelectableOutline(bool on)
    {
        if(isUsed)
            return;
        else
        {
            SelectableOutlineGO.SetActive(on);
        }
    }

    public void PlaceTurret(bool on)
    {
        tCollider.enabled = on;
        isUsed = on;
    }
}

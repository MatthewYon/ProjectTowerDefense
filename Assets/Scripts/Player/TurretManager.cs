using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretManager : MonoBehaviour
{

    public static TurretManager Instance {private set; get;}

    [SerializeField]
    private List<GameObject> turretsList;

    private List<GameObject> ActiveTurretList;

    private Turret selectedTurret;

    private GameObject previewTurret;

    private bool isPreviewOn;
    public bool GetIsPreviewOn
    {get { return isPreviewOn;}}

    private int indexCurrentTurret;

    private Turret lastOutlinedObj;

    [SerializeField]
    private List<TurretSlot> turretSlots;


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
        ActiveTurretList = new List<GameObject>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPreviewOn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int layerMask = LayerMask.GetMask("TurretZone");
            
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                if(hit.transform.gameObject.TryGetComponent(out TurretSlot tSlot))
                {
                    previewTurret.SetActive(true);
                    previewTurret.transform.position = hit.transform.position;
                    if (Input.GetMouseButtonDown(0))
                    {
                        foreach(TurretSlot ts in turretSlots)
                        {
                            ts.SetOutline(false);
                        }
                        Destroy(previewTurret.gameObject);
                        previewTurret = null;
                        var tmpobj = Instantiate(turretsList[indexCurrentTurret], hit.transform.position, Quaternion.identity);
                        tSlot.PlaceTurret(true);
                        ActiveTurretList.Add(tmpobj);
                        tmpobj.gameObject.name = "Turret " + ActiveTurretList.Count;
                        isPreviewOn = false;
                    }
                }
                else
                {
                    previewTurret.SetActive(false);
                    if (Input.GetMouseButtonDown(0))
                    {
                        foreach (TurretSlot ts in turretSlots)
                        {
                            ts.SetOutline(false);
                        }
                        Destroy(previewTurret.gameObject);
                        previewTurret = null;
                        isPreviewOn = false;
                    }
                }
            }
            else
            {
                previewTurret.SetActive(false);
                if (Input.GetMouseButtonDown(0))
                {
                    foreach (TurretSlot ts in turretSlots)
                    {
                        ts.SetOutline(false);
                    }
                    Destroy(previewTurret.gameObject);
                    previewTurret = null;
                    isPreviewOn = false;
                }
            }
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.TryGetComponent(out Turret currentTurret))
                {
                    if (lastOutlinedObj != null) lastOutlinedObj.DesactivateOutline();
                    lastOutlinedObj = currentTurret;
                    lastOutlinedObj.ActivateOutline();
                    if (Input.GetMouseButtonDown(0))
                    {
                        UIManager.Instance.ShowInfoTurret(currentTurret);
                        selectedTurret = currentTurret;
                        OutlineSelected(true);
                        lastOutlinedObj = null;
                    }
                }
                else
                {
                    if (lastOutlinedObj != null && lastOutlinedObj != selectedTurret)
                    {
                        lastOutlinedObj.DesactivateOutline();
                        lastOutlinedObj = null;
                    }
                }
            }
        }
    }

    public void OutlineSelected(bool on)
    {
        if(on)
            selectedTurret.GetComponent<Turret>().ActivateOutline();
        else
            selectedTurret.GetComponent<Turret>().DesactivateOutline();
    }

    public void UnselectTurret()
    {
        selectedTurret = null;
    }


    public void TurretPlacementPreview(int indexTurret)
    {
        foreach(TurretSlot ts in turretSlots)
        {
            ts.SetOutline(true);
        }
        isPreviewOn = true;
        indexCurrentTurret = indexTurret;
        previewTurret = Instantiate(turretsList[indexCurrentTurret]);
        Destroy(previewTurret.GetComponent<LightningBolt>());
        Destroy(previewTurret.GetComponentInChildren<Collider>());
        Destroy(previewTurret.GetComponent<Turret>());
        Destroy(previewTurret.GetComponent<TurretClick>());
    }

    public void SellTurret()
    {
        ActiveTurretList.Remove(selectedTurret.gameObject);
        Destroy(selectedTurret.gameObject);
    }
}

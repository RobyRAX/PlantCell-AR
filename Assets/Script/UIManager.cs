using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject findMarkerNotif;
    public GameObject activeDetail;
    public GameObject[] details; 

    void Awake()
    {
        ScenarioController.OnActiveComponentChanged += SetDetail;
    }

    private void Start()
    {
        ResetDetail();
    }

    void SetDetail(ComponentParentController component)
    {
        activeDetail = component.detail;
        UpdateDetail();
    }

    void UpdateDetail()
    {
        activeDetail.SetActive(true);

        foreach(GameObject detail in details)
        {
            if(detail != activeDetail)
                detail.SetActive(false);
        }
    }

    public void ResetDetail()
    {
        activeDetail = findMarkerNotif;
        UpdateDetail();
    }
}

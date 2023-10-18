using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScenarioController : MonoBehaviour
{
    public static event Action<ComponentParentController> OnActiveComponentChanged;

    public GameObject activeComponent;
    public GameObject mainComponent;
    public GameObject[] componentList;
    [SerializeField] float transitionDuration;

    private void Awake()
    {
        RayCaster.OnComponentClicked += UpdateActiveComponent;
    }

    private void Start()
    {
        
    }

    public void Init()
    {
        UpdateActiveComponent(this, mainComponent);

        foreach (GameObject component in componentList)
        {
            component.transform.localScale = Vector3.zero;
        }

        StartCoroutine(TransitionHandler());
    }

    public void Exit()
    {
        foreach (GameObject component in componentList)
        {
            component.transform.localScale = Vector3.zero;
        }
    }

    public void UpdateActiveComponent(ScenarioController scenario, GameObject newActiveComponent)
    {
        if(scenario == this)
        {
            foreach (GameObject component in componentList)
            {
                if (component == newActiveComponent)
                {
                    activeComponent = component;
                    StartCoroutine(TransitionHandler());

                    OnActiveComponentChanged(activeComponent.GetComponent<ComponentParentController>());
                }               
            }
        }        
    }

    IEnumerator TransitionHandler()
    {
        foreach (GameObject component in componentList)
        {
            if(component != activeComponent)
                component.transform.DOScale(Vector3.zero, transitionDuration);
            else
            {
                component.transform.DOScale(Vector3.one, transitionDuration);

                MeshRenderer[] renderers = component.GetComponentsInChildren<MeshRenderer>();
                foreach (MeshRenderer rend in renderers)
                {
                    rend.enabled = true;
                }
            }                
        }
        yield return new WaitForSeconds(transitionDuration);

        foreach (GameObject component in componentList)
        {
            if (component != activeComponent)
            {
                MeshRenderer[] renderers = component.GetComponentsInChildren<MeshRenderer>();
                foreach(MeshRenderer rend in renderers)
                {
                    rend.enabled = false;
                }
            }
        }
    }
}

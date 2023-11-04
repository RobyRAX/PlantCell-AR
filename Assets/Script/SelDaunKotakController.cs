using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Jaringan
{
    public GameObject obj;
    public Material mat;
}

public class SelDaunKotakController : MonoBehaviour
{
    public Jaringan[] jaringanAll;

    [SerializeField] float activeColorValue;
    [SerializeField] float disableColorValue;

    [SerializeField] float activeShadeValue;   
    [SerializeField] float disableShadeValue;
    

    Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void SelectJaringan(int index)
    {
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        try
        {            
            for (int i = 0; i < jaringanAll.Length; i++)
            {
                jaringanAll[i].obj.SetActive(false);
               
                propertyBlock.SetFloat("_ColorVisibility", disableColorValue);
                propertyBlock.SetFloat("_ShadeVisibility", disableShadeValue);
                rend.SetPropertyBlock(propertyBlock, i);
            }

            jaringanAll[index].obj.SetActive(true);
            propertyBlock.SetFloat("_ColorVisibility", activeColorValue);
            propertyBlock.SetFloat("_ShadeVisibility", activeShadeValue);
            rend.SetPropertyBlock(propertyBlock, index);
        }
        catch
        {
            for (int i = 0; i < jaringanAll.Length; i++)
            {
                jaringanAll[i].obj.SetActive(true);

                propertyBlock.SetFloat("_ColorVisibility", activeColorValue);
                propertyBlock.SetFloat("_ShadeVisibility", activeShadeValue);
                rend.SetPropertyBlock(propertyBlock, i);
            }
        }
    }
}

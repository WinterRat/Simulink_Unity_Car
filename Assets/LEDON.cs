using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LEDON : MonoBehaviour
{
    public Color emissionOn = new Color(1.0f, 1.0f, 1.0f); // Emission이 켜져 있을 때의 색상값
    public Color emissionOff = new Color(0.0f, 0.0f, 0.0f); // Emission이 꺼져 있을 때의 색상값

    private Renderer objRenderer;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    // Emission을 켜는 함수
    public void TurnOnEmission()
    {
        if (objRenderer != null)
        {
            for (int i = 0; i < objRenderer.materials.Length; i++)
            {
                objRenderer.materials[i].SetColor("_EmissionColor", emissionOn);
            }
        }
    }

    // Emission을 끄는 함수
    public void TurnOffEmission()
    {
        if (objRenderer != null)
        {
            for (int i = 0; i < objRenderer.materials.Length; i++)
            {
                objRenderer.materials[i].SetColor("_EmissionColor", emissionOff);
            }
        }
    }
}
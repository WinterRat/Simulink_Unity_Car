using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LEDON : MonoBehaviour
{
    public Color emissionOn = new Color(1.0f, 1.0f, 1.0f); // Emission�� ���� ���� ���� ����
    public Color emissionOff = new Color(0.0f, 0.0f, 0.0f); // Emission�� ���� ���� ���� ����

    private Renderer objRenderer;

    private void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    // Emission�� �Ѵ� �Լ�
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

    // Emission�� ���� �Լ�
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
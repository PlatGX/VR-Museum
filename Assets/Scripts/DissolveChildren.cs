using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveChildren : MonoBehaviour
{
    public List<Material> materials = new List<Material>();
    public float dissolveSpeed = 1f;
    private bool isDissolving = false;

    void Start()
    {
        var renders = GetComponentsInChildren<Renderer>();
        foreach (var rend in renders)
        {
            materials.AddRange(rend.materials);
        }
    }

    public void OnButtonPress(Color color, float colorIntensity)
    {
        if(isDissolving)
            return;

        isDissolving = true;
        float targetValue = materials[0].GetFloat("_Dissolve") == 0f ? 1f : 0f;
        StartCoroutine(DissolveTransition(targetValue, color, colorIntensity));
    }

    IEnumerator DissolveTransition(float targetValue, Color color, float colorIntensity)
    {
        float startValue = materials[0].GetFloat("_Dissolve");
        float duration = Mathf.Abs(targetValue - startValue) / dissolveSpeed;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float currentValue = Mathf.Lerp(startValue, targetValue, elapsed / duration);
            SetValue("_Dissolve", currentValue);
            SetValue("_Color", color);
            SetValue("_ColorIntensity", colorIntensity);
            yield return null;
        }

        SetValue("_Dissolve", targetValue);
        isDissolving = false;
    }

    public void SetValue(string propertyName, float value)
    {
        foreach (var material in materials)
        {
            material.SetFloat(propertyName, value);
        }
    }

    public void SetValue(string propertyName, Color value)
    {
        foreach (var material in materials)
        {
            material.SetColor(propertyName, value);
        }
    }

    public void OnRedButtonPress()
    {
        OnButtonPress(Color.red, 1f);
    }

    public void OnGreenButtonPress()
    {
        OnButtonPress(Color.green, 1f);
    }

    public void OnBlueButtonPress()
    {
        OnButtonPress(Color.blue, 1f);
    }
}
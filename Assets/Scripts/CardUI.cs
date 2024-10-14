using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public GameObject targetObject;
    private MeshRenderer objectRenderer;

    public Dropdown changeColorButton;
    public Slider transparencySlider;
    public Toggle toggleVisibilityButton;
    public void SetupCard(ChangableObject target)
    {
        targetObject = target.gameObject;
        objectRenderer = targetObject.GetComponent<MeshRenderer>();
        changeColorButton.onValueChanged.AddListener(delegate { ChangeColor(); });
        transparencySlider.onValueChanged.AddListener(ChangeTransparency);
        toggleVisibilityButton.onValueChanged.AddListener(ToggleVisibility);
        if (objectRenderer != null)
        {
            transparencySlider.value = objectRenderer.material.color.a;
        }
    }
    void ChangeColor()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }
    void ChangeTransparency(float value)
    {
        if (objectRenderer != null)
        {
            Color newColor = objectRenderer.material.color;
            newColor.a = value;
            objectRenderer.material.color = newColor;
        }
    }
    void ToggleVisibility(bool isVisible)
    {
        objectRenderer.enabled = isVisible;
    }
}

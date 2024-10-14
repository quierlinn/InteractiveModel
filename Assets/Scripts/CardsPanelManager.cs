using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsPanelManager : MonoBehaviour
{
    public GameObject cardPanel;
    public Button toggleButton;
    public CameraController cameraController;

    private bool isPanelVisible = false;
    private GameObject[] objectsToDisplay;
    void Start()
    {
        cardPanel.SetActive(false);
        toggleButton.onClick.AddListener(ToggleCardsPanel);
    }
    void ToggleCardsPanel()
    {
        isPanelVisible = !isPanelVisible;
        cardPanel.SetActive(isPanelVisible);
        if (isPanelVisible)
        {
            cameraController.enabled = false;
        }
        else
        {
            cameraController.enabled = true;
        }
    }
}

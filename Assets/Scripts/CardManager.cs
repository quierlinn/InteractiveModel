using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardContainer;
    public GameObject ChangableObjectsParent; 

    void Start()
    {
        ChangableObject[] objects = ChangableObjectsParent.GetComponentsInChildren<ChangableObject>();
        foreach (ChangableObject obj in objects)
        {
            CreateCard(obj);
        }
    }
    void CreateCard(ChangableObject targetObject)
    {
        GameObject newCard = Instantiate(cardPrefab, cardContainer);
        Text cardText = newCard.GetComponentInChildren<Toggle>().GetComponentInChildren<Text>();
        if (cardText != null)
        {
            cardText.text = targetObject.name;
        }
        CardUI cardUI = newCard.GetComponent<CardUI>();
        if (cardUI != null)
        {
            cardUI.SetupCard(targetObject);
        }
    }
}
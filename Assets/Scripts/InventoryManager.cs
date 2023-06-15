using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject LightGameObject;
    [SerializeField] private GameObject InventoryPanel;
    private Transform panelTransform;
    public List<InventorySlot> slots = new List<InventorySlot>();
    public bool inventoryIsOpen;
    public bool lightIsOn;
    // [FormerlySerializedAs("isOpen")]

    private void Start()
    {
        inventoryIsOpen = false;
        panelTransform = InventoryPanel.transform;
        for (int i = 0; i < panelTransform.childCount; i++)
        {
            if (panelTransform.GetChild(i).GetComponent<InventorySlot>() != null) {
                slots.Add(panelTransform.GetChild(i).GetComponent<InventorySlot>());
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryIsOpen = !inventoryIsOpen;
            InventoryPanel.SetActive(inventoryIsOpen);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            lightIsOn = !lightIsOn;
            LightGameObject.SetActive(lightIsOn);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public ItemSlotUI[] uiSlots;
    public ItemSlot[] slots;

    public GameObject inventoryWindow;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;
    private int selectedItemIndex;
    public TextMeshProUGUI selectedItemName;
    public TextMeshProUGUI selectedItemDescription;
    public TextMeshProUGUI selectedItemStatNames;
    public TextMeshProUGUI selectedItemStatValues;
    public GameObject useButton;
    public GameObject equipButton;
    public GameObject unEquipButton;
    public GameObject dropButton;

    private int curEquipIndex;

    //components
    private PlayerController controller;

    [Header("Events")]
    public UnityEvent onOpenInventory;
    public UnityEvent onCloseInventory;

    //singleton
    public static Inventory instance;

    void Awake()
    {
        instance = this;
        controller = GetComponent<PlayerController>();

    }

    void Start()
    {
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[uiSlots.Length];
        // initialize the slots
        for (int x = 0; x < slots.Length; x++)
        {
            slots[x] = new ItemSlot();
            uiSlots[x].index = x;
            uiSlots[x].Clear();
        }
    }
    public void Toggle()
    {

    }

    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }

    public void AddItem(ItemData item)
    {
        if (item.canStack)
        {
            ItemSlot slotToStackTo = GetItemStack(item);

            if (slotToStackTo != null)
            {
                slotToStackTo.quantity++;
                UpdateUI();
                return;
            }
        }
        ItemSlot emptySlot = GetEmptySlot();

        if (emptySlot != null)
        {
            emptySlot.item = item;
            emptySlot.quantity = 1;
            UpdateUI();
            return;
        }

        ThrowItem(item);
    }

    void ThrowItem(ItemSlot item)
    {

    }

    void UpdateUI()
    {

    }

    ItemSlot GetItemStack(ItemData item)
    {
        return null;
    }

    ItemSlot GetEmptySlot() 
    { 
        return null; 
    }

    public void SelectItem (int index)
    {

    }

    void ClearSelectedItemWindow()
    {

    }
    public void OnUseButton()
    {

    }

    public void OnEquipButton()
    {

    }
    void UnEquip(int index)
    {

    }

    public void OnUnEquipButton()
    {

    }

    public void OnDropButton()
    {

    }

    void RemoveSelectedItem()
    {

    }

    public void RemoveItem(ItemData item)
    {

    }

    public bool HasItems(ItemData item, int quantity)
    {
        return false;
    }
}

public class ItemSlot
{
    public ItemData item;
    public int quantity;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Regular : MonoBehaviour, IActivatable
{
    [SerializeField]
    string nameText;

    [Tooltip("If you set a key, the door will be locked.")]
    [SerializeField]
    Animator parentAnimator;
    [SerializeField]
    InventoryObject key;

    private Animator animator;
    public bool isLocked, isOpen;
    private List<InventoryObject> playerInventory;

    public string NameText
    {
        get
        {
            string toReturn = nameText;

            if (isOpen)
                toReturn = ""; // So it doesn't look like you can open the door anymore.
            else if (isLocked && !HasKey)
                toReturn += " (LOCKED)";
            else if (isLocked && HasKey)
                toReturn += string.Format(" (use {0})", key.NameText);

            return toReturn;
        }
    }

    private bool HasKey
    {
        get
        {
            return playerInventory.Contains(key);
        }
    }

    public void DoActivate()
    {
        if (!isOpen)
        {
            if (!isLocked || HasKey)
            {
                animator.SetBool("IsOpen", true);
                isOpen = true;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        animator = parentAnimator.GetComponent<Animator>();
        playerInventory = FindObjectOfType<InventoryMenu>().PlayerInventory;
        isLocked = key != null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipments : MonoBehaviour
{
    [SerializeField] List<Items> items;

    Character character;

    [SerializeField] Items armorTest;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void Start()
    {
        Equip(armorTest);
    }
    public void Equip(Items itemToEquip)
    {
        if (items == null)
        {
            items = new List<Items>();
        }
        items.Add(itemToEquip);
        itemToEquip.Equip(character);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {

            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                //break;
            }
            


        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }

    }//end of AddItem

    
}// end of public class InventoryObject

    [System.Serializable]
public class InventorySlot
{
      public ItemObject item;
      public int amount;
      //Constructor
      public InventorySlot(ItemObject _item,int _amount)
      {
          item = _item;
          amount = _amount;
      }
    
      //  method in InventorySlot
      public void AddAmount(int value)
      {
          amount += value;
      }

}//end of public class InventorySlot

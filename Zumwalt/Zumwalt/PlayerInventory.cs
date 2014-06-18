﻿namespace Zumwalt
{
    using System;

    public class PlayerInventory
    {
        private PlayerItem[] _armorItems;
        private PlayerItem[] _barItems;
        private Inventory _inv;
        private PlayerItem[] _items;
        private Zumwalt.Player player;

        public PlayerInventory(Zumwalt.Player player)
        {
            this.player = player;
            this._inv = player.PlayerClient.controllable.GetComponent<Inventory>();
            this.InitItems();
        }

        public void AddItem(string name)
        {
            this.AddItem(name, 1);
        }

        public void AddItem(string name, int amount)
        {
            string[] strArray = new string[] { name, amount.ToString() };
            ConsoleSystem.Arg arg = new ConsoleSystem.Arg("");
            arg.Args = strArray;
            arg.SetUser(this.player.PlayerClient.netUser);
            inv.give(ref arg);
        }

        public void Clear()
        {
            foreach (PlayerItem item in this.Items)
            {
                this._inv.RemoveItem(item.RInventoryItem);
            }
            foreach (PlayerItem item2 in this.BarItems)
            {
                this._inv.RemoveItem(item2.RInventoryItem);
            }
        }

        public void ClearAll()
        {
            this._inv.Clear();
        }

        public void ClearArmor()
        {
            foreach (PlayerItem item in this.ArmorItems)
            {
                this._inv.RemoveItem(item.RInventoryItem);
            }
        }

        public void ClearBar()
        {
            foreach (PlayerItem item in this.BarItems)
            {
                this._inv.RemoveItem(item.RInventoryItem);
            }
        }

        public void DropAll()
        {
            DropHelper.DropInventoryContents(this.InternalInventory);
        }

        public void DropItem(PlayerItem pi)
        {
            DropHelper.DropItem(this.InternalInventory, pi.Slot);
        }

        public void DropItem(int slot)
        {
            DropHelper.DropItem(this.InternalInventory, slot);
        }

        private int GetFreeSlots()
        {
            int num = 0;
            for (int i = 0; i < (this._inv.slotCount - 4); i++)
            {
                if (this._inv.IsSlotFree(i))
                {
                    num++;
                }
            }
            return num;
        }

        public bool HasItem(string name)
        {
            return this.HasItem(name, 1);
        }

        public bool HasItem(string name, int number)
        {
            int num = 0;
            foreach (PlayerItem item in this.Items)
            {
                if (item.Name == item.Name)
                {
                    if (item.UsesLeft >= number)
                    {
                        return true;
                    }
                    num += item.UsesLeft;
                }
            }
            foreach (PlayerItem item2 in this.BarItems)
            {
                if (item2.Name == item2.Name)
                {
                    if (item2.UsesLeft >= number)
                    {
                        return true;
                    }
                    num += item2.UsesLeft;
                }
            }
            foreach (PlayerItem item3 in this.ArmorItems)
            {
                if (item3.Name == item3.Name)
                {
                    if (item3.UsesLeft >= number)
                    {
                        return true;
                    }
                    num += item3.UsesLeft;
                }
            }
            return (num >= number);
        }

        private void InitItems()
        {
            this.Items = new PlayerItem[30];
            this.ArmorItems = new PlayerItem[4];
            this.BarItems = new PlayerItem[6];
            for (int i = 0; i < this._inv.slotCount; i++)
            {
                if (i < 30)
                {
                    this.Items[i] = new PlayerItem(ref this._inv, i);
                }
                else if (i < 0x24)
                {
                    this.BarItems[i - 30] = new PlayerItem(ref this._inv, i);
                }
                else if (i < 40)
                {
                    this.ArmorItems[i - 0x24] = new PlayerItem(ref this._inv, i);
                }
            }
        }

        public void RemoveItem(PlayerItem pi)
        {
            foreach (PlayerItem item in this.Items)
            {
                if (item == pi)
                {
                    this._inv.RemoveItem(pi.RInventoryItem);
                    return;
                }
            }
            foreach (PlayerItem item2 in this.ArmorItems)
            {
                if (item2 == pi)
                {
                    this._inv.RemoveItem(pi.RInventoryItem);
                    return;
                }
            }
            foreach (PlayerItem item3 in this.BarItems)
            {
                if (item3 == pi)
                {
                    this._inv.RemoveItem(pi.RInventoryItem);
                    break;
                }
            }
        }

        public void RemoveItem(int slot)
        {
            this._inv.RemoveItem(slot);
        }

        public void RemoveItem(string name, int number)
        {
            foreach (PlayerItem item in this.Items)
            {
                if ((item.Name == item.Name) && (item.UsesLeft >= number))
                {
                    this.RemoveItem(item.Slot);
                    break;
                }
            }
            foreach (PlayerItem item2 in this.ArmorItems)
            {
                if ((item2.Name == item2.Name) && (item2.UsesLeft >= number))
                {
                    this.RemoveItem(item2.Slot);
                    break;
                }
            }
            foreach (PlayerItem item3 in this.BarItems)
            {
                if ((item3.Name == item3.Name) && (item3.UsesLeft >= number))
                {
                    this.RemoveItem(item3.Slot);
                    return;
                }
            }
        }

        public PlayerItem[] ArmorItems
        {
            get
            {
                return this._armorItems;
            }
            set
            {
                this._armorItems = value;
            }
        }

        public PlayerItem[] BarItems
        {
            get
            {
                return this._barItems;
            }
            set
            {
                this._barItems = value;
            }
        }

        public int FreeSlots
        {
            get
            {
                return this.GetFreeSlots();
            }
        }

        public Inventory InternalInventory
        {
            get
            {
                return this._inv;
            }
            set
            {
                this._inv = value;
            }
        }

        public PlayerItem[] Items
        {
            get
            {
                return this._items;
            }
            set
            {
                this._items = value;
            }
        }
    }
}

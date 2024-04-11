﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disaheim
{
    public class Amulet : Merchandise
    {
        
        public string Design { get; set; }
        public Level Quality { get; set; }


        public Amulet(string itemId)
        {
            ItemId = itemId;
            Quality = Level.medium;
        }

        public Amulet(string itemId, Level quality) : this(itemId)
        {
            Quality = quality;
        }

        public Amulet(string itemId, Level quality, string design) : this(itemId, quality)
        {
            Design = design;
        }

        public override string ToString()
        {
            return $"ItemId: {ItemId}, Quality: {Quality}, Design: {Design}";
        }
    }
}
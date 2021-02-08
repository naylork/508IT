using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;

namespace Test.ViewModels
{
    public class EquipmentAndType
    {
        public IEnumerable<Equipment> Equipment { get; set; }

        public IEnumerable<EquipmentType> EquipmentType { get; set; }
    }
}

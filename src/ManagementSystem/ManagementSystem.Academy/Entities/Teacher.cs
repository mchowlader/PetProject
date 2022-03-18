﻿using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Academy.Entities
{
    public class Teacher : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MobileNo{ get; set; }
        public string Photo { get; set; }
        public string Gender { get; set; }
    }
}
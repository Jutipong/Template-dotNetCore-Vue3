﻿using DAL.Model.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TCRB.WEB.Models
{
    public class Demo01ViewModel
    {
        public List<Select2Model> Master_Select2Single { get; set; }
        public List<Select2Model> Master_Select2Multiple { get; set; }
    }
}

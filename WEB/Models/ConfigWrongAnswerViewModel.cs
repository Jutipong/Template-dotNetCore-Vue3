using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class ConfigWrongAnswerViewModel
    {
        public Config_WrongAnswer Config_WrongAnswer { get; set; } = new Config_WrongAnswer();
        public List<Select2Model> MasterChannel { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterLevel { get; set; } = new List<Select2Model>();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();
    }
}

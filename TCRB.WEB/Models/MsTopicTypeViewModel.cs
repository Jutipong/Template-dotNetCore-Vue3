using System.Collections.Generic;
using TCRB.DAL.EntityModel;
using TCRB.DAL.Model.Commons;

namespace TCRB.WEB.Models
{
    public class MsTopicTypeViewModel
    {
        public Ms_TopicType Ms_TopicType { get; set; } = new Ms_TopicType();
        public List<Select2Model> MasterIsActive { get; set; } = new List<Select2Model>();

    }
}

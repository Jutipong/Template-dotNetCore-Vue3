using AutoMapper;
using System.Collections.Generic;
using TCRB.DAL.Model.Authentication;
using TCRB.DAL.UserManagement.EntityModel;

namespace TCRB.WEB.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, ADUserModel>();
            CreateMap<Group, GroupADModel>();
            CreateMap<Permission, PermissionADModel>();
        }
    }
}

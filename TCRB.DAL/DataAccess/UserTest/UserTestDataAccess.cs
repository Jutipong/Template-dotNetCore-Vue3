using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TCRB.DAL.Model.Commons;

namespace TCRB.DAL.DataAccess
{
    public class UserTestDataAccess : IUserTestDataAccess
    {
        private readonly TCRBDBContext _context;
        private readonly IMapper _mapper;

        public UserTestDataAccess(TCRBDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public DataTableResponseModel InquiryMasterDatatable(DatableOption option, Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new DataTableResponseModel();

            try
            {
                var query = (from ut in _context.UserTest.AsEnumerable()
                             where (string.IsNullOrEmpty(userTest.IsActive) || ut.IsActive == userTest.IsActive)
                             where ((string.IsNullOrEmpty(userTest.Name) || ut.Name.Contains(userTest.Name, StringComparison.OrdinalIgnoreCase)))
                             where ((string.IsNullOrEmpty(userTest.Last) || ut.Last.Contains(userTest.Last, StringComparison.OrdinalIgnoreCase)))
                             select ut);

                query = option.sortingby switch
                {
                    1 => (option.orderby == "asc" ? query.OrderBy(r => r.Last) : query.OrderByDescending(r => r.Last)),
                    2 => (option.orderby == "asc" ? query.OrderBy(r => r.CreateBy) : query.OrderByDescending(r => r.CreateBy)),
                    3 => (option.orderby == "asc" ? query.OrderBy(r => r.CreateDate) : query.OrderByDescending(r => r.CreateDate)),
                    4 => (option.orderby == "asc" ? query.OrderBy(r => r.UpdateBy) : query.OrderByDescending(r => r.UpdateBy)),
                    5 => (option.orderby == "asc" ? query.OrderBy(r => r.UpdateDate) : query.OrderByDescending(r => r.UpdateDate)),
                    6 => (option.orderby == "asc" ? query.OrderBy(r => r.IsActive) : query.OrderByDescending(r => r.IsActive)),
                    _ => (option.orderby == "asc" ? query.OrderBy(r => r.Name) : query.OrderByDescending(r => r.Name)),
                };

                var datas = query.Skip(option.start).Take(option.length).ToList();
                var recordsTotal = query.Count();

                result = new DataTableResponseModel
                {
                    status = true,
                    message = "success",
                    data = datas,
                    draw = option.draw,
                    recordsTotal = recordsTotal,
                    recordsFiltered = recordsTotal
                };

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModels<Entity.UserTest> Inquiry(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModels<Entity.UserTest>();

            try
            {
                var query = (from ut in _context.UserTest
                             where (string.IsNullOrEmpty(userTest.IsActive) || ut.IsActive == userTest.IsActive)
                             where ((string.IsNullOrEmpty(userTest.Name) || ut.Name.Contains(userTest.Name, StringComparison.OrdinalIgnoreCase)))
                             where ((string.IsNullOrEmpty(userTest.Last) || ut.Last.Contains(userTest.Last, StringComparison.OrdinalIgnoreCase)))
                             select ut).ToList();

                result.Datas = query;
                result.Total = query.Count();
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModel Create(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel();

            try
            {
                _context.UserTest.Add(userTest);
                _context.SaveChanges();

                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModel Update(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel();

            try
            {
                if (_context.UserTest.Any(item => item.ID == userTest.ID))
                {
                    _context.UserTest.Update(userTest);
                    _context.SaveChanges();
                    result.Success = true;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }

        public ResponseModel Delete(Entity.UserTest userTest)
        {
            var methodName = MethodBase.GetCurrentMethod().Name;
            var result = new ResponseModel();

            try
            {
                _context.UserTest.Remove(_context.UserTest.FirstOrDefault(r => r.ID == userTest.ID));
                _context.SaveChanges();
                result.Success = true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error Function => {methodName}, Message: {ex.Message}", ex);
            }

            return result;
        }
    }
}

using AutoMapper;
using LibraryAPI.Application.Enums.NavigationEnums;
using LibraryAPI.Application.Repositories.UserRepositories.CustomerRepositories;
using LibraryAPI.Core.CrossCuttingConcerns.Exceptions;
using LibraryAPI.Domain.Entities.UserEntities;
using LibraryAPI.Dtos.Views.CustomerViews;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Services.ReadServices.CustomerReadService
{
    public class CustomerReadManager : ICustomerReadService
    {


        private readonly ICustomerReadRepository _customerReadRepository;

        public CustomerReadManager(ICustomerReadRepository customerReadRepository, IMapper mapper)
        {

            _customerReadRepository = customerReadRepository;
        }



        private static ResponseCustomerDto MapToResponseCustomerDto(Customer customer)
        {
            return new ResponseCustomerDto
            {
               UserName=customer.User.UserName,
               IdentityNumber=customer.User.IdentityNumber,
               PhoneNumber=customer.User.PhoneNumber,
               PhotoPath=customer.User.PhotoPath,
               Status=customer.User.Status,
               FirstName=customer.User.FirstName,
               LastName=customer.User.LastName,
               BirthDate=customer.User.BirthDate,
               Email=customer.User.Email,
               SubEndDate=customer.SubEndDate,
               SubStartDate=customer.SubStartDate,
               IsSub=customer.IsSub
            };
        }




        public async Task<List<ResponseCustomerDto>> GetAllCustomer()
        {
            
            var res = await _customerReadRepository.GetQuery(includes:CustomerNavigations.User).Select(customer=> MapToResponseCustomerDto(customer)).ToListAsync();
            if (res.Count==0) throw new BusinessException("Customer not found.");
            return res;
        }

        public async Task<ResponseCustomerDto> GetCustomerById(int id)
        {
            var res = await _customerReadRepository.GetQuery(x=>x.Id==id,includes:CustomerNavigations.User).Select(customer => MapToResponseCustomerDto(customer)).SingleOrDefaultAsync();
            if(res==null) throw new BusinessException($"Customer not find CustomerId:{id}");
            return res;
        }

        public async Task<ResponseCustomerDto> GetCustomerByIdentityNumber(long identityNumber)
        {
            var res = await _customerReadRepository.GetQuery (filter: x => x.User.IdentityNumber == identityNumber, includes: CustomerNavigations.User)
                .Select(customer => MapToResponseCustomerDto(customer)).SingleOrDefaultAsync();
            if (res == null) throw new BusinessException($"Customer not find identityName;{identityNumber}");
            return res;
        }

        public async Task<List<ResponseCustomerDto>> GetCustomerByName(string name)
        {
            var res = await _customerReadRepository.GetQuery(filter: x => x.User.FirstName == name, includes: CustomerNavigations.User)
                .Select(customer => MapToResponseCustomerDto(customer)).ToListAsync();
            if (res == null) throw new BusinessException($"Customer not find FirstName:{name}");
            return res;
        }

        public async Task<ResponseCustomerDto> GetCustomerByUserId(int id)
        {
            var res = await _customerReadRepository.GetQuery(x=>x.UserId==id,includes: CustomerNavigations.User)
                .Select(customer => MapToResponseCustomerDto(customer))
                .SingleOrDefaultAsync();
            if (res == null) throw new BusinessException($"Customer not find UserID:{id}");
            return res;
        }

        public async Task<List<ResponseCustomerDto>> GetCustomerIsSub(bool isSub)
        {
            var res = await _customerReadRepository.GetQuery(x => x.IsSub == isSub, includes: CustomerNavigations.User)
                .Select(customer => MapToResponseCustomerDto(customer))
                .ToListAsync();
            if(res == null) throw new BusinessException($"Customer not find subcribe?:{isSub}");
            return res;
        }
    }
}

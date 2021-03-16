using Abp.Application.Services.Dto;
using MCV.Portal.Person;
using MCV.Portal.Person.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.PhoneBook
{
    public class ProxyPersonAppService : ProxyAppServiceBase, IPersonAppService
    {
        public Task CreatePerson(CreatePersonInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeletePerson(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<PersonListDto>> GetPeople(GetPeopleInput input)
        {
            //var result = ApiClient.GetAsync<ListResultDto<PersonListDto>>(GetEndpoint(nameof(GetPeople)), input);
            return await ApiClient.GetAsync<PagedResultDto<PersonListDto>>(GetEndpoint(nameof(GetPeople)), input);
        }
    }
}

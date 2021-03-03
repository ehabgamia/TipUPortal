using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MCV.Portal.Authorization;
using MCV.Portal.Person.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Person
{
    //[AbpAuthorize(AppPermissions.Pages_Administration)]
    public class PersonAppService : PortalAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;
        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreatePerson(CreatePersonInput input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _personRepository.InsertAsync(person);
        }

        public async Task DeletePerson(EntityDto input)
        {
            await _personRepository.DeleteAsync(input.Id);
        }

        public ListResultDto<PersonListDto> GetPeople(GetPeopleInput input)
        {
            try
            {
                var people = _personRepository
               .GetAll()
               .WhereIf(
                   !input.Filter.IsNullOrEmpty(),
                   p => p.Name.Contains(input.Filter) ||
                        p.Surname.Contains(input.Filter) ||
                        p.EmailAddress.Contains(input.Filter)
               )
               .OrderBy(p => p.Name)
               .ThenBy(p => p.Surname)
               .ToList();

                return new ListResultDto<PersonListDto>(ObjectMapper.Map<List<PersonListDto>>(people));
            }
           catch(Exception ex)
            {
                Logger.Error("GetPeople", ex);
            }
            return null;
        }
    }
}

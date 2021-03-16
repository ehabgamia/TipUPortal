using MCV.Portal.Commands;
using MCV.Portal.Core.Threading;
using MCV.Portal.Models.PhoneBook;
using MCV.Portal.Models.Subject;
using MCV.Portal.Person;
using MCV.Portal.Person.Dto;
using MCV.Portal.Subject;
using MCV.Portal.Subject.Dto;
using MCV.Portal.ViewModels.Base;
using MvvmHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MCV.Portal.ViewModels
{
    public class PeopleViewModel : XamarinViewModel
    {
        public ICommand PageAppearingCommand => HttpRequestCommand.Create(PageAppearingAsync);
        private readonly IPersonAppService _personAppService;
        private  PersonListDto person;
        private ObservableRangeCollection<PersonListDto> Persons { get; set; }

        public PeopleViewModel(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
            Persons = new ObservableRangeCollection<PersonListDto>();
        }

        public PersonListDto Person
        {
            get => person;
            set
            {
                person = value;
                RaisePropertyChanged(() => Person);
            }
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await FetchDataAsync();
        }
            public async Task PageAppearingAsync()
        {
            await FetchDataAsync();
        }

        public async Task FetchDataAsync(string filterText = null)
        {
            await SetBusyAsync(async () =>
            {
                var result = await _personAppService.GetPeople(new GetPeopleInput
                {
                    Filter = filterText
                });

                var personListModels = ObjectMapper.Map<List<PersonListDto>>(result.Items);

                foreach (var item in personListModels)
                {
                    Persons.Add(item);
                }

                Persons.ReplaceRange(personListModels);
            });
        }
    }
}

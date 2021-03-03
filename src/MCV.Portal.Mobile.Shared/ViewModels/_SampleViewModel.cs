using MCV.Portal.Commands;
using MCV.Portal.Models.Subject;
using MCV.Portal.Subject;
using MCV.Portal.ViewModels.Base;
using MvvmHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MCV.Portal.ViewModels
{
    public class _SampleViewModel : XamarinViewModel
    {
        public ICommand PageAppearingCommand => HttpRequestCommand.Create(PageAppearingAsync);
        private readonly ISubjectAppService  _subjectAppService;
        private ObservableRangeCollection<SubjectListModel> Subjects = new ObservableRangeCollection<SubjectListModel>();

        public _SampleViewModel(ISubjectAppService subjectAppService)
        {
            _subjectAppService = subjectAppService;
        }

        public async Task LoadMoresubjectIfNeedsAsync(SubjectListModel shownItem)
        {
            if (IsBusy)
            {
                return;
            }

            await FetchDataAsync();
        }

        public ObservableRangeCollection<SubjectListModel> SelectSubjects
        {
            get => Subjects;
            set
            {
                Subjects = value;
                //OnPropertyChanged(()=> Subjects);
                RaisePropertyChanged(() => SelectSubjects);
            }
        }
        public async Task PageAppearingAsync()
        {
            await FetchDataAsync();
        }

        public async Task FetchDataAsync(string filterText = null)
        {
            await SetBusyAsync(async () =>
            {
                var result = await _subjectAppService.GetSubject(new Subject.Dto.GetSubjectInput
                {
                    Filter = filterText
                });

                var subjetListModels = ObjectMapper.Map<IEnumerable<SubjectListModel>>(result.Items);
                SelectSubjects.ReplaceRange(subjetListModels);
            });
        }
    }
}

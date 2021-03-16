using MCV.Portal.Commands;
using MCV.Portal.Core.Threading;
using MCV.Portal.Models.Subject;
using MCV.Portal.Subject;
using MCV.Portal.Subject.Dto;
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
        public ObservableRangeCollection<SubjectListModel> Subjects { get; set; }
        //private ObservableRangeCollection<SubjectListModel> Subjects = new ObservableRangeCollection<SubjectListModel>();
        private SubjectListModel _subjects;
        //private bool _isInitialized;
        public _SampleViewModel(ISubjectAppService subjectAppService)
        {
            _subjectAppService = subjectAppService;
            Subjects = new ObservableRangeCollection<SubjectListModel>();
           // _isInitialized = false;
        }

        public async override Task InitializeAsync(object navigationData)
        {
            //_isInitialized = true;
            await FetchDataAsync();
            //return Task.CompletedTask;
        }

        public async Task LoadMoresubjectIfNeedsAsync(SubjectListModel shownItem)
        {
            if (IsBusy)
            {
                return;
            }

            await FetchDataAsync();
        }

        public SubjectListModel Subject
        {
            get => _subjects;
            set
            {
                _subjects = value;
                RaisePropertyChanged(() => Subject);
            }
        }



        //public ObservableRangeCollection<SubjectListModel> SelectSubjects
        //{
        //    get => Subjects;
        //    set
        //    {
        //        Subjects = value;
        //        //OnPropertyChanged(()=> Subjects);
        //        RaisePropertyChanged(() => SelectSubjects);
        //        if (_isInitialized)
        //        {
        //            AsyncRunner.Run(FetchDataAsync());
        //        }
        //    }
        //}
        public async Task PageAppearingAsync()
        {
            await FetchDataAsync();
        }

        public async Task FetchDataAsync() //string filterText = null
        {
            await WebRequestExecuter.Execute(async () => await _subjectAppService.GetSubject(), result =>
            {
                var users = ObjectMapper.Map<List<SubjectListModel>>(result.Items);
                return Task.CompletedTask;
            });
            //await UserConfigurationManager.GetAsync(async () =>
            //{
            //   var subj =  await _subjectAppService.GetSubject(new GetSubjectInput { Filter = filterText });
            //   _subjects = ObjectMapper.Map<ObservableRangeCollection<SubjectListDto>>(subj.Items);
            //});

            //var result = await _subjectAppService.GetSubject();

            //var subjetListModels = ObjectMapper.Map<List<SubjectListModel>>(result.Items);

            //Subjects.ReplaceRange(subjetListModels);

            //    await SetBusyAsync(async () =>
            //{

            //});
        }
    }
}

using MCV.Portal.Commands;
using MCV.Portal.Core.Threading;
using MCV.Portal.Models.Subject;
using MCV.Portal.Subject;
using MCV.Portal.ViewModels.Base;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MCV.Portal.ViewModels
{
   public class SubjectViewModel : XamarinViewModel
    {
        public ICommand PageAppearingCommand => HttpRequestCommand.Create(PageAppearingAsync);
        private readonly ISubjectAppService  _subjectAppService;
        private ObservableRangeCollection<SubjectListModel> Subjects = new ObservableRangeCollection<SubjectListModel>();
        //private SubjectListModel _selectedSubject;
        //private bool _isInitialized;
        public SubjectViewModel(ISubjectAppService subjectAppService)
        {
            _subjectAppService = subjectAppService;
        }

        //public override Task InitializeAsync(object navigationData)
        //{
        //    _isInitialized = true;

        //    return Task.CompletedTask;
        //}

        public ObservableRangeCollection<SubjectListModel> SelectSubjects
        {
            get => Subjects;
            set
            {
                Subjects = value;
                RaisePropertyChanged(() => SelectSubjects);
            }
        }

        //public SubjectListModel SelectedSubject
        //{
        //    get => _selectedSubject;
        //    set
        //    {
        //        _selectedSubject = value;
        //        RaisePropertyChanged(() => SelectedSubject);

        //        if (_isInitialized)
        //        {
        //            AsyncRunner.Run(ChangeLanguage());
        //        }
        //    }
        //}

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

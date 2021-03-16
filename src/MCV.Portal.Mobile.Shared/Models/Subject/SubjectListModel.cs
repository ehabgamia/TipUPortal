using Abp.AutoMapper;
using JetBrains.Annotations;
using MCV.Portal.Subject.Dto;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MCV.Portal.Models.Subject
{
    [AutoMapFrom(typeof(SubjectListDto))]
    [AutoMapTo(typeof(SubjectListModel))]
    public class SubjectListModel : SubjectListDto, INotifyPropertyChanged
    {
        public string subjectName => SubjectName ;
        public string reward ;
        //string email = string.Empty;
        public string Reward
        {
            get => reward;
            set => OnPropertyChanged(nameof(Reward));
        }
        public  ObservableRangeCollection<SubjectListDto> Subjects { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //protected void RaisePropertyChanged(string name)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        //}

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

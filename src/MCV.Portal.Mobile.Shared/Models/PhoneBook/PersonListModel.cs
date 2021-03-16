using Abp.AutoMapper;
using JetBrains.Annotations;
using MCV.Portal.Person.Dto;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MCV.Portal.Models.PhoneBook
{
    [AutoMapFrom(typeof(PersonListDto))]
   public class PersonListModel : PersonListDto, INotifyPropertyChanged
    {
        public string FullName => Name + " " + Surname;
        public new ObservableRangeCollection<PersonListDto> Phones { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using MCV.Portal.Models.Subject;
using MCV.Portal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCV.Portal.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectView : ContentView,IXamarinView
    {
        public SubjectView()
        {
            InitializeComponent();
        }

        
    }
}
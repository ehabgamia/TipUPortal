using MCV.Portal.Models.Subject;
using MCV.Portal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCV.Portal.Views
{
	
	public partial class _SampleView : ContentPage, IXamarinView
    {
        protected _SampleViewModel ViewModel => BindingContext as _SampleViewModel;
        public _SampleView ()
		{
			InitializeComponent ();
            //BindingContext = new _SampleViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Update the list if needed. View Model handles this logic.
            await ViewModel.PageAppearingAsync();
        }

        public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((_SampleViewModel)BindingContext).LoadMoresubjectIfNeedsAsync(e.Item as SubjectListModel);
        }
    }
}
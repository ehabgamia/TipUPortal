using MCV.Portal.Models.Subject;
using MCV.Portal.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCV.Portal.Views
{
	
	public partial class _SampleView : ContentPage, IXamarinView
    {

		public _SampleView ()
		{
			InitializeComponent ();
		}

		public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			await ((_SampleViewModel)BindingContext).LoadMoresubjectIfNeedsAsync(e.Item as SubjectListModel);
		}
	}
}
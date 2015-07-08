using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace twinkfrag.HyperTextCSharp.Views
{
	public class BindableRichTextBox : RichTextBox, INotifyPropertyChanged
	{
		#region 依存関係プロパティ
		public static readonly DependencyProperty DocumentProperty =
			DependencyProperty.Register("Document", typeof(FlowDocument),
				typeof(BindableRichTextBox), new FrameworkPropertyMetadata(null, OnRichTextItemsChanged));

		private static void OnRichTextItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var control = sender as RichTextBox;
			if (control != null) control.Document = e.NewValue as FlowDocument;
		}
		#endregion


		#region 公開プロパティ
		public new FlowDocument Document
		{
			get { return (FlowDocument)GetValue(DocumentProperty); }
			set
			{
				SetValue(DocumentProperty, value);
				RaisePropertyChanged();
			}
		}
		#endregion

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

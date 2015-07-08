using System.Windows.Documents;
using Reactive.Bindings;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Windows;
using Livet;

namespace twinkfrag.HyperTextCSharp.ViewModels
{
	public class MainWindowViewModel : ViewModel
	{
		//public ReactiveProperty<FlowDocument> RichDocuments { get; }

		private FlowDocument _RichDocuments = new FlowDocument();

		public FlowDocument RichDocuments
		{
			get { return _RichDocuments; }
			set
			{
				_RichDocuments = value;
				RaisePropertyChanged();
			}
		}

		public ReactiveProperty<BlockCollection> RichBlocks { get; } = new ReactiveProperty<BlockCollection>();

		public ReactiveProperty<string> TextDocument { get; } = new ReactiveProperty<string>();

		public MainWindowViewModel()
		{
			//RichDocuments.PropertyChanged += (s, e) => {  };

			//TextDocument = RichDocuments
			//	.Select(x => x.ToString())
			//	.ToReactiveProperty();
			this.PropertyChanged += (sender, e) =>
			{
				//if (e.PropertyName == nameof(RichDocuments))
					MessageBox.Show("changed");
			};
		}
	}
}

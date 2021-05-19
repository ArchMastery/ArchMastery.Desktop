using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Extensions.DependencyInjection;

using ArchMastery.ViewModels;

namespace ArchMastery.WPF.Host
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainViewModel ViewModel { get; set; }

		public MainWindow()
		{
			InitializeComponent();

			var wpfHost = new global::Uno.UI.Skia.Platform.WpfHost(Dispatcher, () => new ArchMastery.App());
			ViewModel = ArchMastery.App.Host.Services.GetService<MainViewModel>();
			ViewModel.PropertyChanged += ViewModel_PropertyChanged;
			root.Content = wpfHost;
		}

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
			switch (e.PropertyName)
			{
				case nameof(MainViewModel.Name):
					Title = "PUML Builder - " + ViewModel.Name ?? "<none>";
					break;
			}
		}
    }
}

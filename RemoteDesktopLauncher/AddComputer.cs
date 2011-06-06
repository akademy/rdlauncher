using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RemoteDesktopLauncher
{
	[Serializable]
	public partial class AddComputer : Form
	{
		private const string PERCENTS = "Percents";
		private const string PIXELS = "Pixels";
		private Computer _comp;

		public Computer Computer
		{
			get
			{
				return _comp;
			}
			set
			{
				_comp = value;
			}
		}
	
		public AddComputer()
		{
			Initilize( new Computer(), "Add" );
		}

		public AddComputer( Computer computer )
		{
			Initilize( computer, "Change" );
		}

		private void Initilize( Computer computer, String strCommitButtonText )
		{
			InitializeComponent();

			_comp = computer;
			btnAdd.Text = strCommitButtonText;

			InitilizeForm( _comp );
		}

		private void InitilizeForm( Computer computer )
		{
			tbxServerAddress.Text = computer.ServerAddress;
			tbxDisplayName.Text = computer.DisplayName;
			tbxUsername.Text = computer.Username;
			tbxDomain.Text = computer.Domain;

			cbxConsole.Checked = computer.ConnectToConsole;
			cbxFullScreen.Checked = computer.OpenFullScreen;

			switch( computer.Dimensions )
			{
				case( Computer.ScreenDimensions.Percentages ):
					comboDimes.Text = PERCENTS;
					nupHeight.Value = _comp.ScreenHeightPercentage;
					nupWidth.Value = _comp.ScreenWidthPercentage;
					break;

				default:
					comboDimes.Text = PIXELS;
					nupHeight.Value = computer.ScreenHeight;
					nupWidth.Value = computer.ScreenWidth;
					break;
			}
		}

		private void btnAdd_Click( object sender, EventArgs e )
		{
			_comp.ServerAddress = tbxServerAddress.Text;
			_comp.DisplayName = tbxDisplayName.Text;
			_comp.Username = tbxUsername.Text;
			_comp.Domain = tbxDomain.Text;

			_comp.ConnectToConsole = cbxConsole.Checked;
			_comp.OpenFullScreen = cbxFullScreen.Checked;

			switch( comboDimes.Text )
			{
				case ( PERCENTS ):
					_comp.Dimensions = Computer.ScreenDimensions.Percentages;
					_comp.ScreenHeightPercentage = nupHeight.Value;
					_comp.ScreenWidthPercentage = nupWidth.Value;
					break;

				default:
					_comp.Dimensions = Computer.ScreenDimensions.Pixels;
					_comp.ScreenHeight = nupHeight.Value;
					_comp.ScreenWidth = nupWidth.Value;
					break;
			}
		}
	}
}
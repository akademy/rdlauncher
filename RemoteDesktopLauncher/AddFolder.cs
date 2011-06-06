using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RemoteDesktopLauncher
{
	public partial class AddFolder : Form
	{
		private Folder _folder;

		public Folder Folder
		{
			get
			{
				return _folder;
			}
			set
			{
				_folder = value;
			}
		}
	
		public AddFolder()
		{
			Initilse( new Folder(), "Add" );
		}

		public AddFolder( Folder folder )
		{
			Initilse( folder, "Change" );
		}

		private void Initilse( Folder folder, String strCommitButtonText )
		{
			InitializeComponent();

			_folder = folder;
			btnAdd.Text = strCommitButtonText;

			InitiliseForm( _folder );
		}

		private void InitiliseForm( Folder folder )
		{
			tbxFolderName.Text = folder.FolderName;
		}

		private void btnAdd_Click( object sender, EventArgs e )
		{
			_folder.FolderName = tbxFolderName.Text;

			Close();
		}
	}
}
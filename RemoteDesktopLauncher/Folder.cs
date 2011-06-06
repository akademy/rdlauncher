using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteDesktopLauncher
{
	[Serializable]
	public class Folder : ICloneable
	{
		private Folders _folders = new Folders();
		private Computers _computers = new Computers();
		private String _strFolderName = "";

		public Folders Folders
		{
			get
			{
				return _folders;
			}
			set
			{
				_folders = value;
			}
		}

		public Computers Computers
		{
			get
			{
				return _computers;
			}
			set
			{
				_computers = value;
			}
		}

		public String FolderName
		{
			get
			{
				return _strFolderName;
			}
			set
			{
				_strFolderName = value;
			}
		}

		#region ICloneable Members

		public object Clone()
		{
			Folder folderClone = new Folder();

			folderClone.FolderName = _strFolderName;
			folderClone.Folders = (Folders)_folders.Clone();
			folderClone.Computers = (Computers)_computers.Clone();

			return folderClone;
		}

		#endregion
	}
}

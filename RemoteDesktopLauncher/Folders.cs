using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RemoteDesktopLauncher
{
	[Serializable]
	public class Folders : CollectionBase, ICloneable
	{
		//this is the indexer (readonly)
		public virtual Folder this[int Index]
		{
			get
			{
				return (Folder)this.List[Index];
			}
		}

		public virtual void Add( Folder folder )
		{
			//forward our Add method on to CollectionBase.IList.Add   
			this.List.Add( folder );
		}

		public virtual void Remove( Folder folder )
		{
			//forward our Add method on to CollectionBase.IList.Add   
			this.List.Remove( folder );
		}
		#region ICloneable Members

		public object Clone()
		{
			Folders foldersClone = new Folders();

			foreach( Folder f in this )
				foldersClone.Add( (Folder)f.Clone() );

			return foldersClone;
		}

		#endregion
	}
}

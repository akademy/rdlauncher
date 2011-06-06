using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RemoteDesktopLauncher
{
	[Serializable]
	public class Computers : CollectionBase, ICloneable
	{
		//this is the indexer (readonly)
		public virtual Computer this[int Index]
		{
			get
			{
				return (Computer)this.List[Index];
			}
		}

		public virtual void Add( Computer computer )
		{
			//forward our Add method on to CollectionBase.IList.Add   
			this.List.Add( computer );
		}

		public virtual void Remove( Computer computer )
		{
			//forward our Add method on to CollectionBase.IList.Add   
			this.List.Remove( computer );
		}
		#region ICloneable Members

		public object Clone()
		{
			Computers computersClone = new Computers();

			foreach( Computer c in this )
				computersClone.Add( (Computer)c.Clone() );

			return computersClone;
		}

		#endregion
	}
}

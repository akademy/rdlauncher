using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteDesktopLauncher
{
	[Serializable]
	public class Computer : ICloneable
	{
		[Serializable]
		public enum ScreenDimensions
		{
			Pixels,
			Percentages
		}

		private String _strServerAddress = "";
		private String _strDisplayName = "";
		private String _strDomain = "";

		private String _strUsername = "";

		private Boolean _bConnectToConsole = false;
		private Boolean _bOpenFullScreen = false;

		private Decimal _iScreenWidth = 1152;
		private Decimal _iScreenHeight = 864;

		private Decimal _iScreenWidthPercent = 100;
		private Decimal _iScreenHeightPercent = 100;

		private ScreenDimensions _dimensions = ScreenDimensions.Pixels;

		public ScreenDimensions Dimensions
		{
			get
			{
				return _dimensions;
			}
			set
			{
				_dimensions = value;
			}
		}

		public String Domain
		{
			get
			{
				return _strDomain;
			}
			set
			{
				_strDomain = value;
			}
		}
	
		public Decimal ScreenHeight
		{
			get
			{
				return _iScreenHeight;
			}
			set
			{
				_iScreenHeight = value;
			}
		}

		public Decimal ScreenWidth
		{
			get
			{
				return _iScreenWidth;
			}
			set
			{
				_iScreenWidth = value;
			}
		}
		public Decimal ScreenHeightPercentage
		{
			get
			{
				return _iScreenHeightPercent;
			}
			set
			{
				_iScreenHeightPercent = value;
			}
		}

		public Decimal ScreenWidthPercentage
		{
			get
			{
				return _iScreenWidthPercent;
			}
			set
			{
				_iScreenWidthPercent = value;
			}
		}

		public Boolean OpenFullScreen
		{
			get
			{
				return _bOpenFullScreen;
			}
			set
			{
				_bOpenFullScreen = value;
			}
		}

		public Boolean ConnectToConsole
		{
			get
			{
				return _bConnectToConsole;
			}
			set
			{
				_bConnectToConsole = value;
			}
		}

		public String Username
		{
			get
			{
				return _strUsername;
			}
			set
			{
				_strUsername = value;
			}
		}

		public String DisplayName
		{
			get
			{
				return _strDisplayName;
			}
			set
			{
				_strDisplayName = value;
			}
		}

		public String ServerAddress
		{
			get
			{
				return _strServerAddress;
			}
			set
			{
				_strServerAddress = value;
			}
		}

		#region ICloneable Members

		public object Clone()
		{
			Computer computerClone = new Computer();

			computerClone.ServerAddress = _strServerAddress;
			computerClone.DisplayName = _strDisplayName;

			computerClone.ConnectToConsole = _bConnectToConsole;
			computerClone.OpenFullScreen = _bOpenFullScreen;

			computerClone.ScreenWidth = _iScreenWidth;
			computerClone.ScreenHeight = _iScreenHeight;

			computerClone.ScreenWidthPercentage = _iScreenWidthPercent;
			computerClone.ScreenHeightPercentage = _iScreenHeightPercent;

			computerClone.Dimensions = _dimensions;

			return computerClone;
		}

		#endregion
	}
}

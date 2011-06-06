using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RemoteDesktopLauncher
{
	class CreateRdpFile
	{
		private Computer _computer;

		public CreateRdpFile( Computer comp )
		{
			_computer = comp;
		}

		public Computer Computer
		{
			get
			{
				return _computer;
			}
			set
			{
				_computer = value;
			}
		}

		/// <summary>
		/// Create an RDP file and save it
		/// </summary>
		/// <param name="strFileName">Save location</param>
		public void Save( String strFileName )
		{
			StringBuilder strBldRdp = new StringBuilder();

			Decimal 
				desktopWidth = _computer.ScreenWidth,
				desktopHeight = _computer.ScreenHeight,
				windowX = 0,
				windowY = 0;

			// TODO: Find correct screen to use
			System.Drawing.Rectangle rectScreen = Screen.PrimaryScreen.Bounds;


			if( _computer.Dimensions == Computer.ScreenDimensions.Percentages )
			{
				desktopWidth = (_computer.ScreenWidthPercentage * rectScreen.Width) / 100;
				desktopHeight = ( _computer.ScreenHeightPercentage * rectScreen.Height ) / 100;

				windowX = Math.Max( ( rectScreen.Width - desktopWidth ) / 2, 0 );
				windowY = Math.Max( ( rectScreen.Height - desktopHeight ) / 2, 0 );
			}
			
			strBldRdp.Append( "desktopwidth:i:" );
			strBldRdp.Append( desktopWidth );
			strBldRdp.AppendLine();
			strBldRdp.Append("desktopheight:i:" );
			strBldRdp.Append( desktopHeight );
			strBldRdp.AppendLine();

			strBldRdp.Append( "winposstr:s:0," ); // not sure what this zero does.
			//if( desktopWidth > rectScreen.Width )
				strBldRdp.Append( "0," ); // 1=leave as width / height.
			//else
				//strBldRdp.Append( "3," ); // 3 = maximise window (If we are wider than screen - in dual + screens - windows maximises to single window

			strBldRdp.Append( Math.Floor( windowX ) ); // x position
			strBldRdp.Append( "," );
			strBldRdp.Append( Math.Floor( windowY ) );// y Position
			strBldRdp.Append( "," );
			strBldRdp.Append( Math.Floor( desktopWidth ) ); // window width
			strBldRdp.Append( "," );
			strBldRdp.Append( Math.Floor( desktopHeight ) );  // window height
			strBldRdp.AppendLine( ); 

			strBldRdp.Append( "full address:s:" );
			strBldRdp.Append( _computer.ServerAddress );
			strBldRdp.AppendLine(); 

			strBldRdp.Append( "username:s:" );
			strBldRdp.Append( _computer.Username );
			strBldRdp.AppendLine(); 

			strBldRdp.Append( "domain:s:" );
			strBldRdp.Append( _computer.Domain );
			strBldRdp.AppendLine();

			strBldRdp.Append( Defaults() );
			strBldRdp.AppendLine(); 

			File.WriteAllText( strFileName, strBldRdp.ToString() );
		}

		// Set some defaults for the various settings.
		// (Good info here: http://dev.remotenetworktechnology.com/ts/rdpfile.htm )
		private String Defaults()
		{
			//winposstr:s:0,1,55,59,1215,957
			return @"screen mode id:i:1
session bpp:i:16
compression:i:1
keyboardhook:i:2
audiomode:i:0
redirectdrives:i:1
redirectprinters:i:1
redirectcomports:i:0
redirectsmartcards:i:1
displayconnectionbar:i:1
autoreconnection enabled:i:1
alternate shell:s:
shell working directory:s:
disable wallpaper:i:0
disable full window drag:i:0
disable menu anims:i:0
disable themes:i:0
disable cursor setting:i:0
bitmapcachepersistenable:i:1
allow desktop composition:i:0
allow font smoothing:i:0
redirectclipboard:i:1
redirectposdevices:i:0
authentication level:i:0
prompt for credentials:i:0
negotiate security layer:i:1
remoteapplicationmode:i:0
gatewayhostname:s:
gatewayusagemethod:i:4
gatewaycredentialssource:i:4
gatewayprofileusagemethod:i:0
promptcredentialonce:i:1";
		}
	}
}

/*
Example RDP document follows
 * 
desktopwidth:i:1152
desktopheight:i:864
full address:s:127.0.0.1
screen mode id:i:1
session bpp:i:16
winposstr:s:0,1,55,59,1215,957
username:s:matt
compression:i:1
keyboardhook:i:2
audiomode:i:0
redirectdrives:i:1
redirectprinters:i:1
redirectcomports:i:0
redirectsmartcards:i:1
displayconnectionbar:i:1
autoreconnection enabled:i:1
alternate shell:s:
shell working directory:s:
disable wallpaper:i:0
disable full window drag:i:0
disable menu anims:i:0
disable themes:i:0
disable cursor setting:i:0
bitmapcachepersistenable:i:1
allow desktop composition:i:0
allow font smoothing:i:0
redirectclipboard:i:1
redirectposdevices:i:0
authentication level:i:0
prompt for credentials:i:0
negotiate security layer:i:1
remoteapplicationmode:i:0
gatewayhostname:s:
gatewayusagemethod:i:4
gatewaycredentialssource:i:4
gatewayprofileusagemethod:i:0
promptcredentialonce:i:1

End of document
*/
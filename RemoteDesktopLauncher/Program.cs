using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RemoteDesktopLauncher
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			using( SingleProgramInstance spiControl = new SingleProgramInstance( "MyRDLProgram" ) )
			{
				if( spiControl.IsSingleInstance )
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault( false );
					Application.Run( new Launcher() );
				}
				else
				{
					spiControl.RaiseOtherProcess();
				}
			}
		}
	}
}
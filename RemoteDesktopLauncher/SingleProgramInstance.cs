using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Reflection;

namespace RemoteDesktopLauncher
{
	// From code written by Michael Potter
	// More information here: http://www.codeproject.com/KB/cs/cssingprocess.aspx

	/// <summary>
	/// SingleProgamInstance uses a mutex synchronization object to ensure that only one copy of process is running at
	/// a particular time.  It also allows for UI identification of the intial process by bring that window to the foreground.
	/// </summary>
	public class SingleProgramInstance : IDisposable
	{
		//Win32 API calls necesary to raise an unowned processs main window
		[DllImport( "user32.dll" )]
		private static extern bool SetForegroundWindow( IntPtr hWnd );
		[DllImport( "user32.dll" )]
		private static extern bool ShowWindowAsync( IntPtr hWnd, int nCmdShow );
		[DllImport( "user32.dll" )]
		private static extern bool IsIconic( IntPtr hWnd );

		private const int SW_RESTORE = 9;

		private Mutex _processSync;
		private bool _owned = false;

		private SingleProgramInstance() { }

		/// <summary>
		/// Initialize a named mutex and attempt to get ownership immediately.
		/// </summary>
		/// <param name="identifier">lower our chances of another process creating a mutex with the same name.</param>
		public SingleProgramInstance( string identifier )
		{
			_processSync = new Mutex( true, // desire intial ownership
												Assembly.GetExecutingAssembly().GetName().Name + identifier,
												out _owned );
		}

		/// <summary>
		/// Destructor, Release mutex (if necessary) 
		/// </summary>
		/// <remarks>Dispose() is the prefered way to release the mutex.</remarks>
		~SingleProgramInstance()
		{
			Release();
		}

		/// <summary>
		/// Check we own the mutex, if not another instance is running
		/// </summary>
		public bool IsSingleInstance
		{
			get
			{
				return _owned;
			}
		}

		/// <summary>
		/// Bring the other window into view
		/// </summary>
		/// <remarks>
		/// Using Process.ProcessName does not function properly when the name exceeds 15 characters.
		/// Using the assembly name takes care of this problem and is more accruate than other work arounds.
		/// </remarks>
		public void RaiseOtherProcess()
		{
			Process proc = Process.GetCurrentProcess();

			string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
			foreach( Process otherProc in Process.GetProcessesByName( assemblyName ) )
			{
				if( proc.Id != otherProc.Id )
				{
					// Found a "same named process".
					IntPtr hWnd = otherProc.MainWindowHandle;

					if( IsIconic( hWnd ) )
						ShowWindowAsync( hWnd, SW_RESTORE );
					else
						SetForegroundWindow( hWnd );

					return;
				}
			}
		}

		private void Release()
		{
			if( _owned )
			{
				//If we owne the mutex than release it so that
				// other "same" processes can now start.
				_processSync.ReleaseMutex();
				_owned = false;
			}
		}

		#region Implementation of IDisposable
		public void Dispose()
		{
			//release mutex (if necessary) and notify 
			// the garbage collector to ignore the destructor
			Release();
			GC.SuppressFinalize( this );
		}
		#endregion
	}
}
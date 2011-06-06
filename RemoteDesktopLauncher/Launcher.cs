using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace RemoteDesktopLauncher
{
	public partial class Launcher : Form
	{
        	private const string COMPUTER_LIST_FILENAME = "comps.xml";
		private Folder _topFolder = null;
		private TreeNode _treeNodeDragging = null;


		private ResourceManager _resourceManager = new ResourceManager( "RemoteDesktopLauncher.RemoteDesktopLauncher",
												System.Reflection.Assembly.GetExecutingAssembly() );
		/// <summary>
		/// Construct stuff.
		/// </summary>
		public Launcher()
		{
			InitializeComponent();
         SetInitialComponentsText();            

			// Use some nice images for the main tree.
			if( File.Exists( "folder.png" ) && File.Exists( "computer.png" ) )
			{
				ImageList myImageList = new ImageList();

				myImageList.Images.Add( Image.FromFile( "folder.png" ) );
				myImageList.Images.Add( Image.FromFile( "computer.png" ) );

				myImageList.ImageSize = new Size( 32, 32 );
				myImageList.ColorDepth = ColorDepth.Depth32Bit;

				// Assign the ImageList to the TreeView.
				trvComputers.ImageList = myImageList;
			}


         // Set up for initial empty folder / computer list.
         //
         _topFolder = new Folder();
         FillTree();

         trvComputers.SelectedNode = trvComputers.TopNode;
		}

		/// <summary>
		/// Set the strings from the current language.
		/// </summary>
		private void SetInitialComponentsText()
		{
			btnAddComputer.Text = _resourceManager.GetString( "ButtonAddComputer" );
			btnAddFolder.Text = _resourceManager.GetString( "ButtonAddFolder" );
			btnEdit.Text = _resourceManager.GetString( "ButtonEdit" );
			btnDelete.Text = _resourceManager.GetString( "ButtonDelete" );
			btnConnect.Text = _resourceManager.GetString( "ButtonOpen" );

			this.Text = _resourceManager.GetString( "WindowTitle" );
		}

		/// <summary>
		/// The connect button was pressed
		/// </summary>
		/// <param name="sender">Button</param>
		/// <param name="e">Events</param>
		private void btnConnect_Click( object sender, EventArgs e )
		{
			ConnectComputer();
		}

		/// <summary>
		/// Create an RDP file and use it to connect to the computer
		/// </summary>
		private void ConnectComputer()
		{
			// Trigger remote desktop.
			if( trvComputers.SelectedNode != null &&
				 trvComputers.SelectedNode.Tag is Computer )
			{
				Computer computer = (Computer)trvComputers.SelectedNode.Tag;

				CreateRdpFile rdp = new CreateRdpFile( computer );

            Path.GetTempPath();

				String strRdpFile = Path.Combine( Path.GetTempPath(), computer.DisplayName + ".rdp" );
				rdp.Save( strRdpFile );

				System.Diagnostics.Process.Start( "mstsc", "\"" + strRdpFile + "\"" );
			}
		}

		/// <summary>
		/// Add a new computer to the tree
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddComputer_Click( object sender, EventArgs e )
		{
			AddComputer addComp = new AddComputer();

			if( addComp.ShowDialog() == DialogResult.OK )
			{
                object o = trvComputers.SelectedNode.Tag;

                if (o is Computer)
                {
                    o = trvComputers.SelectedNode.Parent.Tag;
                }

				(o as Folder).Computers.Add( addComp.Computer );

				FillTree();

                trvComputers.SelectedNode = NodeFromObject((object)addComp.Computer);
                UpdateButtons();
			}
		}

		/// <summary>
		/// Add a new folder to the tree
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddFolder_Click( object sender, EventArgs e )
		{
            if (trvComputers.SelectedNode != null)
            {
                AddFolder addFolder = new AddFolder();

                if (addFolder.ShowDialog() == DialogResult.OK)
                {
                    object o = trvComputers.SelectedNode.Tag;

                    if (o is Computer)
                    {
                        o = trvComputers.SelectedNode.Parent.Tag;
                    }

                    (o as Folder).Folders.Add(addFolder.Folder);

                    FillTree();

                    trvComputers.SelectedNode = NodeFromObject(o);
                    UpdateButtons();
                }
            }
            else
            {
                MessageBox.Show( _resourceManager.GetString( "SuggestSelectObject" ) );
            }
		}

        /// <summary>
        /// Find the node an object (Computer or Folder) is on.
        /// </summary>
        /// <param name="o">The object you are looking for.</param>
        /// <returns>The node the object is on.</returns>
        private TreeNode NodeFromObject(Object o)
        {
            return NodeFromObjectRecurse(trvComputers.TopNode, o);
        }
        private TreeNode NodeFromObjectRecurse(TreeNode node, Object o)
        {
            if (node.Tag == o)
                return node;

            foreach (TreeNode subNode in node.Nodes)
                NodeFromObjectRecurse(subNode, o);

            return null;
        }

		/// <summary>
		/// Fill the tree with the folders and computers using recursion.
		/// </summary>
		private void FillTree()
		{
			TreeNode topNode = new TreeNode( _resourceManager.GetString( "TreeRootName" ) );
			topNode.Tag = _topFolder;

			TreeNode nodeSelected = null;
			object oSelected = null;
			if( trvComputers.SelectedNode != null )
				oSelected = trvComputers.SelectedNode.Tag;

			FillTreeRecurse( topNode, oSelected, ref nodeSelected );

			trvComputers.BeginUpdate();
			trvComputers.Nodes.Clear();
			trvComputers.Nodes.Add( topNode );
			trvComputers.EndUpdate();

			trvComputers.ExpandAll();
			trvComputers.SelectedNode = nodeSelected;
		}

		/// <summary>
		/// Recurse through the list of computers and folders
		/// </summary>
		/// <param name="trNode">Current tree node</param>
		/// <param name="oSelected">The selected object (folder or computer)</param>
		/// <param name="nodeSelected">The treeNode selected.</param>
		private void FillTreeRecurse( TreeNode trNode, Object oSelected, ref TreeNode nodeSelected )
		{
			Folder folder = (Folder)trNode.Tag;

			foreach( Folder f in folder.Folders )
			{
				TreeNode trSubNode = new TreeNode( /*"F: " +*/ f.FolderName , 0, 0 );
				trSubNode.Tag = f;

				FillTreeRecurse( trSubNode, oSelected, ref nodeSelected );

				if( oSelected as Folder == f )
					nodeSelected = trSubNode;

				trNode.Nodes.Add( trSubNode );
			}

			foreach( Computer c in folder.Computers )
			{
				TreeNode trSubNode = new TreeNode( /*"C: " +*/ c.DisplayName, 1, 1 );
				trSubNode.Tag = c;

				if( oSelected as Computer == c )
					nodeSelected = trSubNode;

				trNode.Nodes.Add( trSubNode );
			}
		}

		/// <summary>
		/// Update buttons after a selection is made
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trvComputers_AfterSelect( object sender, TreeViewEventArgs e )
		{
            UpdateButtons();
		}

        /// <summary>
        /// Update the buttons depending on what is selected.
        /// </summary>
        private void UpdateButtons()
        {
            if (trvComputers.SelectedNode == null)
            {
                btnAddComputer.Enabled = false;
                btnAddFolder.Enabled = false;
                btnConnect.Enabled = false;
                btnDelete.Enabled = false;
            }
            else
            {
                btnAddComputer.Enabled = true;
                btnAddFolder.Enabled = true;

                btnEdit.Enabled = btnDelete.Enabled = (trvComputers.SelectedNode != trvComputers.Nodes[0]);

                if (trvComputers.SelectedNode.Tag is Computer)
                    btnConnect.Enabled = true;
                else
                    btnConnect.Enabled = false;
            }
        }

		/// <summary>
		/// Save the computer list on program close
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Launcher_FormClosed( object sender, FormClosedEventArgs e )
		{
			// Output Folders
			XmlSerializer serializer = new XmlSerializer( typeof( Folder ) );

			try
			{
            using (StreamWriter writer = new StreamWriter(COMPUTER_LIST_FILENAME))
				{
					serializer.Serialize( writer, _topFolder );
				}
			}
			catch( System.UnauthorizedAccessException )
			{
                MessageBox.Show(_resourceManager.GetString("ErrorCantSaveComputerFile"));
			}
		}

		/// <summary>
		/// Load the xml file with the copmuters in on start.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Launcher_Load( object sender, EventArgs e )
		{
            if (File.Exists(COMPUTER_LIST_FILENAME))
			{
				XmlSerializer serializer = new XmlSerializer( typeof( Folder ) );

                using (StreamReader reader = new StreamReader(COMPUTER_LIST_FILENAME))
				{
					_topFolder = (Folder)serializer.Deserialize( reader );
				}

				FillTree();
			}
		}

		/// <summary>
		/// Delete button clicked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click( object sender, EventArgs e )
		{
			if( trvComputers.SelectedNode != null )
			{
				if( trvComputers.SelectedNode.Tag is Computer )
				{
					String strQuestion = _resourceManager.GetString("QuestionDeleteComputer");
					if( MessageBox.Show( strQuestion, _resourceManager.GetString("DialogTitleDeletion"), MessageBoxButtons.YesNo ) == DialogResult.Yes )
					{
						Folder folderParent = (Folder)trvComputers.SelectedNode.Parent.Tag;

						folderParent.Computers.Remove( (Computer)trvComputers.SelectedNode.Tag );

                  FillTree();

                  trvComputers.SelectedNode = NodeFromObject(folderParent);
                  UpdateButtons();
					}
				}
				else
				{
					Folder folder = (Folder)trvComputers.SelectedNode.Tag;

					Decimal dComputerCount = CountComputers( folder );
                    Decimal dFolderCount = CountFolders( folder );

                    String strQuestion = _resourceManager.GetString("QuestionDeleteFolder");

                    if (dComputerCount != 0 || dFolderCount != 0)
                    {
                        strQuestion += Environment.NewLine;
                        strQuestion += String.Format( _resourceManager.GetString("QuestionDeleteFolderAdditional"), dFolderCount, dComputerCount);
                    }

                    if (MessageBox.Show(strQuestion, _resourceManager.GetString("DialogTitleDeletion"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Folder folderParent = (Folder)trvComputers.SelectedNode.Parent.Tag;

                        folderParent.Folders.Remove(folder);

                        FillTree();

                        trvComputers.SelectedNode = NodeFromObject(folderParent);
                        UpdateButtons();
                    }
				}
			}
		}

		/// <summary>
		/// Count the number of computers in a folder.
		/// </summary>
		/// <param name="folder">The folder to look inside of.</param>
		/// <returns>The number of computers.</returns>
		private Decimal CountComputers( Folder folder )
		{
			Decimal dComputers = 0;
			foreach( Folder f in folder.Folders )
			{
				dComputers += CountComputers( f );
			}

			dComputers += folder.Computers.Count;

			return dComputers;
		}

        /// <summary>
        /// Count the number of sub folders below a given folder.
        /// </summary>
        /// <param name="folder">The folder to count inside of.</param>
        /// <returns>The number of folders</returns>
        private Decimal CountFolders(Folder folder)
        {
            Decimal dFolders = 0;
            foreach (Folder f in folder.Folders)
            {
                dFolders += CountFolders(f);
            }

            dFolders += folder.Folders.Count;

            return dFolders;
        }

		/// <summary>
		/// The edit button was clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click( object sender, EventArgs e )
		{
			if( trvComputers.SelectedNode != null )
			{
				if( trvComputers.SelectedNode.Tag is Computer )
				{
					Computer computer = (Computer)trvComputers.SelectedNode.Tag;
					Computer computerTemp = (Computer)computer.Clone();

					AddComputer editComp = new AddComputer( computerTemp );

					if( editComp.ShowDialog() == DialogResult.OK )
					{
						computer.ConnectToConsole = editComp.Computer.ConnectToConsole;
						computer.DisplayName = editComp.Computer.DisplayName;
						computer.OpenFullScreen = editComp.Computer.OpenFullScreen;
						computer.ScreenHeight = editComp.Computer.ScreenHeight;
						computer.ScreenWidth = editComp.Computer.ScreenWidth;
						computer.ServerAddress = editComp.Computer.ServerAddress;
						computer.Username = editComp.Computer.Username;
						computer.Dimensions = editComp.Computer.Dimensions;
						computer.ScreenHeightPercentage = editComp.Computer.ScreenHeightPercentage;
						computer.ScreenWidthPercentage = editComp.Computer.ScreenWidthPercentage;

						FillTree();
					}
				}
				else
				{
					Folder folder = (Folder)trvComputers.SelectedNode.Tag;
					AddFolder editFolder = new AddFolder( folder );

					if( editFolder.ShowDialog() == DialogResult.OK )
					{
						folder.FolderName = editFolder.Folder.FolderName;

						FillTree();
					}
				}
			}
		}

		/// <summary>
		/// Double click on a node, so attempt connection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trvComputers_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
		{
			TreeView tree = (TreeView)sender;
			TreeNode node = tree.GetNodeAt( e.X, e.Y );

			if( node != null && node.Tag is Computer )
				ConnectComputer();	
		}

		#region TreeView Drag and Drop

		private void trvComputers_DragOver( object sender, System.Windows.Forms.DragEventArgs e )
		{
			// Get the tree.
			TreeView tree = (TreeView)sender;

			// Drag and drop denied by default.
			e.Effect = DragDropEffects.None;

			// Is it a valid format?
			if( e.Data.GetData( typeof( TreeNode ) ) != null )
			{
				// Get the screen point.
				Point pt = new Point( e.X, e.Y );

				// Convert to a point in the TreeView's coordinate system.
				pt = tree.PointToClient( pt );

				// Is the mouse over a valid node?
				TreeNode node = tree.GetNodeAt( pt );
				if( node != null && node != _treeNodeDragging )
				{
					if( node.Tag is Computer )
						node = node.Parent;

					if( node.Tag is Folder && !TreeNodeIsSub( ref node, _treeNodeDragging ) )
					{
						e.Effect = DragDropEffects.Move;
						tree.SelectedNode = node;
					}
				}
			}
		}

		private void trvComputers_DragDrop( object sender, System.Windows.Forms.DragEventArgs e )
		{
			// Get the tree.
			TreeView tree = (TreeView)sender;

			// Get the screen point.
			Point pt = new Point( e.X, e.Y );

			// Convert to a point in the TreeView's coordinate system.
			pt = tree.PointToClient( pt );

			// Get the node underneath the mouse.
			TreeNode node = tree.GetNodeAt( pt );

			if( node != null && node != _treeNodeDragging )
			{
				if( node.Tag is Computer )
					node = node.Parent;

				if( node.Tag is Folder && !TreeNodeIsSub( ref node, _treeNodeDragging ) )
				{
					// Add a child node.
					node.Nodes.Add( (TreeNode)e.Data.GetData( typeof( TreeNode ) ) );
					tree.Nodes.Remove( _treeNodeDragging );
				}
			}

			// Show the newly added node if it is not already visible.
			node.Expand();
		}

		private bool TreeNodeIsSub( ref TreeNode nodeToCheck, TreeNode nodeToCheckIn )
		{
			if( nodeToCheck != null && nodeToCheckIn != null )
			{
				if( nodeToCheckIn.Nodes.Contains( nodeToCheck ) )
					return true;

				foreach( TreeNode tn in nodeToCheckIn.Nodes )
				{
					if( TreeNodeIsSub( ref nodeToCheck, tn ) )
						return true;
				}
			}

			return false;
		}
		
		private void trvComputers_ItemDrag( object sender, ItemDragEventArgs e )
		{
			// Get the tree.
			TreeView tree = (TreeView)sender;

			// Get the node underneath the mouse.
			//TreeNode node = tree.GetNodeAt( e.X, e.Y );
			//tree.SelectedNode = node;

			// Start the drag-and-drop operation with a cloned copy of the node.
			//if( node != null )
			{
				_treeNodeDragging = (TreeNode)e.Item;//node;
				tree.DoDragDrop( _treeNodeDragging.Clone(), DragDropEffects.Move );
			}
		}
		#endregion
	}
}
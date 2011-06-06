namespace RemoteDesktopLauncher
{
	partial class Launcher
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Launcher ) );
			this.trvComputers = new System.Windows.Forms.TreeView();
			this.btnAddComputer = new System.Windows.Forms.Button();
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnAddFolder = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// trvComputers
			// 
			this.trvComputers.AllowDrop = true;
			this.trvComputers.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) 
            | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.trvComputers.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.trvComputers.HideSelection = false;
			this.trvComputers.Location = new System.Drawing.Point( 13, 13 );
			this.trvComputers.Name = "trvComputers";
			this.trvComputers.Size = new System.Drawing.Size( 534, 541 );
			this.trvComputers.TabIndex = 0;
			this.trvComputers.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler( this.trvComputers_NodeMouseDoubleClick );
			this.trvComputers.DragDrop += new System.Windows.Forms.DragEventHandler( this.trvComputers_DragDrop );
			this.trvComputers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.trvComputers_AfterSelect );
			this.trvComputers.ItemDrag += new System.Windows.Forms.ItemDragEventHandler( this.trvComputers_ItemDrag );
			this.trvComputers.DragOver += new System.Windows.Forms.DragEventHandler( this.trvComputers_DragOver );
			// 
			// btnAddComputer
			// 
			this.btnAddComputer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnAddComputer.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.btnAddComputer.Location = new System.Drawing.Point( 563, 13 );
			this.btnAddComputer.Name = "btnAddComputer";
			this.btnAddComputer.Size = new System.Drawing.Size( 168, 33 );
			this.btnAddComputer.TabIndex = 1;
			this.btnAddComputer.Text = "Add computer...";
			this.btnAddComputer.UseVisualStyleBackColor = true;
			this.btnAddComputer.Click += new System.EventHandler( this.btnAddComputer_Click );
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnConnect.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.btnConnect.Location = new System.Drawing.Point( 563, 423 );
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size( 168, 131 );
			this.btnConnect.TabIndex = 3;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler( this.btnConnect_Click );
			// 
			// btnAddFolder
			// 
			this.btnAddFolder.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnAddFolder.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.btnAddFolder.Location = new System.Drawing.Point( 563, 52 );
			this.btnAddFolder.Name = "btnAddFolder";
			this.btnAddFolder.Size = new System.Drawing.Size( 168, 33 );
			this.btnAddFolder.TabIndex = 2;
			this.btnAddFolder.Text = "Add folder...";
			this.btnAddFolder.UseVisualStyleBackColor = true;
			this.btnAddFolder.Click += new System.EventHandler( this.btnAddFolder_Click );
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnDelete.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.btnDelete.Location = new System.Drawing.Point( 563, 154 );
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size( 168, 33 );
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler( this.btnDelete_Click );
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btnEdit.Font = new System.Drawing.Font( "Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte)( 0 ) ) );
			this.btnEdit.Location = new System.Drawing.Point( 563, 115 );
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size( 168, 33 );
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit...";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler( this.btnEdit_Click );
			// 
			// Launcher
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 743, 566 );
			this.Controls.Add( this.btnConnect );
			this.Controls.Add( this.btnEdit );
			this.Controls.Add( this.btnDelete );
			this.Controls.Add( this.btnAddFolder );
			this.Controls.Add( this.btnAddComputer );
			this.Controls.Add( this.trvComputers );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "Launcher";
			this.Text = "Launcher";
			this.Load += new System.EventHandler( this.Launcher_Load );
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.Launcher_FormClosed );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.TreeView trvComputers;
		private System.Windows.Forms.Button btnAddComputer;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnAddFolder;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;

	}
}
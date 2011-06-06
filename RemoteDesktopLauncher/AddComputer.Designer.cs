namespace RemoteDesktopLauncher
{
	partial class AddComputer
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbxFullScreen = new System.Windows.Forms.CheckBox();
			this.cbxConsole = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tbxServerAddress = new System.Windows.Forms.TextBox();
			this.nupWidth = new System.Windows.Forms.NumericUpDown();
			this.nupHeight = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxDisplayName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbxUsername = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbxDomain = new System.Windows.Forms.TextBox();
			this.comboDimes = new System.Windows.Forms.ComboBox();
			( (System.ComponentModel.ISupportInitialize)( this.nupWidth ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.nupHeight ) ).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point( 240, 236 );
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
			this.btnCancel.TabIndex = 15;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnAdd
			// 
			this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAdd.Location = new System.Drawing.Point( 240, 207 );
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size( 75, 23 );
			this.btnAdd.TabIndex = 14;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 13, 178 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 38, 13 );
			this.label3.TabIndex = 12;
			this.label3.Text = "Height";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 13, 154 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 35, 13 );
			this.label2.TabIndex = 10;
			this.label2.Text = "Width";
			// 
			// cbxFullScreen
			// 
			this.cbxFullScreen.AutoSize = true;
			this.cbxFullScreen.Location = new System.Drawing.Point( 60, 207 );
			this.cbxFullScreen.Name = "cbxFullScreen";
			this.cbxFullScreen.Size = new System.Drawing.Size( 103, 17 );
			this.cbxFullScreen.TabIndex = 9;
			this.cbxFullScreen.Text = "Open full screen";
			this.cbxFullScreen.UseVisualStyleBackColor = true;
			// 
			// cbxConsole
			// 
			this.cbxConsole.AutoSize = true;
			this.cbxConsole.Location = new System.Drawing.Point( 16, 240 );
			this.cbxConsole.Name = "cbxConsole";
			this.cbxConsole.Size = new System.Drawing.Size( 118, 17 );
			this.cbxConsole.TabIndex = 8;
			this.cbxConsole.Text = "Connect to console";
			this.cbxConsole.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 15 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 78, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Server address";
			// 
			// tbxServerAddress
			// 
			this.tbxServerAddress.Location = new System.Drawing.Point( 96, 12 );
			this.tbxServerAddress.Name = "tbxServerAddress";
			this.tbxServerAddress.Size = new System.Drawing.Size( 219, 20 );
			this.tbxServerAddress.TabIndex = 1;
			// 
			// nupWidth
			// 
			this.nupWidth.Location = new System.Drawing.Point( 60, 149 );
			this.nupWidth.Maximum = new decimal( new int[] {
            5000,
            0,
            0,
            0} );
			this.nupWidth.Name = "nupWidth";
			this.nupWidth.Size = new System.Drawing.Size( 120, 20 );
			this.nupWidth.TabIndex = 11;
			// 
			// nupHeight
			// 
			this.nupHeight.Location = new System.Drawing.Point( 60, 178 );
			this.nupHeight.Maximum = new decimal( new int[] {
            5000,
            0,
            0,
            0} );
			this.nupHeight.Name = "nupHeight";
			this.nupHeight.Size = new System.Drawing.Size( 120, 20 );
			this.nupHeight.TabIndex = 13;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 12, 41 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 70, 13 );
			this.label4.TabIndex = 2;
			this.label4.Text = "Display name";
			// 
			// tbxDisplayName
			// 
			this.tbxDisplayName.Location = new System.Drawing.Point( 96, 38 );
			this.tbxDisplayName.Name = "tbxDisplayName";
			this.tbxDisplayName.Size = new System.Drawing.Size( 219, 20 );
			this.tbxDisplayName.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 12, 88 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 55, 13 );
			this.label5.TabIndex = 4;
			this.label5.Text = "Username";
			// 
			// tbxUsername
			// 
			this.tbxUsername.Location = new System.Drawing.Point( 96, 85 );
			this.tbxUsername.Name = "tbxUsername";
			this.tbxUsername.Size = new System.Drawing.Size( 219, 20 );
			this.tbxUsername.TabIndex = 5;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 12, 114 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 43, 13 );
			this.label6.TabIndex = 6;
			this.label6.Text = "Domain";
			// 
			// tbxDomain
			// 
			this.tbxDomain.Location = new System.Drawing.Point( 96, 111 );
			this.tbxDomain.Name = "tbxDomain";
			this.tbxDomain.Size = new System.Drawing.Size( 219, 20 );
			this.tbxDomain.TabIndex = 7;
			// 
			// comboDimes
			// 
			this.comboDimes.FormattingEnabled = true;
			this.comboDimes.Items.AddRange( new object[] {
            "Pixels",
            "Percents"} );
			this.comboDimes.Location = new System.Drawing.Point( 191, 163 );
			this.comboDimes.Name = "comboDimes";
			this.comboDimes.Size = new System.Drawing.Size( 124, 21 );
			this.comboDimes.TabIndex = 16;
			// 
			// AddComputer
			// 
			this.AcceptButton = this.btnAdd;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size( 327, 269 );
			this.Controls.Add( this.comboDimes );
			this.Controls.Add( this.tbxDomain );
			this.Controls.Add( this.label6 );
			this.Controls.Add( this.tbxUsername );
			this.Controls.Add( this.label5 );
			this.Controls.Add( this.tbxDisplayName );
			this.Controls.Add( this.label4 );
			this.Controls.Add( this.nupHeight );
			this.Controls.Add( this.nupWidth );
			this.Controls.Add( this.btnCancel );
			this.Controls.Add( this.btnAdd );
			this.Controls.Add( this.label3 );
			this.Controls.Add( this.label2 );
			this.Controls.Add( this.cbxFullScreen );
			this.Controls.Add( this.cbxConsole );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.tbxServerAddress );
			this.Name = "AddComputer";
			this.Text = "AddComputer";
			( (System.ComponentModel.ISupportInitialize)( this.nupWidth ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.nupHeight ) ).EndInit();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox cbxFullScreen;
		private System.Windows.Forms.CheckBox cbxConsole;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbxServerAddress;
		private System.Windows.Forms.NumericUpDown nupWidth;
		private System.Windows.Forms.NumericUpDown nupHeight;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxDisplayName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbxUsername;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbxDomain;
		private System.Windows.Forms.ComboBox comboDimes;
	}
}
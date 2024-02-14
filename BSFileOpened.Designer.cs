namespace Loader
{
    partial class BSFileOpened
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this._appExit = new System.Windows.Forms.Label();
            this._bsFileOpen = new Guna.UI2.WinForms.Guna2Button();
            this._fileOpenLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 20;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // _appExit
            // 
            this._appExit.AutoSize = true;
            this._appExit.Font = new System.Drawing.Font("Disket Mono", 15.75F, System.Drawing.FontStyle.Bold);
            this._appExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._appExit.Location = new System.Drawing.Point(221, 9);
            this._appExit.Name = "_appExit";
            this._appExit.Size = new System.Drawing.Size(27, 25);
            this._appExit.TabIndex = 39;
            this._appExit.Text = "X";
            this._appExit.Click += new System.EventHandler(this._appExit_Click);
            // 
            // _bsFileOpen
            // 
            this._bsFileOpen.BackColor = System.Drawing.Color.Transparent;
            this._bsFileOpen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._bsFileOpen.BorderRadius = 7;
            this._bsFileOpen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this._bsFileOpen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this._bsFileOpen.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._bsFileOpen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this._bsFileOpen.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this._bsFileOpen.Font = new System.Drawing.Font("Disket Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._bsFileOpen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._bsFileOpen.Location = new System.Drawing.Point(43, 110);
            this._bsFileOpen.Name = "_bsFileOpen";
            this._bsFileOpen.Size = new System.Drawing.Size(176, 39);
            this._bsFileOpen.TabIndex = 40;
            this._bsFileOpen.Text = "Выбрать файлы";
            this._bsFileOpen.Click += new System.EventHandler(this._bsFileOpen_Click);
            // 
            // _fileOpenLabel
            // 
            this._fileOpenLabel.AutoSize = true;
            this._fileOpenLabel.BackColor = System.Drawing.Color.Transparent;
            this._fileOpenLabel.Font = new System.Drawing.Font("Disket Mono", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fileOpenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._fileOpenLabel.Location = new System.Drawing.Point(64, 89);
            this._fileOpenLabel.Name = "_fileOpenLabel";
            this._fileOpenLabel.Size = new System.Drawing.Size(138, 18);
            this._fileOpenLabel.TabIndex = 41;
            this._fileOpenLabel.Text = "Выбери файлы:";
            // 
            // BSFileOpened
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(260, 265);
            this.Controls.Add(this._fileOpenLabel);
            this.Controls.Add(this._bsFileOpen);
            this.Controls.Add(this._appExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BSFileOpened";
            this.Text = "BSFileOpened";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label _appExit;
        private Guna.UI2.WinForms.Guna2Button _bsFileOpen;
        private System.Windows.Forms.Label _fileOpenLabel;
    }
}
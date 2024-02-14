namespace Loader
{
    partial class Authorize
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
            this._auth = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this._authorizeConfirm = new Guna.UI2.WinForms.Guna2Button();
            this._menuName = new System.Windows.Forms.Label();
            this._appExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _auth
            // 
            this._auth.BorderRadius = 20;
            this._auth.ContainerControl = this;
            this._auth.DockIndicatorTransparencyValue = 0.6D;
            this._auth.TransparentWhileDrag = true;
            // 
            // _authorizeConfirm
            // 
            this._authorizeConfirm.BackColor = System.Drawing.Color.Transparent;
            this._authorizeConfirm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._authorizeConfirm.BorderRadius = 7;
            this._authorizeConfirm.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this._authorizeConfirm.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this._authorizeConfirm.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this._authorizeConfirm.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this._authorizeConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this._authorizeConfirm.Font = new System.Drawing.Font("Disket Mono", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._authorizeConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._authorizeConfirm.Location = new System.Drawing.Point(77, 128);
            this._authorizeConfirm.Name = "_authorizeConfirm";
            this._authorizeConfirm.Size = new System.Drawing.Size(205, 39);
            this._authorizeConfirm.TabIndex = 41;
            this._authorizeConfirm.Text = "Войти как гость";
            this._authorizeConfirm.Click += new System.EventHandler(this._authorizeConfirm_Click);
            // 
            // _menuName
            // 
            this._menuName.AutoSize = true;
            this._menuName.Font = new System.Drawing.Font("Disket Mono", 15.75F, System.Drawing.FontStyle.Bold);
            this._menuName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._menuName.Location = new System.Drawing.Point(89, 21);
            this._menuName.Name = "_menuName";
            this._menuName.Size = new System.Drawing.Size(192, 25);
            this._menuName.TabIndex = 42;
            this._menuName.Text = "CoolBsEditor";
            // 
            // _appExit
            // 
            this._appExit.AutoSize = true;
            this._appExit.Font = new System.Drawing.Font("Disket Mono", 15.75F, System.Drawing.FontStyle.Bold);
            this._appExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this._appExit.Location = new System.Drawing.Point(317, 9);
            this._appExit.Name = "_appExit";
            this._appExit.Size = new System.Drawing.Size(27, 25);
            this._appExit.TabIndex = 43;
            this._appExit.Text = "X";
            this._appExit.Click += new System.EventHandler(this._appExit_Click);
            // 
            // Authorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(356, 311);
            this.Controls.Add(this._appExit);
            this.Controls.Add(this._menuName);
            this.Controls.Add(this._authorizeConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Authorize";
            this.Text = "Authorize";
            this.Load += new System.EventHandler(this.Authorize_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm _auth;
        private Guna.UI2.WinForms.Guna2Button _authorizeConfirm;
        private System.Windows.Forms.Label _menuName;
        private System.Windows.Forms.Label _appExit;
    }
}
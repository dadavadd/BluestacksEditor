namespace Loader
{
    partial class AdForm
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
            this._adForm = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this._bsFileOpen = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // _adForm
            // 
            this._adForm.BorderRadius = 20;
            this._adForm.ContainerControl = this;
            this._adForm.DockIndicatorTransparencyValue = 0.6D;
            this._adForm.TransparentWhileDrag = true;
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
            this._bsFileOpen.Location = new System.Drawing.Point(278, 369);
            this._bsFileOpen.Name = "_bsFileOpen";
            this._bsFileOpen.Size = new System.Drawing.Size(243, 52);
            this._bsFileOpen.TabIndex = 41;
            this._bsFileOpen.Text = "Пропустить рекламу";
            // 
            // AdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._bsFileOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdForm";
            this.Text = "AdForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm _adForm;
        private Guna.UI2.WinForms.Guna2Button _bsFileOpen;
    }
}
namespace Futjalma
{
    partial class ucListPlayer
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.pbShield = new System.Windows.Forms.PictureBox();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            this.btCalcel = new System.Windows.Forms.Button();
            this.tbNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShield)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPicture
            // 
            this.pbPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPicture.Location = new System.Drawing.Point(3, 0);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(383, 385);
            this.pbPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPicture.TabIndex = 0;
            this.pbPicture.TabStop = false;
            // 
            // pbShield
            // 
            this.pbShield.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbShield.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbShield.Location = new System.Drawing.Point(383, 0);
            this.pbShield.Name = "pbShield";
            this.pbShield.Size = new System.Drawing.Size(581, 385);
            this.pbShield.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbShield.TabIndex = 1;
            this.pbShield.TabStop = false;
            // 
            // tbPlayer
            // 
            this.tbPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPlayer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbPlayer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbPlayer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tbPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlayer.Location = new System.Drawing.Point(392, 260);
            this.tbPlayer.MaxLength = 100;
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(374, 38);
            this.tbPlayer.TabIndex = 4;
            this.tbPlayer.TextChanged += new System.EventHandler(this.tbPlayer_TextChanged);
            // 
            // btCalcel
            // 
            this.btCalcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCalcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btCalcel.Location = new System.Drawing.Point(12, 336);
            this.btCalcel.Margin = new System.Windows.Forms.Padding(2);
            this.btCalcel.Name = "btCalcel";
            this.btCalcel.Size = new System.Drawing.Size(128, 38);
            this.btCalcel.TabIndex = 9;
            this.btCalcel.Text = "Back";
            this.btCalcel.UseVisualStyleBackColor = true;
            this.btCalcel.Click += new System.EventHandler(this.btCalcel_Click);
            // 
            // tbNumber
            // 
            this.tbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNumber.BackColor = System.Drawing.Color.White;
            this.tbNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNumber.Location = new System.Drawing.Point(392, 304);
            this.tbNumber.MaxLength = 3;
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.ReadOnly = true;
            this.tbNumber.Size = new System.Drawing.Size(81, 80);
            this.tbNumber.TabIndex = 10;
            this.tbNumber.Text = "00";
            this.tbNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ucListPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.btCalcel);
            this.Controls.Add(this.tbPlayer);
            this.Controls.Add(this.pbShield);
            this.Controls.Add(this.pbPicture);
            this.Name = "ucListPlayer";
            this.Size = new System.Drawing.Size(964, 388);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShield)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.PictureBox pbShield;
        private System.Windows.Forms.TextBox tbPlayer;
        private System.Windows.Forms.Button btCalcel;
        private System.Windows.Forms.TextBox tbNumber;
    }
}

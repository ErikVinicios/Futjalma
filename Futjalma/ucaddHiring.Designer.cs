namespace Futjalma
{
    partial class ucaddHiring
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucaddHiring));
            this.btSave = new System.Windows.Forms.Button();
            this.btCalcel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nupShirt = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpClosure = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbClub = new System.Windows.Forms.TextBox();
            this.tbPlayer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupShirt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btSave.Location = new System.Drawing.Point(816, 336);
            this.btSave.Margin = new System.Windows.Forms.Padding(2);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(128, 38);
            this.btSave.TabIndex = 5;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCalcel
            // 
            this.btCalcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCalcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btCalcel.Location = new System.Drawing.Point(12, 336);
            this.btCalcel.Margin = new System.Windows.Forms.Padding(2);
            this.btCalcel.Name = "btCalcel";
            this.btCalcel.Size = new System.Drawing.Size(128, 38);
            this.btCalcel.TabIndex = 6;
            this.btCalcel.Text = "Cancel";
            this.btCalcel.UseVisualStyleBackColor = true;
            this.btCalcel.Click += new System.EventHandler(this.btCalcel_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(13, 170);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Shirt";
            // 
            // nupShirt
            // 
            this.nupShirt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nupShirt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nupShirt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupShirt.Location = new System.Drawing.Point(88, 175);
            this.nupShirt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupShirt.Name = "nupShirt";
            this.nupShirt.Size = new System.Drawing.Size(46, 22);
            this.nupShirt.TabIndex = 3;
            this.nupShirt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label4.Location = new System.Drawing.Point(13, 233);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Closure";
            // 
            // dtpClosure
            // 
            this.dtpClosure.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dtpClosure.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.dtpClosure.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpClosure.Location = new System.Drawing.Point(125, 227);
            this.dtpClosure.Margin = new System.Windows.Forms.Padding(2);
            this.dtpClosure.Name = "dtpClosure";
            this.dtpClosure.Size = new System.Drawing.Size(174, 38);
            this.dtpClosure.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(13, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Club";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(13, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Player";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(964, 388);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // tbClub
            // 
            this.tbClub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbClub.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbClub.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClub.Location = new System.Drawing.Point(88, 49);
            this.tbClub.MaxLength = 100;
            this.tbClub.Name = "tbClub";
            this.tbClub.Size = new System.Drawing.Size(840, 38);
            this.tbClub.TabIndex = 1;
            this.tbClub.TextChanged += new System.EventHandler(this.tbClub_TextChanged);
            // 
            // tbPlayer
            // 
            this.tbPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPlayer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tbPlayer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPlayer.Location = new System.Drawing.Point(109, 109);
            this.tbPlayer.MaxLength = 100;
            this.tbPlayer.Name = "tbPlayer";
            this.tbPlayer.Size = new System.Drawing.Size(819, 38);
            this.tbPlayer.TabIndex = 12;
            // 
            // ucaddHiring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbPlayer);
            this.Controls.Add(this.tbClub);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpClosure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nupShirt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btCalcel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ucaddHiring";
            this.Size = new System.Drawing.Size(964, 388);
            ((System.ComponentModel.ISupportInitialize)(this.nupShirt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCalcel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nupShirt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpClosure;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tbClub;
        private System.Windows.Forms.TextBox tbPlayer;
    }
}

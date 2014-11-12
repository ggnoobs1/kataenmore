namespace PacketAnalyzer
{
    partial class PAForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
       public System.ComponentModel.IContainer components = null;

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
            this.PGridSend = new System.Windows.Forms.DataGridView();
            this.Header = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Channel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flags = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PGridRecv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkRecv = new System.Windows.Forms.CheckBox();
            this.chkSend = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PGridSend)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PGridRecv)).BeginInit();
            this.SuspendLayout();
            // 
            // PGridSend
            // 
            this.PGridSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PGridSend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Header,
            this.Size,
            this.Channel,
            this.Flags});
            this.PGridSend.Location = new System.Drawing.Point(6, 42);
            this.PGridSend.Name = "PGridSend";
            this.PGridSend.Size = new System.Drawing.Size(246, 297);
            this.PGridSend.TabIndex = 6;
            this.PGridSend.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PGridSend_MouseDown);
            // 
            // Header
            // 
            this.Header.Frozen = true;
            this.Header.HeaderText = "Header";
            this.Header.MaxInputLength = 4;
            this.Header.Name = "Header";
            this.Header.ReadOnly = true;
            this.Header.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Header.Width = 50;
            // 
            // Size
            // 
            this.Size.Frozen = true;
            this.Size.HeaderText = "Size";
            this.Size.MaxInputLength = 5;
            this.Size.Name = "Size";
            this.Size.ReadOnly = true;
            this.Size.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Size.Width = 50;
            // 
            // Channel
            // 
            this.Channel.Frozen = true;
            this.Channel.HeaderText = "Channel";
            this.Channel.MaxInputLength = 1;
            this.Channel.Name = "Channel";
            this.Channel.ReadOnly = true;
            this.Channel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Channel.Width = 50;
            // 
            // Flags
            // 
            this.Flags.Frozen = true;
            this.Flags.HeaderText = "Flags";
            this.Flags.MaxInputLength = 1;
            this.Flags.Name = "Flags";
            this.Flags.ReadOnly = true;
            this.Flags.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Flags.Width = 60;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.PGridRecv);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.chkRecv);
            this.groupBox1.Controls.Add(this.chkSend);
            this.groupBox1.Controls.Add(this.PGridSend);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 401);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // PGridRecv
            // 
            this.PGridRecv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PGridRecv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.PGridRecv.Location = new System.Drawing.Point(323, 42);
            this.PGridRecv.Name = "PGridRecv";
            this.PGridRecv.Size = new System.Drawing.Size(246, 297);
            this.PGridRecv.TabIndex = 12;
            this.PGridRecv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PGridRecv_MouseDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Header";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 4;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Size";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Channel";
            this.dataGridViewTextBoxColumn3.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.Frozen = true;
            this.dataGridViewTextBoxColumn4.HeaderText = "Flags";
            this.dataGridViewTextBoxColumn4.MaxInputLength = 1;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(126, 14);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 25);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkRecv
            // 
            this.chkRecv.AutoSize = true;
            this.chkRecv.Checked = true;
            this.chkRecv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecv.Location = new System.Drawing.Point(323, 19);
            this.chkRecv.Name = "chkRecv";
            this.chkRecv.Size = new System.Drawing.Size(55, 17);
            this.chkRecv.TabIndex = 9;
            this.chkRecv.Text = "RECV";
            this.chkRecv.UseVisualStyleBackColor = true;
            // 
            // chkSend
            // 
            this.chkSend.AutoSize = true;
            this.chkSend.Checked = true;
            this.chkSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSend.Location = new System.Drawing.Point(6, 19);
            this.chkSend.Name = "chkSend";
            this.chkSend.Size = new System.Drawing.Size(56, 17);
            this.chkSend.TabIndex = 8;
            this.chkSend.Text = "SEND";
            this.chkSend.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 345);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 20);
            this.textBox1.TabIndex = 13;
            // 
            // PAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 418);
            this.Controls.Add(this.groupBox1);
            this.Name = "PAForm";
            this.Text = "Packet Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.PGridSend)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PGridRecv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView PGridSend;
        public System.Windows.Forms.DataGridViewTextBoxColumn pSize;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox chkRecv;
        public System.Windows.Forms.CheckBox chkSend;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn Header;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size;
        private System.Windows.Forms.DataGridViewTextBoxColumn Channel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flags;
        public System.Windows.Forms.DataGridView PGridRecv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.TextBox textBox1;

    }
}
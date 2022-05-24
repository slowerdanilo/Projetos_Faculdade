namespace WindowsFormsApp1
{
    partial class frmQuartos
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
            this.dg2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reservarQuartoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liberarQuartoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisponiveis = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnRelatorio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg2
            // 
            this.dg2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dg2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg2.ContextMenuStrip = this.contextMenuStrip1;
            this.dg2.Location = new System.Drawing.Point(12, 124);
            this.dg2.Name = "dg2";
            this.dg2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg2.Size = new System.Drawing.Size(577, 235);
            this.dg2.TabIndex = 0;
            this.dg2.AllowUserToAddRowsChanged += new System.EventHandler(this.dg2_AllowUserToAddRowsChanged);
            this.dg2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg2_CellClick);
            this.dg2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg2_CellEnter);
            this.dg2.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg2_CellEnter);
            this.dg2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dg2_CellFormatting);
            this.dg2.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg2_CellLeave);
            this.dg2.Click += new System.EventHandler(this.dg2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservarQuartoToolStripMenuItem,
            this.liberarQuartoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 48);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // reservarQuartoToolStripMenuItem
            // 
            this.reservarQuartoToolStripMenuItem.Name = "reservarQuartoToolStripMenuItem";
            this.reservarQuartoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.reservarQuartoToolStripMenuItem.Text = "Reservar Quarto";
            this.reservarQuartoToolStripMenuItem.Click += new System.EventHandler(this.reservarQuartoToolStripMenuItem_Click);
            // 
            // liberarQuartoToolStripMenuItem
            // 
            this.liberarQuartoToolStripMenuItem.Name = "liberarQuartoToolStripMenuItem";
            this.liberarQuartoToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.liberarQuartoToolStripMenuItem.Text = "Liberar Quarto";
            this.liberarQuartoToolStripMenuItem.Click += new System.EventHandler(this.liberarQuartoToolStripMenuItem_Click);
            // 
            // btnDisponiveis
            // 
            this.btnDisponiveis.Location = new System.Drawing.Point(423, 94);
            this.btnDisponiveis.Name = "btnDisponiveis";
            this.btnDisponiveis.Size = new System.Drawing.Size(166, 24);
            this.btnDisponiveis.TabIndex = 1;
            this.btnDisponiveis.Text = "Disponíveis";
            this.btnDisponiveis.UseVisualStyleBackColor = true;
            this.btnDisponiveis.Click += new System.EventHandler(this.btnDisponiveis_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Reservados";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.Location = new System.Drawing.Point(444, 365);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(145, 23);
            this.btnRelatorio.TabIndex = 9;
            this.btnRelatorio.Text = "Relatorio";
            this.btnRelatorio.UseVisualStyleBackColor = true;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // frmQuartos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(601, 400);
            this.Controls.Add(this.btnRelatorio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDisponiveis);
            this.Controls.Add(this.dg2);
            this.Name = "frmQuartos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quartos";
            this.Shown += new System.EventHandler(this.frmQuartos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dg2)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg2;
        private System.Windows.Forms.Button btnRelatorio;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem reservarQuartoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liberarQuartoToolStripMenuItem;
        public System.Windows.Forms.Button btnDisponiveis;
        public System.Windows.Forms.Button button2;
    }
}
namespace AssistenciaFuncionarios
{
    partial class TelaPrincipal
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
            dataGridView1 = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Cliente = new DataGridViewTextBoxColumn();
            Aparelho = new DataGridViewTextBoxColumn();
            Data = new DataGridViewTextBoxColumn();
            Valor = new DataGridViewTextBoxColumn();
            Status = new DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id, Cliente, Aparelho, Data, Valor, Status });
            dataGridView1.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridView1.GridColor = SystemColors.InfoText;
            dataGridView1.Location = new Point(12, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(330, 195);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // Id
            // 
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.Visible = false;
            Id.Width = 23;
            // 
            // Cliente
            // 
            Cliente.HeaderText = "Cliente";
            Cliente.Name = "Cliente";
            Cliente.Width = 69;
            // 
            // Aparelho
            // 
            Aparelho.HeaderText = "Aparelho";
            Aparelho.Name = "Aparelho";
            Aparelho.Width = 80;
            // 
            // Data
            // 
            Data.HeaderText = "Data";
            Data.Name = "Data";
            Data.Width = 56;
            // 
            // Valor
            // 
            Valor.HeaderText = "Valor";
            Valor.Name = "Valor";
            Valor.Width = 58;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.Items.AddRange(new object[] { "Aguardando análise", "Em manutenção", "Aguardando peça", "Pronto", "Entregue" });
            Status.Name = "Status";
            Status.Resizable = DataGridViewTriState.True;
            Status.SortMode = DataGridViewColumnSortMode.Automatic;
            Status.Width = 64;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 349);
            Controls.Add(dataGridView1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TelaPrincipal";
            Text = "TelaPrincipal";
            Load += TelaPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion


        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn Aparelho;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Valor;
        private DataGridViewComboBoxColumn Status;
    }
}
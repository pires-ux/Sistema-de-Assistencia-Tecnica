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
            listView1 = new ListView();
            columnCliente = new ColumnHeader();
            columnAparelho = new ColumnHeader();
            columnValor = new ColumnHeader();
            columnStatus = new ColumnHeader();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnCliente, columnAparelho, columnValor, columnStatus });
            listView1.Location = new Point(65, 119);
            listView1.Name = "listView1";
            listView1.Size = new Size(405, 138);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnCliente
            // 
            columnCliente.Text = "Cliente";
            columnCliente.TextAlign = HorizontalAlignment.Center;
            columnCliente.Width = 100;
            // 
            // columnAparelho
            // 
            columnAparelho.Text = "Aparelho";
            columnAparelho.TextAlign = HorizontalAlignment.Center;
            columnAparelho.Width = 100;
            // 
            // columnValor
            // 
            columnValor.Text = "Valor";
            columnValor.TextAlign = HorizontalAlignment.Center;
            columnValor.Width = 100;
            // 
            // columnStatus
            // 
            columnStatus.Text = "Status";
            columnStatus.TextAlign = HorizontalAlignment.Center;
            columnStatus.Width = 100;
            // 
            // TelaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(619, 349);
            Controls.Add(listView1);
            Name = "TelaPrincipal";
            Text = "TelaPrincipal";
            Load += TelaPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnAparelho;
        private ColumnHeader columnValor;
        private ColumnHeader columnStatus;
        private ColumnHeader columnCliente;
    }
}
namespace PROJETO_CANTINA
{
    partial class frmTela1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstCardapio = new ListBox();
            btnAdicionar = new Button();
            lstPedido = new ListBox();
            btnRemover = new Button();
            btnFinalizar = new Button();
            lblTotal = new Label();
            lblValor = new Label();
            cboPagamento = new ComboBox();
            SuspendLayout();
            // 
            // lstCardapio
            // 
            lstCardapio.FormattingEnabled = true;
            lstCardapio.ItemHeight = 15;
            lstCardapio.Location = new Point(37, 33);
            lstCardapio.Name = "lstCardapio";
            lstCardapio.Size = new Size(259, 124);
            lstCardapio.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(325, 33);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(110, 53);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // lstPedido
            // 
            lstPedido.FormattingEnabled = true;
            lstPedido.ItemHeight = 15;
            lstPedido.Location = new Point(478, 33);
            lstPedido.Name = "lstPedido";
            lstPedido.Size = new Size(259, 124);
            lstPedido.TabIndex = 2;
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(325, 120);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(110, 53);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(325, 284);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(110, 53);
            btnFinalizar.TabIndex = 4;
            btnFinalizar.Text = "Finalizar";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(300, 208);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(64, 15);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Valor Total:";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValor.Location = new Point(379, 194);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(44, 32);
            lblValor.TabIndex = 6;
            lblValor.Text = "R$";
            // 
            // cboPagamento
            // 
            cboPagamento.FormattingEnabled = true;
            cboPagamento.Location = new Point(282, 239);
            cboPagamento.Name = "cboPagamento";
            cboPagamento.Size = new Size(199, 23);
            cboPagamento.TabIndex = 7;
            cboPagamento.SelectedIndexChanged += cboPagamento_SelectedIndexChanged;
            cboPagamento.Click += cboPagamento_SelectedIndexChanged;
            // 
            // frmTela1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboPagamento);
            Controls.Add(lblValor);
            Controls.Add(lblTotal);
            Controls.Add(btnFinalizar);
            Controls.Add(btnRemover);
            Controls.Add(lstPedido);
            Controls.Add(btnAdicionar);
            Controls.Add(lstCardapio);
            Name = "frmTela1";
            Text = "Tela_1_Pedidos";
            Load += frmTela1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstCardapio;
        private Button btnAdicionar;
        private ListBox lstPedido;
        private Button btnRemover;
        private Button btnFinalizar;
        private Label lblTotal;
        private Label lblValor;
        private ComboBox cboPagamento;
    }
}

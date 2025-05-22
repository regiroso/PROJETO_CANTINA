using Microsoft.VisualBasic;

namespace PROJETO_CANTINA
{
    public partial class frmTela1 : Form
    {

        // Lista de Formas de Pagamento
        List<string> pagamento = new List<string>()
        {
            "Débito",
            "Crédito",
            "Pix",
            "Dinheiro",
        };

        // Dicionário com nome do item e preço
        Dictionary<string, decimal> preco = new Dictionary<string, decimal>
            {
                { "Pão de Queijo", 3.50m },
                { "Coxinha", 5.00m },
                { "Pastel de Carne", 6.00m },
                { "Pastel de Queijo", 5.50m },
                { "Suco Natural (300 ml)", 4.00m },
                { "Refrigerante Lata", 4.50m },
                { "Hamburguer Simples", 8.00m },
                { "Hamburguer com Queijo", 9.00m },
                { "X-Tudo", 12.00m },
                { "Água Mineral (500 ml)", 2.50m }
            };

        // Dicionário para armazenar as quantidades dos itens no carrinho
        Dictionary<string, int> pedido = new Dictionary<string, int>();




        public frmTela1()
        {
            InitializeComponent();
        }

        private void frmTela1_Load(object sender, EventArgs e)
        {
            lstCardapio.Items.Clear();
            foreach (var item in preco)
            {
                lstCardapio.Items.Add($"{item.Key} R$: {item.Value:0.00}");
            }
            cboPagamento.DataSource = pagamento;


            lblValor.Text = "R$: 0,00";
        }

        private void AtualizarListaCarrinho()
        {
            lstPedido.Items.Clear();

            foreach (var item in pedido)
            {
                // Mostrar no formato "2x Refrigerante"
                lstPedido.Items.Add($"{item.Value}x {item.Key}");
            }
        }

        private void AtualizarTotal()
        {
            decimal total = 0;

            foreach (var item in pedido)
            {
                if (preco.ContainsKey(item.Key))
                {
                    total += preco[item.Key] * item.Value;
                }
            }

            lblValor.Text = $"R$: {total:0.00}";
        }


        // Melhor posição?
        decimal valorDinheiro;
        bool finalizado = true;



        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (lstCardapio.SelectedItem != null)
            {
                // Extrair o nome do item selecionado (antes do " R$")
                string nome = lstCardapio.SelectedItem.ToString().Split(new string[] { " R$" }, StringSplitOptions.None)[0];

                // Incrementar quantidade no dicionário do pedido
                if (pedido.ContainsKey(nome))
                {
                    pedido[nome]++;
                }
                else
                {
                    pedido[nome] = 1;
                }

                AtualizarListaCarrinho(); // ainda não está pronto
                AtualizarTotal(); // ainda não está pronto
            }
            else
            {
                MessageBox.Show("Selecione um item do cardápio.");
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (lstPedido.SelectedItem != null)
            {
                // Extrair o nome do item selecionado no carrinho (ex: "2x Refrigerante")
                string itemSelecionado = lstPedido.SelectedItem.ToString();

                // O nome fica após o "x " (ex: "2x Refrigerante" -> "Refrigerante")
                int pos = itemSelecionado.IndexOf("x ");
                if (pos >= 0)
                {
                    string nome = itemSelecionado.Substring(pos + 2);

                    if (pedido.ContainsKey(nome))
                    {
                        pedido[nome]--;
                        if (pedido[nome] <= 0)
                        {
                            pedido.Remove(nome);
                        }
                    }

                    AtualizarListaCarrinho();
                    AtualizarTotal();
                }

            }
            else
            {
                MessageBox.Show("Selecione um item do carrinho.");
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            string cliente = Interaction.InputBox("Digite o nome do Cliente:");

            DialogResult resultado = MessageBox.Show("Deseja finalizar o pedido?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cboPagamento.SelectedItem != null && cboPagamento.SelectedItem.ToString() == "Dinheiro")
            {
                string valor = Interaction.InputBox("Digite o valor pago em dinheiro:");
                if (string.IsNullOrEmpty(valor) || !decimal.TryParse(valor, out valorDinheiro))
                {
                    MessageBox.Show("Valor inválido.");
                    return;
                }
            }

            if (resultado == DialogResult.Yes)
            {
                if (pedido.Count == 0)
                {
                    MessageBox.Show("O carrinho está vazio!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Montar extrato
                System.Text.StringBuilder extrato = new System.Text.StringBuilder();
                extrato.AppendLine("********* Extrato do Pedido *********");
                extrato.AppendLine();

                decimal total = 0;
                bool pagamentoValido = true;
                decimal troco = 0;

                foreach (var item in pedido)
                {
                    string nome = item.Key;
                    int quantidade = item.Value;
                    decimal precoUnitario = preco[nome];
                    decimal subtotal = precoUnitario * quantidade;

                    extrato.AppendLine($"{quantidade}x {nome} - R$ {precoUnitario:0.00}  |  Subtotal: R$ {subtotal:0.00}");

                    total += subtotal;
                }

                if (cboPagamento.SelectedItem != null && cboPagamento.SelectedItem.ToString() == "Dinheiro")
                {
                    if (valorDinheiro >= total)
                    {
                        troco = valorDinheiro - total;
                    }
                    else
                    {
                        pagamentoValido = false;
                    }
                }

                extrato.AppendLine();
                extrato.AppendLine($"Total: R$ {total:0.00}");

                if (cboPagamento.SelectedItem.ToString() == "Dinheiro")
                {
                    extrato.AppendLine($"Valor Pago: R$ {valorDinheiro:0.00}");
                    extrato.AppendLine($"Troco: R$ {troco:0.00}");
                }

                extrato.AppendLine("Cliente: " + cliente);
                extrato.AppendLine("*************************************");

                if (pagamentoValido)
                {
                    MessageBox.Show(extrato.ToString(), "Extrato do Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pedido.Clear();
                    AtualizarListaCarrinho();
                    AtualizarTotal();
                }
                else
                {
                    MessageBox.Show("Valor insuficiente para finalizar o pedido.");
                }
            }
            else
            {
                MessageBox.Show("Pedido não foi finalizado.");
            }
        }

        private void cboPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}

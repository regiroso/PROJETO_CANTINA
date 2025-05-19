using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PROJETO_CANTINA
{
    public partial class frmTela1 : Form
    {
        // Dicionário com nome do item e preço
        Dictionary<string, decimal> preco = new Dictionary<string, decimal>
            {
                { "Coxinha", 5.00m },
                { "Pastel", 6.00m },
                { "Suco", 3.00m },
                { "Refrigerante", 4.50m },
                { "Brigadeiro", 2.00m }
            };

        // Dicionário para armazenar as quantidades dos itens no carrinho
        Dictionary<string, int> pedido = new Dictionary<string, int>();

        //carrinho >>>> pedido
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
            DialogResult resultado = MessageBox.Show("Deseja finalizar o pedido?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (pedido.Count == 0)
                {
                    MessageBox.Show("O carrinho está vazio!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Montar o extrato formatado
                System.Text.StringBuilder extrato = new System.Text.StringBuilder();
                extrato.AppendLine("********* Extrato do Pedido *********");
                extrato.AppendLine();

                decimal total = 0;

                foreach (var item in pedido)
                {
                    string nome = item.Key;
                    int quantidade = item.Value;
                    decimal precoUnitario = preco[nome];
                    decimal subtotal = precoUnitario * quantidade;

                    extrato.AppendLine($"{quantidade}x {nome} - R$ {precoUnitario:0.00}  |  Subtotal: R$ {subtotal:0.00}");

                    total += subtotal;
                }

                extrato.AppendLine();
                extrato.AppendLine($"Total: R$ {total:0.00}");
                extrato.AppendLine("*************************************");

                // Exibir o extrato para o usuário
                MessageBox.Show(extrato.ToString(), "Extrato do Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Aqui você pode adicionar código para "finalizar" de fato o pedido, como limpar o carrinho, salvar dados, etc.
                pedido.Clear();
                AtualizarListaCarrinho();
                AtualizarTotal();
            }
            else
            {
                // O usuário clicou em "Não"
                MessageBox.Show("Pedido não foi finalizado.");
            }
        }

        
    }
}

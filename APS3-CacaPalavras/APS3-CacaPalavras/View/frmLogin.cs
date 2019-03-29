using APS3_CacaPalavras.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APS3_CacaPalavras
{
    public partial class Form1 : Form
    {
        public int i = 0; //contador de eventos
        public int[] firstCell = null; //armazena a primeira posição na tabela que foi selecionada [x,y]
        int[] auxCell = null; //armazena [x, y] da celula mais distante da firstCell

        public Form1()
        {
            InitializeComponent();
            //remover seleção inicial do dg 
            dg.ClearSelection();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.PopularTabelaFormatarTabela();
        }
        private void PopularTabelaFormatarTabela()
        {
            //popular
            for(int p = 0; p < 20; p++)
            {
                dg.Rows.Add();
            }
            for(int i =0; i<dg.Rows.Count; ++i)
            {
                for(int c =0; c < dg.Columns.Count; c++)
                {
                    dg.Rows[i].Cells[c].Value = string.Format("{0}, {1}", i, c);
                }

            }

            //formatar

            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dg.AllowUserToResizeRows = false;


            foreach (DataGridViewColumn column in dg.Columns)
            {
                column.Width = 35; //tamanho fixo da primeira coluna
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                column.Resizable = DataGridViewTriState.False;
            }
        }




        private void dg_SelectionChanged(object sender, EventArgs e)
        {
            this.Text = "";
            //contador de celulas verificadas no foreach
            int teste = 0;

            //verificando se já foi definida a celula inicial
            if (dg.SelectedCells.Count == 1)
            {
                firstCell = new int[] { Convert.ToInt16(dg.CurrentCell.RowIndex), Convert.ToInt16(dg.CurrentCell.ColumnIndex) };
            }

            //verificando se já existem pelo menos 2 celulas selecionadas
            if (dg.SelectedCells.Count > 1)
            {
                //definindo a firstCell como celula aux para verificacão
                auxCell = new int[2] { firstCell[0], firstCell[1] };

                //loop nas celulas selecionadas para encontrar celula mais distante 
                foreach (DataGridViewCell celulaVolta in dg.SelectedCells)
                {
                    teste++;
                    //Verificando se a distância para x é maior e se a distância para y é maior ou igual a da celula selecionada atualmente, em relação à firstCell
                    if (Math.Abs(celulaVolta.RowIndex - firstCell[0]) >= Math.Abs(auxCell[0] - firstCell[0]) && Math.Abs(celulaVolta.ColumnIndex - firstCell[1]) >= Math.Abs(auxCell[1] - firstCell[1]))// && Math.Abs(firstCell[1] - celulaVolta.ColumnIndex) >= Math.Abs(auxCell[1] - firstCell[1]))
                    {
                        auxCell[0] = celulaVolta.RowIndex;
                        auxCell[1] = celulaVolta.ColumnIndex;
                    }
                }

                //caso a distância de X seja maior que de Y: Movimento VERTICAL
                if (Math.Abs(auxCell[0] - firstCell[0]) == Math.Abs(auxCell[1] - firstCell[1]))
                {
                    foreach (DataGridViewCell cell in dg.SelectedCells)
                    {
                        if (Math.Abs(cell.ColumnIndex - firstCell[1]) != Math.Abs(cell.RowIndex - firstCell[0]))
                        {
                            dg.Rows[cell.RowIndex].Cells[cell.ColumnIndex].Selected = false;
                        }
                        this.Text = "@D - ";

                    }
                }

                this.Text = this.Text + string.Format("{0} SELECIONADAS/ firstCell: [{1}, {2}]/ auxCell é: [{3}, {4}]/ TOTAL LOOP: [{5}]", dg.SelectedCells.Count, firstCell[0], firstCell[1], auxCell[0], auxCell[1], teste);
            }

        }

        private void dg_MouseUp(object sender, MouseEventArgs e)
        {

            firstCell = null;
            auxCell = null;
            dg.ClearSelection();

        }

        private void dg_CurrentCellChanged(object sender, EventArgs e)
        {
            /*
            if (frow != null)
            {
                MessageBox.Show("chegueeeeeeei");
                //this.Text = "cheguei aqui";
                if (Convert.ToInt16(dg.SelectedColumns[0].Index) == frow[1])
                {
                    MessageBox.Show("movimento vertical");
                }
                else if (Convert.ToInt16(dg.SelectedRows[0].Index) == frow[0])
                {
                    MessageBox.Show("movimento vertical");
                }
            }
            */
        }
    }
}

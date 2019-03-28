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
        string movimento; //a partir da movimentação, será determinado se o motimento foi horizontal ['h'] ou vertical ['v']
        int[] auxCell = null;

        public Form1()
        {
            InitializeComponent();
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dg.AllowUserToResizeRows = false;

            foreach (DataGridViewColumn column in dg.Columns)
            {
                column.Width = 30; //tamanho fixo da primeira coluna
            }

            foreach (DataGridViewColumn row in dg.Rows)
            {
                row.Width = 30; //tamanho fixo da primeira coluna
            }

            dg.ClearSelection();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.PopularTabela();
        }

        private void PopularTabela()
        {
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
        }

        private void dg_SelectionChanged(object sender, EventArgs e)
        {
            //verificando se já foi definida a celula inicial
            if (dg.SelectedCells.Count == 1)
            {
                firstCell = new int[] { Convert.ToInt16(dg.CurrentCell.RowIndex), Convert.ToInt16(dg.CurrentCell.ColumnIndex) };
            }

            //verificando se já existem pelo menos 2 celulas selecionadas
            if (dg.SelectedCells.Count > 1)
            {
                foreach(DataGridViewCell celulaVolta in dg.SelectedCells)
                {
                    if (auxCell == null)
                    {
                        auxCell = new int[2] { firstCell[0], firstCell[1]};
                    }
                    else
                    {   //Verificando se a distância para x é maior e se a distância para y é maior ou igual a da celula selecionada atualmente, em relação à firstCell
                        if( (Math.Abs(firstCell[0] - celulaVolta.RowIndex) > Math.Abs(firstCell[0] - auxCell[0]) || Math.Abs(firstCell[0] - celulaVolta.RowIndex) > Math.Abs(firstCell[1] - auxCell[1])  ) && Math.Abs(firstCell[1] - celulaVolta.ColumnIndex) >= Math.Abs(auxCell[1] - firstCell[1]))
                        {
                            auxCell[0] = celulaVolta.RowIndex;
                            auxCell[1] = celulaVolta.ColumnIndex;
                        }
                        else
                        //Verificando se a distância para y é maior e se a distância para x é maior ou igual a da celula selecionada atualmente, em relação à firstCell    
                        if ( (Math.Abs(firstCell[1] - celulaVolta.ColumnIndex) > Math.Abs(firstCell[1] - auxCell[1]) || Math.Abs(firstCell[1] - celulaVolta.ColumnIndex) > Math.Abs(firstCell[0] - auxCell[0]) ) && Math.Abs(firstCell[0] - celulaVolta.ColumnIndex) >= Math.Abs(auxCell[0] - firstCell[0]))
                        {
                            auxCell[0] = celulaVolta.RowIndex;
                            auxCell[1] = celulaVolta.ColumnIndex;

                        }
                        this.Text = string.Format("Inicial: [{0}, {1}] - celula mais distante é: [{2}, {3}]", firstCell[0], firstCell[1], auxCell[0], auxCell[1]);

                    }
                }
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

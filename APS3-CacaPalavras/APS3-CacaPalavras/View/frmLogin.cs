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
        public int[] frow = null; //armazena a primeira posição na tabela que foi selecionada [x,y]
        string movimento; //a partir da movimentação, será determinado se o motimento foi horizontal ['h'] ou vertical ['v']

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
            for(int i =0; i<19; ++i)
            {
                dg.Rows.Add(1, 2, 3, 4, 5, 6, 7, 1, 2, 3, 4, 5, 6, 7, 8, 9, 5, 3);

            }
        }

        private void dg_SelectionChanged(object sender, EventArgs e)
        {

            if (frow == null)
            {
                frow = new int[] { Convert.ToInt16(dg.CurrentCell.RowIndex), Convert.ToInt16(dg.CurrentCell.ColumnIndex) };
            }

            this.Text = string.Format("SelectionChanged - > [{0}, {1}]", frow[0], frow[1]);


            if (frow == null)
            {
                MessageBox.Show("fodseu");
            }
            string a = string.Format("({0})", dg.SelectedCells.Count);
            for(int c = 0; c < dg.SelectedCells.Count; c++)
            {

            }
            //this.Text = a;
        }

        private void dg_MouseUp(object sender, MouseEventArgs e)
        {

            frow = null;
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

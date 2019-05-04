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

namespace APS3_CacaPalavras.View
{
    public partial class FormJogo : Form
    {


        public FormJogo()
        {
            InitializeComponent();
        }

        private void FrmJogo_Load(object sender, EventArgs e)
        {
            dataGridJogo = DataGridJogo.PopularGrid(dataGridJogo);
        }
        private void IniciarJogo()
        {

        }
        private void CriarJogo()
        {

        }


        //eventos
        private void dataGridJogo_SelectionChanged(object sender, EventArgs e)
        {
            DataGridJogo.IdentificarMov(dataGridJogo);
            DataGridJogo.SelecionarCelulasMovOrientacao(dataGridJogo);
            DataGridJogo.DeselecionarCelulasNaoMovOrientacao(dataGridJogo);
        }

        private void dataGridJogo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (DataGridJogo.firstCell != null)
                {
                    DataGridJogo.distCell = new int[2] { e.RowIndex, e.ColumnIndex };
                }
            }
        }

        private void dataGridJogo_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridJogo.firstCell = null;
            DataGridJogo.distCell = null;
            DataGridJogo.distMovCell = null;
            DataGridJogo.movSentido = null;
        }
        private void dataGridJogo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DataGridJogo.firstCell == null)
            {
                DataGridJogo.firstCell = new int[2] { e.RowIndex, e.ColumnIndex };
            }
        }
    }
}

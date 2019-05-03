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
            dataGridJogo = GridBoard.PopularGrid(dataGridJogo);
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
            GridBoard.IdentificarMov(dataGridJogo);
            GridBoard.SelecionarCelulasMovOrientacao(dataGridJogo);
            GridBoard.DeselecionarCelulasNaoMovOrientacao(dataGridJogo);
        }

        private void dataGridJogo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (GridBoard.firstCell != null)
                {
                    GridBoard.distCell = new int[2] { e.RowIndex, e.ColumnIndex };
                }
            }
        }

        private void dataGridJogo_MouseUp(object sender, MouseEventArgs e)
        {
            GridBoard.firstCell = null;
            GridBoard.distCell = null;
            GridBoard.distMovCell = null;
            GridBoard.movSentido = null;
        }
        private void dataGridJogo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (GridBoard.firstCell == null)
            {
                GridBoard.firstCell = new int[2] { e.RowIndex, e.ColumnIndex };
            }
        }
    }
}

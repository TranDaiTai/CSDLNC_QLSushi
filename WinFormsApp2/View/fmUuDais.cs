using QuanLySuShi.Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySuShi
{
    public partial class fmUuDais : Form
    {
        public DataGridViewRow uuDai = null;
        public fmUuDais(List<UuDai> uuDais)
        {
            InitializeComponent();
            dtgvUuDai.DataSource = uuDais;
        }

        public void LoadUuDais()
        {

        }
        private void btnApdung_Click(object sender, EventArgs e)
        {
            if (uuDai == null)
            {
                MessageBox.Show("Vui lòng chọn ưu đãi", "Thông báo");
                return;
            }
           
            this.Close(); // Đóng form

        }

        private void dtgvUuDai_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            uuDai = dtgvUuDai.Rows[e.RowIndex];
        }

        private void fmUuDais_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK; // Thiết lập DialogResult
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSOL.DAO;
namespace MSOL
{
    public partial class QUYDINH : Form
    {
        public QUYDINH()
        {
            InitializeComponent();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var sotiencoc = Convert.ToInt32(txtTiendatcoc.Text);
                var solephuc = Convert.ToInt32(txtSolephuc.Text);
                var sogoichup = Convert.ToInt32(txtSoGoiChup.Text);
                if (QuyDinhDAO.Instance.Update(sotiencoc, solephuc, sogoichup))
                {
                    MessageBox.Show("Cập nhật thành công");
                    loadtextbox();
                }
            }
            catch { }
        }

        private void QUYDINH_Load(object sender, EventArgs e)
        {
            loadtextbox();
        }

        private void loadtextbox()
        {
            txtTiendatcoc.Text = QuyDinhDAO.Instance.Sotiencoc().ToString();
            txtSolephuc.Text = QuyDinhDAO.Instance.SoLePhucToiDa().ToString();
            txtSoGoiChup.Text = QuyDinhDAO.Instance.SoGoiChupToiDa().ToString();
        }
    }
}

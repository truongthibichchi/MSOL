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
using MSOL.DTO;

namespace MSOL
{
    public partial class CHONGOICHUP : Form
    {
        public CHONGOICHUP()
        {
            InitializeComponent();
        }

         private List<LoaiGoiChup> _LoaigoichupList;
        private List<GoiChup> _GoichupList;
        private List<GoiChup> _Goichupduocchon;
        

        private void CHONGOICHUP_Load(object sender, EventArgs e)
        {

            LoadcbbLoaigoichup();
            LoadGoichupList(1);
            _Goichupduocchon = new List<GoiChup>();
        }

        
        private void LoadcbbLoaigoichup()
        {
            
            _LoaigoichupList = LoaiGoiChupDAO.Instance.getTenloaiGCList();
            cbbLoaiGC.DataSource = _LoaigoichupList;
            cbbLoaiGC.DisplayMember = "TenLoaiGC";
            cbbLoaiGC.ValueMember = "MaLoaiGC";
            cbbLoaiGC.MaxDropDownItems = 5;
        }

        private void LoadGoichupList(int loaigoichup)
        {
            _GoichupList = GoiChupDAO.Instance.GetGoichupListByLoaigc(loaigoichup);
            dgvGoichup.DataSource = _GoichupList;
 
        }

        private event EventHandler<ChonGoiChupEvent> _chongoichup;
        public event EventHandler<ChonGoiChupEvent> Chongoichup
        {
            add { _chongoichup += value; }
            remove { _chongoichup -= value; }
        }

        public void GoiChup()
        {
            if (_chongoichup != null)
            {
                _chongoichup(this, new ChonGoiChupEvent(_Goichupduocchon));
            }
        }

        public class ChonGoiChupEvent : EventArgs
        {
            private List<GoiChup> _goichuplist;

            public List<GoiChup> Goichuplist
            {
                get { return _goichuplist; }
                set { _goichuplist = value; }
            }

            public ChonGoiChupEvent(List<GoiChup> goichuplist)
            {
                this._goichuplist = goichuplist;
            }
            
        }


        private void cbbLoaiGC_SelectedIndexChanged(object sender, EventArgs e)
        {
            var loaigc = (cbbLoaiGC.SelectedItem as LoaiGoiChup).MaLoaiGC;
            LoadGoichupList(loaigc);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGoichup.Rows)
            {
                DataGridViewCheckBoxCell cell = row.Cells[0] as DataGridViewCheckBoxCell;
                if (cell.Value != null)
                {
                    if (cell.Value == cell.TrueValue)
                    {
                        var magoichup = _GoichupList[dgvGoichup.SelectedRows[0].Index].MaGoiChup;
                        GoiChup goichup = GoiChupDAO.Instance.GetgoichupByMagc(magoichup);
                        _Goichupduocchon.Add(goichup);
                    }
                }
            }
            
            GoiChup();
            this.Close();
        }  
    }
}

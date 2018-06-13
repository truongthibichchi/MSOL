using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSOL
{
    public partial class LIENHE : UserControl
    {
        private static LIENHE _instance;
        public static LIENHE Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LIENHE();
                return _instance;
            }
        }
        public LIENHE()
        {
            InitializeComponent();
        }
    }
}

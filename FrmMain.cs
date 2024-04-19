using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        List<FrmCalc> listCalc = new List<FrmCalc>();
        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Hide();
            AddCalcWindow(Left, Top);
        }
        void AddCalcWindow(int left, int top)
        {
            var calc = new FrmCalc();
            listCalc.Add(calc);
            calc.FormClosed += (s, e) =>
            {
                listCalc.Remove(calc);
                Debug.WriteLine("[" + listCalc.Count + "]Calc window remove");
                if (listCalc.Count == 0)
                {
                    Close();
                }
            };
            calc.NewCalcWindow += () =>
            {
                AddCalcWindow(calc.Left, calc.Top + 5 + calc.Height);
            };
            calc.Show();
            calc.Left = left;
            calc.Top = top;
            Debug.WriteLine("[" + listCalc.Count + "]Calc window added");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
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
        void AddCalcWindow(int left = -1, int top = -1)
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
            calc.ShowAllCalc += ShowAllCalc;
            calc.NextCalc += NextCalc;
            calc.CalcActivate += CalcActivate;
            calc.SaveAllCalcWindow += SaveAllCalcWindow;
            calc.LoadAllCalcWindow += LoadAllCalcWindow;
            calc.Show();
            if (left >= 0)
            {
                calc.Left = left;
            }
            if (top >= 0)
            {
                calc.Top = top;
            }
            lastIndex = listCalc.Count - 1;
            Debug.WriteLine("[" + listCalc.Count + "]Calc window added");
        }
        /// <summary>
        /// 显示所有计算器窗口
        /// </summary>
        void ShowAllCalc()
        {
            foreach (var calc in listCalc)
            {
                calc.Activate();
            }
        }
        int lastIndex = 0;
        /// <summary>
        /// 切换焦点到下一个计算器窗口
        /// </summary>
        void NextCalc()
        {
            if (listCalc.Count > lastIndex + 1)
            {
                lastIndex++;
            }
            else
            {
                lastIndex = 0;
            }
            listCalc[lastIndex].Activate();
        }
        /// <summary>
        /// 某个计算器窗口被激活时，更新当前激活的窗口索引
        /// </summary>
        /// <param name="frm">计算器窗口</param>
        void CalcActivate(FrmCalc frm)
        {
            int index = listCalc.IndexOf(frm);
            if (index != -1)
            {
                lastIndex = index;
            }
        }
        /// <summary>
        /// 保存所有计算器窗口的位置和值
        /// </summary>
        void SaveAllCalcWindow()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "计算器配置文件|*.cc";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var calc in listCalc)
            {
                sb.AppendLine(calc.CurrValue + "," + calc.Mode + "," + calc.Left + "," + calc.Top);
            }
            System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
        }
        /// <summary>
        /// 加载配置文件，恢复所有计算器窗口
        /// </summary>
        void LoadAllCalcWindow()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "计算器配置文件|*.cc";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);
            foreach (var line in lines)
            {
                string[] items = line.Split(',');
                if (items.Length == 4)
                {
                    AddCalcWindow();
                    FrmCalc lastCalc = listCalc[listCalc.Count - 1];
                    lastCalc.CurrValue = Convert.ToUInt32(items[0]);
                    lastCalc.SetMode((FrmCalc.CalcMode)Enum.Parse(typeof(FrmCalc.CalcMode), items[1]));
                    lastCalc.Left = Convert.ToInt32(items[2]);
                    lastCalc.Top = Convert.ToInt32(items[3]);
                }
            }
        }
    }
}

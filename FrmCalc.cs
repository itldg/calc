using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Calc
{

    public partial class FrmCalc : Form
    {
        /// <summary>
        /// 创建一个新的计算器窗口
        /// </summary>
        public event Action<bool> NewCalcWindow;
        /// <summary>
        /// 展示所有的计算器窗口
        /// </summary>
        public event Action ShowAllCalc;
        /// <summary>
        /// 切换下一个计算器窗口
        /// </summary>
        public event Action NextCalc;
        /// <summary>
        /// 窗口被激活
        /// </summary>
        public event Action<FrmCalc> CalcActivate;

        /// <summary>
        /// 保存所有计算器窗口
        /// </summary>
        public event Action SaveAllCalcWindow;

        /// <summary>
        /// 加载所有计算器窗口
        /// </summary>
        public event Action LoadAllCalcWindow;

        /// <summary>
        /// 关闭所有计算器窗口
        /// </summary>
        public event Action CloseAllCalcWindow;

        /// <summary>
        /// 当前模式
        /// </summary>
        public CalcMode Mode { get; set; } = CalcMode.Hex;
        uint _CurrValue = 0;
        /// <summary>
        /// 当前值
        /// </summary>
        public uint CurrValue
        {
            get { return _CurrValue; }
            set
            {
                _CurrValue = value;
                ShowNewValue();
                Text = lblNum.Text + " 老大哥计算器";
            }
        }

        Label lblNum = new Label();
        /// <summary>
        /// 去除标签中的空格和逗号
        /// </summary>
        public string NoSymbolNum
        {
            get
            {
                return lblNum.Text.Replace(" ", "").Replace(",", "");
            }
        }
        string beforeValueStr = "";
        uint beforeValue = 0;



        public char CalcCommand { get; set; } = ' ';
        char[] allowCommands = new char[] { '+', '-', '*', '/', '%', '&', '|', '^', '~', '>', '<' };

        bool resetValue = false;
        /// <summary>
        /// 计算器模式
        /// </summary>
        public enum CalcMode
        {
            /// <summary>
            /// 16进制
            /// </summary>
            Hex,
            /// <summary>
            /// 10进制
            /// </summary>
            Dec,
            /// <summary>
            /// 2进制
            /// </summary>
            Bin
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MoveWindow(e);
        }
        void MoveWindow(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x00A1, 2, 0);
            }
        }
        Color colorBg;
        public FrmCalc()
        {
            InitializeComponent();
            SetMode(CalcMode.Hex);
            colorBg = BackColor;
            LostFocus += (s, e) =>
            {
                BackColor = colorBg;
            };
        }
        public void SetMode(CalcMode mode)
        {
            pHighHex.Visible = pHighDec.Visible = pHighBin.Visible = false;
            Mode = mode;
            resetValue = true;
            switch (mode)
            {
                case CalcMode.Hex:
                    pHighHex.Visible = true;
                    lblNum = lblHex;
                    break;
                case CalcMode.Dec:
                    pHighDec.Visible = true;
                    lblNum = lblDec;
                    break;
                case CalcMode.Bin:
                    pHighBin.Visible = true;
                    lblNum = lblBin;
                    break;
                default:
                    break;
            }
        }

        private void FrmCalc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                Close();
            }
            else if (e.KeyChar == 7) //Ctrl + G
            {
                CloseAllCalcWindow?.Invoke();
            }
            else if (e.KeyChar == 19) //Ctrl + S
            {
                SaveAllCalcWindow?.Invoke();
            }
            else if (e.KeyChar == 15) //Ctrl + O
            {
                LoadAllCalcWindow?.Invoke();
            }
            else if (e.KeyChar == 'N' || e.KeyChar == 'n')
            {
                NewCalcWindow?.Invoke(true);
            }
            else if (e.KeyChar == 14) //Ctrl + N
            {
                NewCalcWindow?.Invoke(false);
            }
            else if (e.KeyChar == 'S' || e.KeyChar == 's')
            {
                ShowAllCalc?.Invoke();
            }
            else if (e.KeyChar == '\t') //Tab
            {
                NextCalc?.Invoke();
            }
            else if (e.KeyChar == 3) //Ctrl + C
            {
                //复制
                try
                {
                    Clipboard.SetText(NoSymbolNum);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "复制失败");
                }
            }
            else if (e.KeyChar == 22) //Ctrl + V
            {
                //粘贴
                lblNum.Text = "";
                char[] chars = Clipboard.GetText().ToCharArray();
                foreach (var item in chars)
                {
                    NumKeyPress(item);
                }
            }
            else if (e.KeyChar == '\b') //Backspace
            {
                DeleteNumer();
            }
            else if (e.KeyChar == '\r' || e.KeyChar == '=')
            {
                Calc();
                CalcCommand = ' ';
            }
            else if (allowCommands.Contains(e.KeyChar))
            {
                CalcBefore(e.KeyChar);
            }
            else
            {
                NumKeyPress(e.KeyChar);
            }
        }
        void NumKeyPress(char key)
        {
            switch (Mode)
            {
                case CalcMode.Hex:
                    KeyPressHex(key);
                    break;
                case CalcMode.Dec:
                    KeyPressDec(key);
                    break;
                case CalcMode.Bin:
                    KeyPressBin(key);
                    break;
                default:
                    break;
            }
        }
        char[] hexAllowNumbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'a', 'b', 'c', 'd', 'e', 'f' };
        void KeyPressHex(char key)
        {
            if (hexAllowNumbers.Contains(key))
            {
                if (lblNum.Text.Length >= 9 && !resetValue)
                {
                    return;
                }
                AddNum(key);
            }
        }
        char[] decAllowNumbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        void KeyPressDec(char key)
        {
            if (decAllowNumbers.Contains(key))
            {
                if (lblNum.Text.Length >= 11 && !resetValue)
                {
                    return;
                }
                AddNum(key);
            }
        }
        char[] binAllowNumbers = new char[] { '0', '1' };
        void KeyPressBin(char key)
        {
            if (binAllowNumbers.Contains(key))
            {
                if (lblNum.Text.Length >= 39 && !resetValue)
                {
                    return;
                }
                AddNum(key);
            }
        }
        /// <summary>
        /// 添加一个数字
        /// </summary>
        /// <param name="num">数字字符</param>
        void AddNum(char num)
        {
            if (resetValue)
            {
                lblNum.Text = num.ToString();
                resetValue = false;
            }
            else
            {
                lblNum.Text += num;
            }
            CurrValue = Convert.ToUInt32(NoSymbolNum, Mode == CalcMode.Hex ? 16 : Mode == CalcMode.Dec ? 10 : 2);
        }
        /// <summary>
        /// 删除最后一个数字
        /// </summary>
        void DeleteNumer()
        {
            if (lblNum.Text.Length > 1)
            {
                lblNum.Text = lblNum.Text.Substring(0, lblNum.Text.Length - 1);
                CurrValue = Convert.ToUInt32(NoSymbolNum, Mode == CalcMode.Hex ? 16 : Mode == CalcMode.Dec ? 10 : 2);
            }
            else
            {
                CurrValue = 0;
            }
        }
        /// <summary>
        /// 要去除的字符串开头字符
        /// </summary>
        char[] trimChar = new char[] { '0' };
        /// <summary>
        /// 展示修改后的数值
        /// </summary>
        void ShowNewValue()
        {
            string hexValue = _CurrValue.ToString("X");
            if (hexValue.Length > 1)
            {
                hexValue = hexValue.TrimStart(trimChar);
            }
            lblHex.Text = StringSplit(hexValue, 4);

            lblDec.Text = StringSplit(_CurrValue.ToString(), 3, ",");
            lblBin.Text = StringSplit(Convert.ToString(_CurrValue, 2), 4);
        }
        /// <summary>
        /// 每隔一定长度分割字符串
        /// </summary>
        /// <param name="str">要分割的字符串</param>
        /// <param name="length">长度</param>
        /// <param name="split">用于分割的字符串</param>
        /// <returns></returns>
        string StringSplit(string str, int length, string split = " ")
        {
            string result = "";
            uint index = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (index % length == 0 && index != 0)
                {
                    result = split + result;
                }
                result = str[i] + result;
                index++;
            }
            return result;
        }
        void CalcBefore(char command)
        {
            //计算之前的式子
            Calc();
            beforeValue = CurrValue;
            beforeValueStr = lblNum.Text;
            lblCalc.Text = beforeValueStr + " " + command;
            CalcCommand = command;
        }
        /// <summary>
        /// 计算当前的值
        /// </summary>
        void Calc()
        {
            resetValue = true;
            if (CalcCommand == ' ')
            {
                //没有在计算
                return;
            }
            switch (CalcCommand)
            {
                case '+':
                    CurrValue = beforeValue + CurrValue;
                    break;
                case '-':
                    CurrValue = beforeValue - CurrValue;
                    break;
                case '*':
                    CurrValue = beforeValue * CurrValue;
                    break;
                case '/':
                    CurrValue = beforeValue / CurrValue;
                    break;
                case '%':
                    CurrValue = beforeValue % CurrValue;
                    break;
                case '&':
                    CurrValue = beforeValue & CurrValue;
                    break;
                case '|':
                    CurrValue = beforeValue | CurrValue;
                    break;
                case '^':
                    CurrValue = beforeValue ^ CurrValue;
                    break;
                case '~':
                    CurrValue = ~CurrValue;
                    break;
                case '>':
                    CurrValue = beforeValue >> (int)CurrValue;
                    break;
                case '<':
                    CurrValue = beforeValue << (int)CurrValue;
                    break;
                default:
                    break;
            }
            beforeValueStr = "";
            lblCalc.Text = "";
        }
        private void lblModeHex_Click(object sender, EventArgs e)
        {
            SetMode(CalcMode.Hex);
        }

        private void lblModeDec_Click(object sender, EventArgs e)
        {
            SetMode(CalcMode.Dec);
        }

        private void lblModeBin_Click(object sender, EventArgs e)
        {
            SetMode(CalcMode.Bin);
        }

        private void FrmCalc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CurrValue = 0;
            }
            else if (e.KeyCode == Keys.Up)
            {
                switch (Mode)
                {
                    case CalcMode.Hex:
                        SetMode(CalcMode.Bin);
                        break;
                    case CalcMode.Dec:
                        SetMode(CalcMode.Hex);
                        break;
                    case CalcMode.Bin:
                        SetMode(CalcMode.Dec);
                        break;
                    default:
                        break;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                switch (Mode)
                {
                    case CalcMode.Hex:
                        SetMode(CalcMode.Dec);
                        break;
                    case CalcMode.Dec:
                        SetMode(CalcMode.Bin);
                        break;
                    case CalcMode.Bin:
                        SetMode(CalcMode.Hex);
                        break;
                    default:
                        break;
                }
            }
        }

        private void lblModeHex_MouseMove(object sender, MouseEventArgs e)
        {
            MoveWindow(e);
        }

        private void FrmCalc_Activated(object sender, EventArgs e)
        {
            BackColor = Color.FromArgb(185, 209, 234);
            CalcActivate?.Invoke(this);
        }
    }
}

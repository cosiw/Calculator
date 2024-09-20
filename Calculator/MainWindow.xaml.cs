using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsInput;
using WindowsInput.Native;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
		/// 키패드 버튼 참조
		/// </summary>
		private Button[] mButtons;

        /// <summary>
		/// 키패드 InputSimulator 참조
		/// </summary>
		private readonly InputSimulator inputSimulator = new InputSimulator();


        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            InitializeKeypadButtons();
        }

        private void InitializeKeypadButtons()
        {
            mButtons =
                new Button[] {
                    this.btn0,
                    this.btn1,
                    this.btn2,
                    this.btn3,
                    this.btn4,
                    this.btn5,
                    this.btn6,
                    this.btn7,
                    this.btn8,
                    this.btn9};

            // 버튼 컨트롤의 공통 속성값을 지정합니다.
            foreach (var btn in mButtons)
            {
                btn.Focusable = false;
            }

            // 버튼의 Tag 속성을 설정합니다.
            this.btn0.Tag = 48 + 0;
            this.btn1.Tag = 48 + 1;
            this.btn2.Tag = 48 + 2;
            this.btn3.Tag = 48 + 3;
            this.btn4.Tag = 48 + 4;
            this.btn5.Tag = 48 + 5;
            this.btn6.Tag = 48 + 6;
            this.btn7.Tag = 48 + 7;
            this.btn8.Tag = 48 + 8;
            this.btn9.Tag = 48 + 9;

        }
        /// <summary>
		/// 키패드 클릭 이벤트 핸들러 입니다.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnKeyPad_Click(object sender, RoutedEventArgs e)
        {
            var tagData = (sender as Button)?.Tag;
            if (tagData != null)
            {
                if (tagData is int)
                {
                    inputSimulator.Keyboard.KeyDown((VirtualKeyCode)tagData);
                }
            }
        }
    }
}
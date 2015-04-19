using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace myMines
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        internal DispatcherTimer timer;  //計時器
        int _height = 10;  //地雷盤高度格數(列數)
        int _width = 10;  //地雷盤寬度格數(行數) 
        int _mines = 10;  //地雷數
        int _count; //被標記為地雷的數目
        Game gm;  //遊戲類別物件
        int sec = 0;
        
        double rate =1 ;

        public Window1()
        {
            InitializeComponent();
            //建立計時器實例、設定屬性及新增事件
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            
            
            
            //重設遊戲畫面
            Reset();
        }

        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            //重設遊戲畫面
            Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //每一秒在計時Label內顯示秒數
            sec ++ ;
           lblTimer.Content = sec ;
            
        }

        
            
        



        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //判斷遊戲仍在進行且按下去的來源是Square類別的物件
            if (gm.IsStarted && e.Source.GetType() == typeof(Square))
            {
                //若計時器未啟動則啟動之
                if(!timer.IsEnabled){
                    timer.Start();
                }

                Square s = (Square)e.Source;
                //判斷是否按下的是滑鼠左鍵
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    gm.Click(s);
                    //打開格子(呼叫Game的Click Method傳入s當參數)
                    
                    if (gm.IsFinished)
                    {
                        //顯示完成訊息
                        MessageBox.Show("< 資管二/102306045/朱思瑀>\n恭喜您在 " + "lblTimer.Content" + " 秒內完成遊戲!");
                        Reset();
                    }
                }
                //判斷是否按下的是滑鼠右鍵
                else if (e.RightButton == MouseButtonState.Pressed)
                {
                    
                    //標註地雷 (呼叫Square物件s的DismantleClick Method)
                    s.DismantleClick();
                    _count = (s.Dismantled) ? _count - 1 : _count + 1;
                    //顯示數目

                    lblCount.Content = (_count)*(-1);

                }
            }
        }

        //重設遊戲畫面
        void Reset()   
        {
            //關閉計時器
            timer.Stop();
           


            //所有label歸零
           sec = 0;
           _count = 0;
           lblTimer.Content = 0 ;
           lblCount.Content = 0;

            //建立新的地雷盤
            gm = new Game(this, _width, _height, _mines);
            gm.Start();  //放地雷進去
        }

        private void MenuItem_About_Click(object sender, RoutedEventArgs e)
        {
            AboutBox2 about = new AboutBox2();
            about.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            rate = 1.0;
            //設定初級地雷盤
            _height = 10;  //地雷盤高度格數(列數)
            _width = 10;  //地雷盤寬度格數(行數) 
            _mines = 10;

            this.Width = this.ActualHeight*rate;
            
            //調整視窗寬度，讓格子看起來像正方形
            
            //重設遊戲畫面
            Reset();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            //設定中級地雷盤
            rate = 1.0;
            _height = 15;  //地雷盤高度格數(列數)
            _width = 15;  //地雷盤寬度格數(行數) 
            _mines = 30;
            this.Width = this.ActualHeight * rate;
            //調整視窗寬度，讓格子看起來像正方形
            
            //重設遊戲畫面
            Reset();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //設定高級地雷盤
            rate = (double)30 / 16;
            _height = 16;  //地雷盤高度格數(列數)
            _width = 30;  //地雷盤寬度格數(行數) 
            _mines = 99;
            this.Width = this.ActualHeight*rate;
            
            //調整視窗寬度，讓格子看起來像正方形
            
            //重設遊戲畫面
            Reset();
        }

        private void MenuItem_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //關閉視窗
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

 

        private void MenuItem_Click_game(object sender, RoutedEventArgs e)
        {

        }


        private void MenuItem_Click_explain(object sender, RoutedEventArgs e)
        {

        }

        private void ugdBoard_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            this.Width = this.ActualHeight * rate;
        }

       


       

       
    }
}

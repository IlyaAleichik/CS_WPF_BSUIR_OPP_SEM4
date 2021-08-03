using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String selectedItemStr { get; set; }
        ArrayList objectList = new ArrayList();
        String comboItem { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        public void GetStrElemCount(string str)
        {
            string newStr= "";
            int index = 0, count = 0;
            bool flag = false;

            for (int i = 0; i < str.Length; i++)
            {
                    
                if (Convert.ToInt32(str[i]) % 2 == 1)
                {
                    count++;
                    newStr += str[i].ToString();
                }
                if (count == 5)
                {
                    if (Convert.ToInt32(str[i+1]) % 2 == 1)
                    {
                        continue;
                    }
                    listBoxRun.Items.Add(newStr);
                    newStr = "";
                    count = 0;
                }
          
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
         
            objectList.Add(inptText.Text);
            comboBox.Items.Clear();
            listBox.Items.Clear();
            foreach (object o in objectList)
            {
                comboBox.Items.Add(o);
                listBox.Items.Add(o);
            }
      
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {        
            GetStrElemCount(selectedItemStr);
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         //  comboItem = (String)comboBox.SelectedValue;
            ComboBox comboBox = (ComboBox)sender;
            String selectedItem = (String)comboBox.SelectedItem;
            selectedItemStr = selectedItem;
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listBoxRun.Items.Clear();
        }
    }
}

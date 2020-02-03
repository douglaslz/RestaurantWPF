using System;
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

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declaring List to all the products
        List<Food> food = new List<Food>();
        //Declaring List to all the products in the order
        List<Food> order = new List<Food>();
        //Number of produc in the order
        int numberitem = 1;
        //Item seleted on the datagrid
        Food a;

        public MainWindow()
        {
            InitializeComponent();
            //Introducing product in the list
            food.Add(new Food {Category ="Beverage", Name = "Soda", Price= 1.95m });
            food.Add(new Food {Category ="Beverage", Name = "Tea", Price = 1.5m });
            food.Add(new Food {Category ="Beverage", Name = "Coffee", Price = 1.25m });
            food.Add(new Food {Category ="Beverage", Name = "Minera Water", Price = 2.95m });
            food.Add(new Food {Category ="Beverage", Name = "Juice", Price = 2.5m });
            food.Add(new Food {Category ="Beverage", Name = "Milk", Price = 1.5m });
            food.Add(new Food {Category ="Appetizer", Name = "Buffalo Wings", Price = 5.95m });
            food.Add(new Food {Category ="Appetizer", Name = "Buffalo Fingers", Price = 6.95m });
            food.Add(new Food {Category ="Appetizer", Name = "Potato Skins", Price = 8.95m });
            food.Add(new Food {Category ="Appetizer", Name = "Nachos", Price = 8.95m });
            food.Add(new Food {Category ="Appetizer", Name = "Mushroom Caps", Price = 10.95m });
            food.Add(new Food {Category ="Appetizer", Name = "Shrimp Cocktail", Price = 12.95m });
            food.Add(new Food {Category ="Appetizer", Name = "Chips and Salsa", Price = 6.95m });
            food.Add(new Food {Category ="Main Course", Name = "Seafood Alfredo", Price = 15.95m });
            food.Add(new Food {Category ="Main Course", Name = "Chicken Alfredo", Price = 13.95m });
            food.Add(new Food {Category ="Main Course", Name = "Chicken Picatta", Price = 13.95m });
            food.Add(new Food {Category ="Main Course", Name = "Turkey Club", Price = 11.95m});
            food.Add(new Food {Category ="Main Course", Name = "Lobster Pie", Price = 19.95m });
            food.Add(new Food {Category ="Main Course", Name = "Prime Ribs", Price = 20.95m });
            food.Add(new Food {Category ="Main Course", Name = "Shrimp Scampi", Price = 18.95m });
            food.Add(new Food {Category ="Main Course", Name = "Turkey Dinner", Price = 13.95m });
            food.Add(new Food {Category ="Main Course", Name = "Stuffed Chicken", Price = 14.95m });
            food.Add(new Food {Category ="Dessert", Name = "Apple pie", Price = 5.95m });
            food.Add(new Food {Category ="Dessert", Name = "Sundae", Price = 3.95m });
            food.Add(new Food {Category ="Dessert", Name = "Carrot Cake", Price = 5.95m });
            food.Add(new Food {Category ="Dessert", Name = "Mud Pie", Price = 4.95m });
            food.Add(new Food {Category ="Dessert", Name = " Apple Crisp", Price = 5.95m });
            
            //Sending data to the comboBox depent its category
            foreach (Food elemento in food)
            {
                if(elemento.Category == "Beverage")
                {
                    comboBox.Items.Add(elemento.Name.ToString());

                }else if (elemento.Category == "Appetizer")
                {
                    comboBox_Copy.Items.Add(elemento.Name.ToString());

                }
                else if (elemento.Category == "Main Course")
                {
                    comboBox_Copy1.Items.Add(elemento.Name.ToString());

                }
                else
                {
                    comboBox_Copy2.Items.Add(elemento.Name.ToString());
                }

            }
            //Loading data  in datagrid(I use in order to show columns)
            loadItemDataGrid();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            addproduct(comboBox);

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {

            addproduct(comboBox_Copy);
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            addproduct(comboBox_Copy1);
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
        
            addproduct(comboBox_Copy2);

        }

        public void addproduct(ComboBox combotext)
        {
            //Running the list to find product
            foreach (Food elemento in food)
            {
                //Finding the product 
                if (elemento.Name == combotext.Text)
                {
                    //Sending it to the order list
                    order.Add(new Food() {Id = numberitem, Category = elemento.Category, Name = elemento.Name, Price = elemento.Price });
                    //Increment counter of the number of items in order
                    numberitem++;

                }

            }
            //Loading data  in datagrid
            loadItemDataGrid();
        }

        

        private void datagrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
             //Send item selected to the variable a            
             a = dataGrid.SelectedItem as Food;  
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Check if there is any item selected
            if(a == null)
            {
                MessageBox.Show("No Item Selected");
            }
            else
            {
                
                foreach (Food item in order.ToList())
                {
                    if (item.Id == a.Id)
                    {
                        //Removing selected item
                        order.Remove(item);
                        //Loading data  in datagrid
                        loadItemDataGrid();

                    }
                        
                }
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //Cleaning all the fields
            order.Clear();
            loadItemDataGrid();
        }

        public void loadItemDataGrid()
        {
            //Erase datagrid
            dataGrid.ItemsSource = null;
            //Introduce data in the list order to datagrid
            dataGrid.ItemsSource = order;
        }
    }
}

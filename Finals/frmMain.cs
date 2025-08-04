using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finals
{
    /*
Name: Alex Magallon, Maurel Fabian, Dimas Chica,
Group Name: the coders
Date: 5/23/24
Program: Payment screen for user to pay for food
*/
    public partial class frmMain : Form
    {
        // Synchronization flag to prevent recursive selection events
        private bool syncingSelection = false;
        private string user_name;

        // Properties to get the tip and total amounts
        public double getTip { get; set; }
        public double getTotal { get; set; }

        // Variables for order calculations
        public double orderTip = 0;
        public double subTotal = 0;

        // File paths for different categories of items and their prices
        private const string MainDishesFileName = "MainDishes.txt";
        private const string SaladsFileName = "Salads.txt";
        private const string DrinksFileName = "Drinks.txt";
        private const string DessertsFileName = "Desserts.txt";
        private const string PricesFileName = "Prices.txt";

        // Constants and fields
        private const double TAX_PERCENT = 0.095;
        private double orderTax = 0;
        private double orderSum = 0;

        // Size constant for array lengths
        private const int SIZE = 99;

        // Arrays to store different categories of items and their counts
        private string[] main_Dishes = new string[SIZE];
        private string[] salads = new string[SIZE];
        private string[] drinks = new string[SIZE];
        private string[] desserts = new string[SIZE];
        private int mainDishCount = 0;
        private int saladsCount = 0;
        private int drinksCount = 0;
        private int dessertsCount = 0;

        // Array to store prices and their count
        private double[] prices = new double[SIZE];
        private int priceCount = 0;

        // Arrays and counters for current order details
        private double[] currentOrder = new double[SIZE];
        private int currentOrderCount = 0;
        private int placeOrder = 0;
        private int orderNumber = 1000;

        // Arrays for different types of bread, toppings, and meat types
        private string[] breadTypes = { "White", "Wheat", "Gluten Free", "Rye", "Sourdough", "Ciabata" };
        private string[] toppings = { "Lettuce", "Tomatoes", "Mayo", "Provolone", "Onions" };
        private string[] meatTypes = { "Regular", "Impossible" };

        public frmMain()
        {
            InitializeComponent();

            // Remove certain tabs from the TabControl initially
            tabControl1.TabPages.Remove(tabCurrentOrder);
            tabControl1.TabPages.Remove(tabReceipt);

            // Hide the receipt text box initially
            rtxtReceipt2.Visible = false;

            // Deselect items in the list boxes depending on the selected tab
            int tabIndex = tabControl1.SelectedIndex;
            if (tabIndex != 0) lstMainDishes.ClearSelected();
            if (tabIndex != 1) lstSalads.ClearSelected();
            if (tabIndex != 2) lstDrinks.ClearSelected();
            if (tabIndex != 3) lstDesserts.ClearSelected();
        }

        // Synchronize selection between source and target list boxes
        private void SynchronizeSelection(ListBox sourceList, ListBox targetList)
        {
            // Clear selection in target list
            targetList.ClearSelected();

            // Select corresponding item in target list
            if (sourceList.SelectedIndex != -1)
            {
                int selectedIndex = sourceList.SelectedIndex;
                if (selectedIndex == targetList.Items.Count)
                {
                    targetList.Text = sourceList.Text;
                }
                else
                {
                    targetList.SetSelected(selectedIndex, true);
                }
            }
        }

        // Handle selection changes in the main dishes list box
        private void lstOrderItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstMainDishes, lstOrderPrices);
                syncingSelection = false;
            }

            // Update images based on the selected main dish
            switch (lstMainDishes.SelectedIndex)
            {
                case 0: pictureBox1.Image = Properties.Resources.crispy_chicken_parmesan_sandwich_vert3; break;
                case 1: pictureBox1.Image = Properties.Resources.Salami; break;
                case 2: pictureBox1.Image = Properties.Resources.italian_sub; break;
                case 3: pictureBox1.Image = Properties.Resources.ChickenParm__1_; break;
                case 4: pictureBox1.Image = Properties.Resources.Lasagna; break;
                case 5: pictureBox1.Image = Properties.Resources.Strambolli; break;
                case 6: pictureBox1.Image = Properties.Resources.Risotto__1_; break;
                case 7: pictureBox1.Image = Properties.Resources.Spaghetti_Meatballs__1_; break;
                case 8: pictureBox1.Image = Properties.Resources.Chicken_Florentine; break;
                case 9: pictureBox1.Image = Properties.Resources.WeddingSoup; break;
                case 10: pictureBox1.Image = Properties.Resources.SicilianPizza; break;
                case 11: pictureBox1.Image = Properties.Resources.NeopolitanPizza; break;
            }

            // Update images based on the selected salad
            switch (lstSalads.SelectedIndex)
            {
                case 0: pictureBox2.Image = Properties.Resources.Summer_Farro_Salad; break;
                case 1: pictureBox2.Image = Properties.Resources.Big_Italian_Salad; break;
                case 2: pictureBox2.Image = Properties.Resources.CHICKPEA; break;
            }

            // Update images based on the selected drink
            switch (lstDrinks.SelectedIndex)
            {
                case 0: pictureBox3.Image = Properties.Resources.water; break;
                case 1: pictureBox3.Image = Properties.Resources.Coke; break;
                case 2: pictureBox3.Image = Properties.Resources.Sprite; break;
                case 3: pictureBox3.Image = Properties.Resources.Dr_Pepper; break;
                case 4: pictureBox3.Image = Properties.Resources.Orange_Crush; break;
                case 5: pictureBox3.Image = Properties.Resources.Sangria; break;
                case 6: pictureBox3.Image = Properties.Resources.Red_Wine; break;
                case 7: pictureBox3.Image = Properties.Resources.WhiteWine; break;
            }

            // Update images based on the selected dessert
            switch (lstDesserts.SelectedIndex)
            {
                case 0: pictureBox4.Image = Properties.Resources.Tiramisu; break;
                case 1: pictureBox4.Image = Properties.Resources.Biscotti; break;
                case 2: pictureBox4.Image = Properties.Resources.Cannoli; break;
            }
        }

        // Handle selection changes in the salads list box
        private void lstSalads_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstSalads, lstSaladPrices);
                syncingSelection = false;
            }
        }

        // Handle selection changes in the drinks list box
        private void lstDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstDrinks, lstDrinkPrices);
                syncingSelection = false;
            }
        }

        // Handle selection changes in the desserts list box
        private void lstDesserts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstDesserts, lstDessertPrices);
                syncingSelection = false;
            }
        }

        // Handle selection changes in the order prices list box
        private void lstOrderPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstOrderPrices, lstMainDishes);
                syncingSelection = false;
            }
        }

        // Handle selection changes in the salad prices list box
        private void lstSaladPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstSaladPrices, lstSalads);
                syncingSelection = false;
            }
        }

        // Handle selection changes in the drink prices list box
        private void lstDrinkPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstDrinkPrices, lstDrinks);
                syncingSelection = false;
            }
        }

        // Handle selection changes in the dessert prices list box
        private void lstDessertPrices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!syncingSelection)
            {
                syncingSelection = true;
                SynchronizeSelection(lstDessertPrices, lstDesserts);
                syncingSelection = false;
            }
        }

        // Load data from a file into a specified array and update the count
        private void LoadData(string fileName, string[] dataArray, ref int count)
        {
            try
            {
                using (StreamReader inFile = File.OpenText(fileName))
                {
                    while (!inFile.EndOfStream)
                    {
                        dataArray[count] = inFile.ReadLine();
                        count++;
                    }
                }
            }
            catch
            {
                MessageBox.Show($"The file '{fileName}' was not found. Please contact admin.");
            }
        }

        // Load prices from the Prices.txt file into the prices array
        private void loadprices()
        {
            try
            {
                // Open the file for reading
                StreamReader inFile = File.OpenText(PricesFileName);
                // Read each line of the file until the end is reached
                while (!inFile.EndOfStream)
                {
                    // Parse the line as a double and store it in the prices array
                    prices[priceCount] = double.Parse(inFile.ReadLine());
                    // Increment priceCount to keep track of the number of prices
                    priceCount++;
                }
            }
            catch
            {
                // Display a message box if an error occurs
                MessageBox.Show("The file 'Prices.txt' was not found in FrmMain. Please contact admin.");
            }
        }

        // Check which bread type radio button is selected and return the corresponding index
        private int breadCheck()
        {
            if (radWhite.Checked) return 0;
            if (radWheat.Checked) return 1;
            if (radGlutenFree.Checked) return 2;
            if (radRye.Checked) return 3;
            if (radSourdough.Checked) return 4;
            if (radCiabata.Checked) return 5;
            return 6;
        }
        // Check which meat type radio button is selected and return the corresponding index
        private int meatCheck()
        {
            if (radRegularMeat.Checked)
            {
                return 0; // Regular meat selected
            }
            else if (radImpossible.Checked)
            {
                return 1; // Impossible meat selected
            }
            else
            {
                return 2; // No selection or other case
            }
        }

        // Add selected toppings to the order list
        private void toppingsCheck()
        {
            if (cbxEverything.Checked)
            {
                // If "Everything" is checked, add all toppings to the order list
                for (int i = 0; i < toppings.Length; i++)
                {
                    lstCheckOrder.Items.Add("      " + toppings[i]);
                }
            }
            else
            {
                // Add only the selected toppings to the order list
                if (cbxLettuce.Checked)
                    lstCheckOrder.Items.Add("      " + toppings[0]);
                if (cbxTomato.Checked)
                    lstCheckOrder.Items.Add("      " + toppings[1]);
                if (cbxMayo.Checked)
                    lstCheckOrder.Items.Add("      " + toppings[2]);
                if (cbxProvolone.Checked)
                    lstCheckOrder.Items.Add("      " + toppings[3]);
                if (cbxOnion.Checked)
                    lstCheckOrder.Items.Add("      " + toppings[4]);
            }
        }

        // Clear all checkbox and radio button selections
        private void clearChecks()
        {
            cbxLettuce.Checked = false;
            cbxOnion.Checked = false;
            cbxMayo.Checked = false;
            cbxProvolone.Checked = false;
            cbxTomato.Checked = false;
            cbxEverything.Checked = false;
            radWhite.Checked = false;
            radWheat.Checked = false;
            radGlutenFree.Checked = false;
            radRye.Checked = false;
            radSourdough.Checked = false;
            radCiabata.Checked = false;
            radRegularMeat.Checked = false;
            radImpossible.Checked = false;
        }

        // Form load event handler
        private void frmMain_Load(object sender, EventArgs e)
        {
            frmSplash frmSplashScreen = new frmSplash();
            frmSplashScreen.ShowDialog(this);
            user_name = frmSplashScreen.txtName.Text;
            orderNumber++;
            preOrderAdd();

            // Load data for main dishes, salads, drinks, and desserts
            LoadData(MainDishesFileName, main_Dishes, ref mainDishCount);
            LoadData(SaladsFileName, salads, ref saladsCount);
            LoadData(DrinksFileName, drinks, ref drinksCount);
            LoadData(DessertsFileName, desserts, ref dessertsCount);
            loadprices();

            // Add items to the list boxes with their prices
            for (int i = 0; i < mainDishCount; i++)
            {
                lstMainDishes.Items.Add(main_Dishes[i]);
                lstOrderPrices.Items.Add(prices[i].ToString("C"));
            }
            if (mainDishCount == 0)
            {
                MessageBox.Show("Sorry, no values set yet.");
            }
            for (int i = 0; i < saladsCount; i++)
            {
                lstSalads.Items.Add(salads[i]);
                lstSaladPrices.Items.Add(prices[mainDishCount + i].ToString("C"));
            }
            for (int i = 0; i < drinksCount; i++)
            {
                lstDrinks.Items.Add(drinks[i]);
                lstDrinkPrices.Items.Add(prices[mainDishCount + saladsCount + i].ToString("C"));
            }
            for (int i = 0; i < dessertsCount; i++)
            {
                lstDesserts.Items.Add(desserts[i]);
                lstDessertPrices.Items.Add(prices[mainDishCount + saladsCount + drinksCount + i].ToString("C"));
            }
            if (priceCount == 0)
            {
                MessageBox.Show("Sorry, no values set yet.");
            }
        }

        // Event handler for adding a main dish to the order
        private void btnAddMainDish_Click(object sender, EventArgs e)
        {
            clearChecks();
            int selectionIndex = lstMainDishes.SelectedIndex;
            try
            {
                if (selectionIndex == -1)
                {
                    throw new Exception("Please select a Main Dish!");
                }

                // If the selected item is a sandwich, show additional options
                if (lstMainDishes.SelectedItem.ToString().Contains("Sandwich"))
                {
                    gbxComidations.Visible = true;
                    lstMainDishes.Visible = false;
                    lstOrderPrices.Visible = false;
                    tabControl1.TabPages.Remove(tabCurrentOrder);
                    tabControl1.TabPages.Remove(tabSalads);
                    tabControl1.TabPages.Remove(tabDrinks);
                    tabControl1.TabPages.Remove(tabDesserts);
                }
                else
                {
                    // Add the selected item to the current order list
                    lstCurrentOrder.Items.Add(lstMainDishes.SelectedItem);
                    currentOrder[currentOrderCount] = prices[selectionIndex];
                    currentOrderCount++;
                    lstMainDishes.ClearSelected();
                    MessageBox.Show("Item was added to your current order: " + currentOrder[currentOrderCount - 1]);
                    if (tabControl1.TabPages.Count < 5)
                    {
                        tabControl1.TabPages.Insert(4, tabCurrentOrder);
                        tabControl1.SelectedIndex = 4;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for "Everything" checkbox change
        private void cbxEverything_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxEverything.Checked)
            {
                // Check all other checkboxes if "Everything" is checked
                cbxLettuce.Checked = true;
                cbxOnion.Checked = true;
                cbxMayo.Checked = true;
                cbxProvolone.Checked = true;
                cbxTomato.Checked = true;
            }
            else
            {
                // Uncheck all other checkboxes if "Everything" is unchecked
                cbxLettuce.Checked = false;
                cbxTomato.Checked = false;
                cbxMayo.Checked = false;
                cbxProvolone.Checked = false;
                cbxOnion.Checked = false;
            }
        }

        // Event handler for canceling the addition of a main dish
        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbxComidations.Visible = false;
            clearChecks();
            lstMainDishes.Visible = true;
            lstOrderPrices.Visible = true;
            lstMainDishes.ClearSelected();

            int currentOrderIndex = lstCurrentOrder.Items.Count;
            if (currentOrderIndex == 0)
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Remove(tabCurrentOrder);
            }
            else
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Insert(4, tabCurrentOrder);
            }
        }

        // Event handler for proceeding to the next step after selecting a sandwich
        private void btnNext_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstMainDishes.SelectedIndex;
            int bread = breadCheck();
            int meat = meatCheck();

            if (bread != 6 && meat != 2)
            {
                // Add the selected main dish and its details to the check order list
                lstCheckOrder.Items.Add(lstMainDishes.SelectedItem);
                lstCheckOrder.Items.Add("      " + breadTypes[bread] + " bread");
                lstCheckOrder.Items.Add("      " + meatTypes[meat] + " meat");
                toppingsCheck();
                gbxComidations.Visible = false;
                gbxCheckOrder.Visible = true;
                currentOrder[currentOrderCount] = prices[selectedIndex];
                currentOrderCount++;
            }
            else
            {
                MessageBox.Show("Please select bread and meat options!");
            }
        }

        // Event handler for going back to the previous step in the sandwich selection
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            gbxCheckOrder.Visible = false;
            lstCheckOrder.Items.Clear();
            gbxComidations.Visible = true;
        }

        // Event handler for canceling the current order
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            gbxCheckOrder.Visible = false;
            lstCheckOrder.Items.Clear();
            clearChecks();
            lstMainDishes.Visible = true;
            lstOrderPrices.Visible = true;
            lstMainDishes.ClearSelected();

            int currentOrderIndex = lstCurrentOrder.Items.Count;
            if (currentOrderIndex == 0)
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Remove(tabCurrentOrder);
            }
            else
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Insert(4, tabCurrentOrder);
            }
        }
        private void btnAddSandwich_Click(object sender, EventArgs e)
        {
            lstCheckOrder.Select();
            lstCurrentOrder.Items.AddRange(lstCheckOrder.Items);

            //gbxCheckOrder.Visible = false;
            lstCheckOrder.Items.Clear();
            clearChecks();
            gbxComidations.Visible = false;
            gbxCheckOrder.Visible = false;


            MessageBox.Show("item was added to your current order");
            lstMainDishes.ClearSelected();
            if (tabControl1.TabPages.Count < 5)
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Insert(4, tabCurrentOrder);
                tabControl1.SelectedIndex = 4;
            }
            lstMainDishes.Visible = true;
            lstOrderPrices.Visible = true;
            
        }


        private void DeleteItemAndSubItems(ListBox listBox, string itemToDelete)
        {
            // Find the index of the item to delete
            int index = listBox.Items.IndexOf(itemToDelete);
            if (index != -1)
            {
                // Remove the item
                listBox.Items.RemoveAt(index);
                currentOrder[index] = 0;
                updateCurrentOrder(index);


                // Remove sub-items (lines starting with whitespace)
                while (index < listBox.Items.Count && listBox.Items[index].ToString().StartsWith("      "))
                {
                    listBox.Items.RemoveAt(index);
                }
                int currentOrderindex = lstCurrentOrder.Items.Count;
                if (currentOrderindex == 0)
                {
                    tabControl1.TabPages.Remove(tabCurrentOrder);
                    // Switch to the appropriate tab
                    tabControl1.SelectedIndex = 0;
                }
            }
        }
        private void editOrders(ListBox listBox)
        {
            int index = listBox.SelectedIndex;
            if (index != -1)
            {
                clearChecks(); // Clear all previous checks

                // Move to the next item, which should be the bread type
                index++;
                if (index < listBox.Items.Count && listBox.Items[index].ToString().StartsWith("      "))
                {
                    string breadType = listBox.Items[index].ToString().Trim();
                    switch (breadType)
                    {
                        case "White bread":
                            radWhite.Checked = true;
                            break;
                        case "Wheat bread":
                            radWheat.Checked = true;
                            break;
                        case "Gluten Free bread":
                            radGlutenFree.Checked = true;
                            break;
                        case "Rye bread":
                            radRye.Checked = true;
                            break;
                        case "Sourdough bread":
                            radSourdough.Checked = true;
                            break;
                        case "Ciabata bread":
                            radCiabata.Checked = true;
                            break;
                    }
                    index++;
                }

                // Move to the next item, which should be the meat type
                if (index < listBox.Items.Count && listBox.Items[index].ToString().StartsWith("      "))
                {
                    string meatType = listBox.Items[index].ToString().Trim();
                    switch (meatType)
                    {
                        case "Regular meat":
                            radRegularMeat.Checked = true;
                            break;
                        case "Impossible meat":
                            radImpossible.Checked = true;
                            break;
                    }
                    index++;
                }

                // The remaining items should be the toppings
                while (index < listBox.Items.Count && listBox.Items[index].ToString().StartsWith("      "))
                {
                    string topping = listBox.Items[index].ToString().Trim();
                    switch (topping)
                    {
                        case "Lettuce":
                            cbxLettuce.Checked = true;
                            break;
                        case "Tomatoes":
                            cbxTomato.Checked = true;
                            break;
                        case "Mayo":
                            cbxMayo.Checked = true;
                            break;
                        case "Provolone":
                            cbxProvolone.Checked = true;
                            break;
                        case "Onions":
                            cbxOnion.Checked = true;
                            break;
                    }
                    index++;
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCurrentOrder.SelectedIndex != -1)
            {
                // Get the selected item
                string selectedItem = lstCurrentOrder.SelectedItem.ToString();

                // Delete the selected item and its sub-items
                DeleteItemAndSubItems(lstCurrentOrder, selectedItem);
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private void lstCurrentOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCurrentOrder.SelectedIndex != -1)
            {
                string selectedItem = lstCurrentOrder.SelectedItem.ToString();

                // Check if the selected item is a sub-item (starts with whitespace)
                if (selectedItem.StartsWith("      "))
                {
                    // Clear the selection if it's a sub-item
                    lstCurrentOrder.ClearSelected();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //Get selected item
            int selectedIndex = lstCurrentOrder.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Please click a sandwich to edit");
            }
            else
            {
                string selectedItem = lstCurrentOrder.SelectedItem.ToString();
                if (selectedItem.Contains("Sandwich"))
                {
                    editOrders(lstCurrentOrder);
                    // Show the group box for editing
                    gbxComidations.Visible = true;
                    lstMainDishes.Visible = false;
                    lstOrderPrices.Visible = false;
                    btnAddEditedSandwich.Visible = true;
                    btnCancelEditedOrder.Visible = true;
                    btnCancelEdit.Visible = true;
                    // Switch to the appropriate tab
                    tabControl1.SelectedIndex = 0;
                    tabControl1.TabPages.Remove(tabCurrentOrder);
                    tabControl1.TabPages.Remove(tabSalads);
                    tabControl1.TabPages.Remove(tabDrinks);
                    tabControl1.TabPages.Remove(tabDesserts);
                    //
                    int indexInOrderItems = lstMainDishes.Items.IndexOf(selectedItem);
                    if (indexInOrderItems != -1)
                    {
                        lstMainDishes.SelectedIndex = indexInOrderItems;
                    }

                }

            }

        }

        private void updateCurrentOrder(int selection)
        {
            for(int i = selection; i < currentOrderCount;i++)
            {
                currentOrder[i] = currentOrder[i + 1];
            }
            currentOrderCount--;
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            // Get the selected item
            int selectionIndex = lstCurrentOrder.SelectedIndex;
            string selectedItem = lstCurrentOrder.SelectedItem.ToString();

            // Show the group box for editing
            lstCheckOrder.Items.Add(selectedItem);


            // Edit the selected item and reflect the changes in the checkboxes
            editOrders(lstCurrentOrder);
            int bread = breadCheck();
            int meat = meatCheck();
            if (bread != 6 && meat != 2)
            {
                lstCheckOrder.Items.Add(("      " + breadTypes[bread] + " bread"));
                lstCheckOrder.Items.Add(("      " + meatTypes[meat] + " meat"));
                toppingsCheck();
            }

            // Add the edited order items
            lstCheckOrder.Items.AddRange(lstCurrentOrder.Items);

            // Hide the edit and cancel buttons, clear the temporary list
            btnCancelEdit.Visible = false;
            lstCheckOrder.Items.Clear();
            gbxComidations.Visible = false;
            btnAddEditedSandwich.Visible = false;
            btnCancelEditedOrder.Visible = false;

            // Ensure the Current Order tab is visible and selected
            if (tabControl1.TabPages.Count < 5)
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Insert(4, tabCurrentOrder);
                tabControl1.SelectedIndex = 4;
            }
            tabControl1.SelectedIndex = 4;
            lstMainDishes.Visible = true;
            lstOrderPrices.Visible = true;
            lstMainDishes.ClearSelected();
        }

        private void btnAddEditedSandwich_Click(object sender, EventArgs e)
        {
            // Get the selected item
            string selectedItem = lstCurrentOrder.SelectedItem.ToString();

            // Remove the original item and its sub-items
            DeleteItemAndSubItems(lstCurrentOrder, selectedItem);

            // Add the edited order items
            lstCurrentOrder.Items.AddRange(lstCheckOrder.Items);

            // Ensure the Current Order tab is visible and selected
            if (tabControl1.TabPages.Count < 5)
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Insert(4, tabCurrentOrder);
                tabControl1.SelectedIndex = 4;
            }

            // Clear the temporary list and hide buttons
            lstCheckOrder.Items.Clear();
            btnAddEditedSandwich.Visible = false;
            btnCancelEditedOrder.Visible = false;
            btnCancelEdit.Visible = false;
            gbxCheckOrder.Visible = false;
            lstMainDishes.Visible = true;
            lstOrderPrices.Visible = true;
            lstMainDishes.ClearSelected();
        }

        private void btnCancelEditedOrder_Click(object sender, EventArgs e)
        {

            lstCheckOrder.Items.Clear();
            lstMainDishes.ClearSelected();
            if (tabControl1.TabPages.Count < 5)
            {
                tabControl1.TabPages.Insert(1, tabSalads);
                tabControl1.TabPages.Insert(2, tabDrinks);
                tabControl1.TabPages.Insert(3, tabDesserts);
                tabControl1.TabPages.Insert(4, tabCurrentOrder);
                tabControl1.SelectedIndex = 4;
            }
            gbxCheckOrder.Visible = false;
            btnCancelEdit.Visible = false;
            btnCancelEditedOrder.Visible = false;
            btnAddEditedSandwich.Visible = false;
            lstMainDishes.Visible = true;
            lstOrderPrices.Visible = true;
        }
        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
  
            foreach ( var listCurrentOrder in lstCurrentOrder.Items)
            {
                rtxtReceipt.AppendText(listCurrentOrder.ToString());
                rtxtReceipt2.AppendText(listCurrentOrder.ToString());
                if (!listCurrentOrder.ToString().StartsWith(" "))
                {
                    rtxtReceipt.AppendText("   " + currentOrder[placeOrder].ToString("C"));
                    rtxtReceipt2.AppendText("   " + currentOrder[placeOrder].ToString("C"));
                    rtxtReceipt2.Text += "\r\n";
                    rtxtReceipt.Text += "\r\n";
                    placeOrder++;
                }
                else
                {
                    rtxtReceipt.Text += "\r\n";
                    rtxtReceipt2.Text += "\r\n";
                }
                   
            }
            lstCurrentOrder.Items.Clear();
            btnPayForFood.Visible = true;
            for ( int i = 0; i < drinksCount; i++)
            {
                if (!rtxtReceipt.Text.Contains(drinks[i]))
                {
                    tabControl1.SelectedIndex = 2;
                }
            }

        }

        private void btnAddDrink_Click(object sender, EventArgs e)
        {
            try
            {
                int selectionIndex = lstDrinks.SelectedIndex;

                currentOrder[currentOrderCount] = prices[mainDishCount + saladsCount + selectionIndex];
                currentOrderCount++;
                lstCurrentOrder.Items.Add(lstDrinks.SelectedItem);
                lstDrinks.ClearSelected();
                MessageBox.Show("item was added to your current order" + currentOrder[currentOrderCount - 1]);
                if (tabControl1.TabPages.Count < 5)
                {
                    tabControl1.TabPages.Insert(4, tabCurrentOrder);
                    tabControl1.SelectedIndex = 4;
                    //MessageBox.Show("item was added to your current order. if you want to delete it, then click on the item and hit the 'delete' button in the right. Note that you can only edit sandwiches. Finally, if you are ready to place order just hit the 'place order' button and we'll start prepping your meal.");
                }
            }catch
            {
                MessageBox.Show("Please Select A Drink.");
            }

        }

        private void btnPayForFood_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 5;
            if (tabControl1.TabPages.Count == 6)
            {
                //Prepare to add receipt
                tabControl1.TabPages.Remove(tabMainDishes);
                tabControl1.TabPages.Remove(tabSalads);
                tabControl1.TabPages.Remove(tabDrinks);
                tabControl1.TabPages.Remove(tabDesserts);
                tabControl1.TabPages.Remove(tabCurrentOrder);
            }
            calcSumAndTax();

            //take you to checkout
            frmCheckout form2 = new frmCheckout();
            form2.getSum = orderSum;
            form2.getTax = orderTax;
            // Show Form2
            form2.Show(this);
            custReceipt();
        }

        private void btnAddSalad_Click(object sender, EventArgs e)
        {
            try
            {
                int selectionIndex = lstSalads.SelectedIndex;

                currentOrder[currentOrderCount] = prices[mainDishCount + selectionIndex];
                currentOrderCount++;
                lstCurrentOrder.Items.Add(lstSalads.SelectedItem);
                lstSalads.ClearSelected();
                MessageBox.Show("item was added to your current order" + currentOrder[currentOrderCount - 1]);
                if (tabControl1.TabPages.Count < 5)
                {
                    tabControl1.TabPages.Insert(4, tabCurrentOrder);
                    tabControl1.SelectedIndex = 4;
                }
            }
            catch
            {
                MessageBox.Show("Please Select A Salad.");
            }

        }

        private void btnAddDesserts_Click(object sender, EventArgs e)
        {
            try
            {
                int selectionIndex = lstDesserts.SelectedIndex;

                currentOrder[currentOrderCount] = prices[mainDishCount + saladsCount + drinksCount + selectionIndex];
                currentOrderCount++;
                lstCurrentOrder.Items.Add(lstDesserts.SelectedItem);
                lstDesserts.ClearSelected();
                MessageBox.Show("item was added to your current order" + currentOrder[currentOrderCount - 1]);
                if (tabControl1.TabPages.Count < 5)
                {
                    tabControl1.TabPages.Insert(4, tabCurrentOrder);
                    tabControl1.SelectedIndex = 4;
                }
            }
            catch
            {
                MessageBox.Show("Please Select A Dessert.");
            }

        }
        private void calcSumAndTax()
        {
            for (int i = 0; i < currentOrderCount; i++)
            {
                orderSum += currentOrder[i];
            }
            orderTax = orderSum * TAX_PERCENT;
        }

        private void custReceipt()
        {
            //put Receipts onto screen
            tabControl1.TabPages.Remove(tabMainDishes);
            tabControl1.TabPages.Remove(tabSalads);
            tabControl1.TabPages.Remove(tabDrinks);
            tabControl1.TabPages.Remove(tabCurrentOrder);
            tabControl1.TabPages.Remove(tabDesserts);
            btnCloseReceipt.Visible = false;
            tabControl1.TabPages.Add(tabReceipt);
            
        }

        private void btnShowReceipt_Click(object sender, EventArgs e)
        {
            //Show the receipt
            btnShowReceipt.Visible = false;
            postOrderAdd();
            rtxtReceipt2.Visible = true;
            btnCloseReceipt.Visible = true;

        }

        private void preOrderAdd()
        {
            
            rtxtReceipt2.AppendText("Delicioso E-Restorante" + "\r\n");
            rtxtReceipt2.AppendText("Address: " + "\r\n");
            rtxtReceipt2.AppendText("Name: " + user_name.ToString() + "\r\n");
            rtxtReceipt2.AppendText("Order #" +orderNumber.ToString() + "\r\n");
            rtxtReceipt2.AppendText("------------------------------------------" + "\r\n");
        }

        private void postOrderAdd()
        {
            rtxtReceipt2.AppendText("------------------------------------------" + "\r\n");
            rtxtReceipt2.AppendText("total: " + orderSum.ToString("C")+"\r\n");
            rtxtReceipt2.AppendText("tax: "  + orderTax.ToString("C")+ "\r\n");
            rtxtReceipt2.AppendText("Tip " + orderTip.ToString("C") + "\r\n");
            rtxtReceipt2.AppendText("sub-total: " + subTotal.ToString("C") + "\r\n");
        }

        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() ==  DialogResult.OK)
            {
                TextWriter outFile = new StreamWriter(saveFileDialog1.FileName + ".txt");
                outFile.WriteLine(rtxtReceipt2.Text);
                outFile.Close();
            }
        }
    }
}
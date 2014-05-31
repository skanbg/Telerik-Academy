
namespace WarehouseSystem.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Reflection;
    using WarehouseSystem.Interfaces;
    using WarehouseSystem.StoreObjects;
    using WarehouseSystem.Store;
    using WarehouseSystem.Enumerations;
    using WarehouseSystem.Exceptions;

    public class ProgramEngine : IEngine
    {
        public static List<StoreObject> ItemContainer = new List<StoreObject>();
        public static List<UIElement> PropertyContents = new List<UIElement>();
        public static DesktopStore InstanceStore = new DesktopStore();

        private MainWindow window;

        public ProgramEngine(MainWindow window)
        {
            this.window = window;
        }

        public void Run()
        {
            this.window.DataContext = InstanceStore;
            ItemContainer = InstanceStore.GetAllProducts();
            LoadCategoryTabs();
            LoadCategories(InstanceStore);
            GenerateAllProducts();
            this.window.productCategories.SelectionChanged += ChangeValue;
            this.window.AddButton.Click += AddProduct;
        }

        // Loading the product categories to the initial add product screen
        private void LoadCategories(DesktopStore desktopStore)
        {
            this.window.productCategories.ItemsSource = desktopStore.GetCategories();
        }
        
        // Loading the existing product categories to the category tab
        private void LoadCategoryTabs()
        {
            var existingCategories = ItemContainer.Select(x => x.Category.ToString()).Distinct().ToList<string>();
            CreateInnerTabsWithContent(existingCategories);
        }

        // Generating all products to all products tab
        public void GenerateAllProducts()
        {
            this.window.AllProductsStack.Children.Clear();
            foreach (var product in ItemContainer)
            {
                Button exportButton = new Button
                {
                    Content = "Export - " + product.CatalogueNumber,
                    FontWeight = FontWeights.Normal,
                    FontSize = 15,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Width = 170,
                    Margin = new Thickness(24, 0, 0, 5),
                    Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(160, 208, 237))

                };
                exportButton.Click += ExportProduct;
                StackPanel itemProps = new StackPanel();
                itemProps.Children.Add(new Label { Content = product.ToString(), Height = 250 });
                itemProps.Children.Add(exportButton);
                this.window.AllProductsStack.Children.Add(new Expander() { Header = product.Manufacturer + " " + "'" + product.Model + "'", Content = itemProps, FontSize = 20, FontWeight = FontWeights.Bold, FontStyle = FontStyles.Italic, FontFamily = new FontFamily("Consolas"), Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(204, 204, 204, 204)), Margin = new Thickness(2) });
            }
        }

        // This function loads subtabs in the 
        private void CreateInnerTabsWithContent(List<string> categories)
        {
            this.window.CategorySubContainer.Items.Clear();

            foreach (var category in categories)
            {
                TabItem currentItem = new TabItem();
                currentItem.Background = (Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#BDCBFF");
                //currentItem.Background = Brushes.LightSteelBlue;
                currentItem.Header = "_" + category;
                var categoryStackPannel = new StackPanel();
                //categoryStackPannel.Background = (Brush)new System.Windows.Media.BrushConverter().ConvertFromString("#FBFFF4");
                var categoryFilter =
                    from x in ItemContainer
                    where x.Category.ToString() == category.ToString()
                    select x;
                
                StackPanel sp = new StackPanel();
                foreach (var item in categoryFilter)
                {
                    Button exportButton = new Button
                    {
                        Content = "Export - " + item.CatalogueNumber,
                        FontWeight = FontWeights.Normal,
                        FontSize = 15,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Width = 170,
                        Margin = new Thickness(24, 0, 0, 5),
                        Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(160, 208, 237)),
                    };

                    exportButton.Click += ExportProduct;
                    StackPanel itemProps = new StackPanel();
                    itemProps.Children.Add(new Label { Content = item.ToString(), Height = 250 });
                    itemProps.Children.Add(exportButton);
                    sp.Children.Add(new Expander() { Header = item.Manufacturer + " " + "'" + item.Model + "'", Content = itemProps, FontSize = 20, FontWeight = FontWeights.Bold, FontStyle = FontStyles.Italic, FontFamily = new FontFamily("Consolas"), Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(204, 204, 204, 204)), Margin = new Thickness(2) });
                }

                categoryStackPannel.Children.Add(new ScrollViewer { Content = sp, CanContentScroll = true, VerticalScrollBarVisibility = ScrollBarVisibility.Auto });
                currentItem.Content = categoryStackPannel;
                this.window.CategorySubContainer.Items.Add(currentItem);
                GenerateAllProducts();
            }
        }

        // Combobox eventhandler, handles category changes
        private void ChangeValue(object sender, SelectionChangedEventArgs e)
        {
            switch (this.window.productCategories.SelectedIndex)
            {
                case 1: ElectronicObject eo = new ElectronicObject();
                    GenerateInputFields(eo);
                    this.window.AddTabChildStack.Background = Brushes.LightBlue;
                    break;
                case 2: ConstructionObject co = new ConstructionObject();
                    GenerateInputFields(co);
                    this.window.AddTabChildStack.Background = Brushes.LightCyan;
                    break;
                case 3: GardenObject go = new GardenObject();
                    GenerateInputFields(go);
                    this.window.AddTabChildStack.Background = Brushes.LightGreen;
                    break;
                case 4: SanitaryObject so = new SanitaryObject();
                    GenerateInputFields(so);
                    this.window.AddTabChildStack.Background = Brushes.LightCoral;
                    break;
                case 5: ToolObject to = new ToolObject();
                    GenerateInputFields(to);
                    this.window.AddTabChildStack.Background = Brushes.LightGoldenrodYellow;
                    break;
                case 6: MachineryObject mo = new MachineryObject();
                    GenerateInputFields(mo);
                    this.window.AddTabChildStack.Background = Brushes.LightSalmon;
                    break;
                case 7: AutoPartObject ao = new AutoPartObject();
                    GenerateInputFields(ao);
                    this.window.AddTabChildStack.Background = Brushes.LightGray;
                    break;
                default: this.window.AddTabChildStack.Children.RemoveRange(1, this.window.AddTabChildStack.Children.Count - 1);
                    this.window.AddTabChildStack.Background = Brushes.Transparent;
                    this.window.AddButton.IsEnabled = false;
                    break;
            }
        }

        // Generates the input fields, depending to the selected category
        private void GenerateInputFields(StoreObject obj)
        {
            PropertyContents.Clear();
            this.window.AddTabChildStack.Children.RemoveRange(1, this.window.AddTabChildStack.Children.Count - 1);
            var list = obj.GetType().GetProperties();
            this.window.AddButton.IsEnabled = true;


            foreach (var item in list)
            {
                this.window.AddTabChildStack.Children.Add(new Label { Content = item.Name + ":" });
                if (item.PropertyType.Name == "Branch")
                {
                    TextBox box = new TextBox
                    {
                        Text = this.window.productCategories.SelectedItem.ToString(),
                        Width = 150,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(10, 0, 0, 3)
                    };
                    this.window.AddTabChildStack.Children.Add(box);
                    PropertyContents.Add(box);
                }
                else if (item.PropertyType.Name == "Color")
                {
                    var colors = new List<string>();

                    foreach (var color in Enum.GetValues(typeof(WarehouseSystem.Enumerations.Color)))
                    {
                        colors.Add(color.ToString());
                    }
                    ComboBox comboBox = new ComboBox
                    {
                        ItemsSource = colors,
                        Width = 150,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(10, 0, 0, 3)
                    };
                    this.window.AddTabChildStack.Children.Add(comboBox);
                    PropertyContents.Add(comboBox);
                }
                else if (item.PropertyType.Name == "Material")
                {
                    var materials = new List<string>();

                    foreach (var material in Enum.GetValues(typeof(Material)))
                    {
                        materials.Add(material.ToString());
                    }
                    ComboBox comboBox = new ComboBox
                    {
                        ItemsSource = materials,
                        Width = 150,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(10, 0, 0, 3)
                    };
                    this.window.AddTabChildStack.Children.Add(comboBox);
                    PropertyContents.Add(comboBox);
                }
                else
                {
                    TextBox box = new TextBox
                    {
                        MaxLength = 20,
                        Width = 150,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(10, 0, 0, 3)
                    };

                    this.window.AddTabChildStack.Children.Add(box);
                    PropertyContents.Add(box);
                }
            }
        }

        // Add product button handler
        private void AddProduct(object sender, RoutedEventArgs e)
        {
            try
            {
                bool addProduct = true;
                var enumValue = Enum.Parse(typeof(Branch), this.window.productCategories.SelectedValue.ToString(), true);
                var getClassNameFromBranch = ((BranchToClassName)((int)enumValue)).ToString();
                var product = Activator.CreateInstance(Type.GetType("WarehouseSystem.StoreObjects." + getClassNameFromBranch, true));
                var list = product.GetType().GetProperties();
                int propertyIndex = 0;

                foreach (var property in PropertyContents)
                {
                    var controlType = property.GetType();

                    if (controlType.Name == "TextBox")
                    {
                        if (controlType.GetProperty("Text") != null)
                        {
                            var controlValue = property.GetType().GetProperty("Text").GetValue(property).ToString();
                            var propertyType = list[propertyIndex].PropertyType;
                            dynamic parsedValue;
                            if (propertyType.Name == "Branch")
                            {
                                parsedValue = Enum.Parse(typeof(Branch), controlValue);
                            }
                            else if (propertyType.Name == "Dimensions")
                            {

                                parsedValue = InstanceStore.ParseDimensions(controlValue.ToString());
                            }
                            else
                            {
                                parsedValue = Convert.ChangeType(controlValue.ToString(), propertyType.GetTypeInfo());
                            }
                            list[propertyIndex].SetValue(product, parsedValue);
                        }
                        else
                        {
                            addProduct = false;
                        }
                    }
                    else if (controlType.Name == "ComboBox")
                    {

                        try
                        {
                            var propertyType = list[propertyIndex].PropertyType;
                            dynamic parsedValue;
                            if (property.GetType().GetProperty("SelectedValue").GetValue(property) == null)
                            {
                                throw new SelectCategoryException();
                            }
                            var controlValue = property.GetType().GetProperty("SelectedValue").GetValue(property).ToString();

                            if (propertyType.Name == "Material")
                            {
                                parsedValue = Enum.Parse(typeof(Material), controlValue);
                            }
                            else if (propertyType.Name == "Color")
                            {
                                parsedValue = Enum.Parse(typeof(WarehouseSystem.Enumerations.Color), controlValue);
                            }
                            else
                            {
                                parsedValue = Convert.ChangeType(controlValue.ToString(), propertyType.GetTypeInfo());
                            }
                            list[propertyIndex].SetValue(product, parsedValue);
                        }
                        catch (SelectCategoryException sce)
                        {
                            MessageBox.Show(sce.Message);
                            addProduct = false;

                        }
                    }

                    if (addProduct != true)
                    {
                        break;
                    }
                    propertyIndex++;
                }

                if (addProduct)
                {
                    System.Windows.MessageBox.Show("Product successfully added!");
                    InstanceStore.AddProduct(product as StoreObject);
                    LoadCategoryTabs();
                    this.window.productCategories.SelectedIndex = 0; // clears the fields and selects none of the products categories to be added
                    InstanceStore.SaveStore();
                }
            }
            catch (FormatException)
            {
                //TODO: Check all control fields(input) for empty value
                //System.Windows.MessageBox.Show(ex.ToString());
                System.Windows.MessageBox.Show("Please fill all fields!");
            }
            finally
            {

            }
        }

        // Export button event handler
        private void ExportProduct(object sender, RoutedEventArgs e)
        {
            InstanceStore.ExportProduct((sender as Button).Content.ToString(), ItemContainer);
            InstanceStore.SaveStore();
            LoadCategoryTabs();
            GenerateAllProducts();
        }
    }
}
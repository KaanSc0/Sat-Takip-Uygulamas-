using System.Text.Json;

namespace SalesTrackingApp;

public partial class SalesListForm : Form
{
    private DataGridView dgvSalesList;
    private Button btnNavigateToSales;
    private Button btnDelete;
    private Label lblTotalAmount;
    private TextBox txtTotalAmount;
    private List<Sale> currentSales;

    public SalesListForm()
    {
        InitializeComponent();
        currentSales = new List<Sale>();
        LoadSalesData();
    }

    private void InitializeComponent()
    {
        this.Text = "Satış Listesi";
        this.ClientSize = new Size(1000, 600);
        this.StartPosition = FormStartPosition.CenterScreen;

        // Navigasyon Butonu
        btnNavigateToSales = new Button();
        btnNavigateToSales.Text = "Satış";
        btnNavigateToSales.Location = new Point(20, 20);
        btnNavigateToSales.Size = new Size(100, 30);
        btnNavigateToSales.Click += btnNavigateToSales_Click;

        // Sil Butonu
        btnDelete = new Button();
        btnDelete.Text = "Sil";
        btnDelete.Location = new Point(140, 20);
        btnDelete.Size = new Size(100, 30);
        btnDelete.BackColor = Color.Red;
        btnDelete.ForeColor = Color.White;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.FlatAppearance.BorderColor = Color.DarkRed;
        btnDelete.Click += btnDelete_Click;

        // Toplam Tutar
        lblTotalAmount = new Label();
        lblTotalAmount.Text = "Toplam Tutar:";
        lblTotalAmount.Location = new Point(20, 70);
        lblTotalAmount.Size = new Size(100, 20);

        txtTotalAmount = new TextBox();
        txtTotalAmount.Location = new Point(120, 70);
        txtTotalAmount.Size = new Size(300, 20);
        txtTotalAmount.ReadOnly = true;

        // DataGridView
        dgvSalesList = new DataGridView();
        dgvSalesList.Location = new Point(20, 120);
        dgvSalesList.Size = new Size(960, 440);
        dgvSalesList.AllowUserToAddRows = false;
        dgvSalesList.AllowUserToDeleteRows = false;
        dgvSalesList.ReadOnly = true;
        dgvSalesList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvSalesList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Sütunları ekle
        dgvSalesList.Columns.Add("colTcNo", "TC No");
        dgvSalesList.Columns.Add("colCustomerName", "Müşteri Adı");
        dgvSalesList.Columns.Add("colPhone", "Telefon");
        dgvSalesList.Columns.Add("colTotalAmount", "Toplam Tutar");
        dgvSalesList.Columns.Add("colSaleDate", "Satış Tarihi");
        dgvSalesList.Columns.Add("colProductDetails", "Ürün Detayları");

        this.Controls.AddRange(new Control[] { 
            btnNavigateToSales,
            btnDelete,
            lblTotalAmount, txtTotalAmount,
            dgvSalesList 
        });
    }

    private void LoadSalesData()
    {
        if (dgvSalesList == null) return;

        var sales = SalesManager.LoadSales();
        dgvSalesList.Rows.Clear();

        foreach (var sale in sales)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dgvSalesList);
            
            // Sütun indekslerini kullan
            row.Cells[0].Value = sale.TcNo;
            row.Cells[1].Value = sale.CustomerName;
            row.Cells[2].Value = sale.Phone;
            row.Cells[3].Value = sale.TotalAmount;
            row.Cells[4].Value = sale.SaleDate.ToString("dd.MM.yyyy HH:mm");
            
            // Ürün detaylarını birleştir
            var productDetails = string.Join("\n", sale.Items.Select(item => 
                $"{item.ProductName} - {item.Price}"));
            row.Cells[5].Value = productDetails;
            
            dgvSalesList.Rows.Add(row);
        }

        // Toplam tutarı hesapla
        decimal total = 0;
        foreach (var sale in sales)
        {
            if (decimal.TryParse(sale.TotalAmount, out decimal price))
            {
                total += price;
            }
        }
        if (txtTotalAmount != null)
        {
            txtTotalAmount.Text = total.ToString("C2");
        }
    }

    private void btnNavigateToSales_Click(object? sender, EventArgs e)
    {
        var mainForm = new Form1();
        mainForm.Show();
        this.Close();
    }

    private void btnDelete_Click(object? sender, EventArgs e)
    {
        if (dgvSalesList == null || dgvSalesList.SelectedRows.Count == 0)
        {
            MessageBox.Show("Lütfen silinecek satırı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var result = MessageBox.Show("Seçili satışı silmek istediğinize emin misiniz?", "Onay", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            try
            {
                var selectedIndex = dgvSalesList.SelectedRows[0].Index;
                var sales = SalesManager.LoadSales();
                
                if (selectedIndex >= 0 && selectedIndex < sales.Count)
                {
                    sales.RemoveAt(selectedIndex);
                    
                    // Güncellenmiş satış listesini kaydet
                    string jsonString = JsonSerializer.Serialize(sales, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(SalesManager.GetJsonFilePath(), jsonString);

                    // Listeyi yenile
                    LoadSalesData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Silme işlemi sırasında bir hata oluştu: {ex.Message}", "Hata", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
} 
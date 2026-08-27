namespace SalesTrackingApp;

public partial class Form1 : Form
{
    private decimal totalAmount = 0;
    private List<Sale> currentSales = new List<Sale>();
    private SalesListForm? salesListForm;

    public Form1()
    {
        InitializeComponent();
        LoadSalesData();
    }

    private void UpdateTotalAmount()
    {
        txtTotalAmount.Text = totalAmount.ToString("C2");
    }

    private void LoadSalesData()
    {
        if (dgvSales == null) return;

        var sales = SalesManager.LoadSales();
        dgvSales.Rows.Clear();

        foreach (var sale in sales)
        {
            var row = new DataGridViewRow();
            row.CreateCells(dgvSales);
            
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
            
            dgvSales.Rows.Add(row);
        }
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // Müşteri bilgileri kontrolü
        if (string.IsNullOrWhiteSpace(txtTcNo.Text))
        {
            MessageBox.Show("TC No boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTcNo.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
        {
            MessageBox.Show("Müşteri Adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCustomerName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPhone.Text))
        {
            MessageBox.Show("Telefon boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPhone.Focus();
            return;
        }

        // Ürün bilgileri kontrolü
        if (string.IsNullOrWhiteSpace(txtBarcode.Text))
        {
            MessageBox.Show("Barkod boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtBarcode.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtProductName.Text))
        {
            MessageBox.Show("Ürün Adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtProductName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPrice.Text))
        {
            MessageBox.Show("Fiyat boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPrice.Focus();
            return;
        }

        if (!decimal.TryParse(txtPrice.Text, out decimal price))
        {
            MessageBox.Show("Geçerli bir fiyat giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPrice.Focus();
            return;
        }

        var sale = new Sale
        {
            TcNo = txtTcNo.Text,
            CustomerName = txtCustomerName.Text,
            Phone = txtPhone.Text,
            Items = new List<SaleItem>
            {
                new SaleItem
                {
                    Barcode = txtBarcode.Text,
                    ProductName = txtProductName.Text,
                    Price = txtPrice.Text
                }
            },
            TotalAmount = txtPrice.Text,
            SaleDate = DateTime.Now
        };

        currentSales.Add(sale);
        totalAmount += price;
        UpdateTotalAmount();
        LoadSalesData();
        ClearProductInputs();
    }

    private void btnSale_Click(object sender, EventArgs e)
    {
        if (currentSales.Count == 0)
        {
            MessageBox.Show("Satış yapılacak ürün bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtTcNo.Text))
        {
            MessageBox.Show("TC No boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTcNo.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
        {
            MessageBox.Show("Müşteri Adı boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCustomerName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtPhone.Text))
        {
            MessageBox.Show("Telefon boş olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPhone.Focus();
            return;
        }

        // Yeni bir satış oluştur
        var sale = new Sale
        {
            TcNo = txtTcNo.Text,
            CustomerName = txtCustomerName.Text,
            Phone = txtPhone.Text,
            Items = new List<SaleItem>(),
            TotalAmount = totalAmount.ToString(),
            SaleDate = DateTime.Now
        };

        // Mevcut ürünleri satışa ekle
        foreach (var item in currentSales)
        {
            sale.Items.Add(new SaleItem
            {
                Barcode = item.Items[0].Barcode,
                ProductName = item.Items[0].ProductName,
                Price = item.Items[0].Price
            });
        }

        // Satışı JSON'a kaydet
        SalesManager.SaveSale(sale);
        
        // Satışları temizle
        currentSales.Clear();
        totalAmount = 0;
        UpdateTotalAmount();
        LoadSalesData();
        ClearProductInputs();

        MessageBox.Show("Satış başarıyla tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvSales.SelectedRows.Count == 0)
        {
            MessageBox.Show("Lütfen silinecek satırı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedSale = dgvSales.SelectedRows[0].DataBoundItem as Sale;
        if (selectedSale != null)
        {
            if (decimal.TryParse(selectedSale.TotalAmount, out decimal price))
            {
                totalAmount -= price;
            }
            currentSales.Remove(selectedSale);
            UpdateTotalAmount();
            LoadSalesData();
        }
    }

    private void btnClearAll_Click(object sender, EventArgs e)
    {
        if (currentSales.Count == 0)
        {
            return;
        }

        var result = MessageBox.Show("Tüm satışları silmek istediğinize emin misiniz?", "Onay", 
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
        {
            currentSales.Clear();
            totalAmount = 0;
            UpdateTotalAmount();
            LoadSalesData();
        }
    }

    private void btnNavigateToSales_Click(object sender, EventArgs e)
    {
        // Zaten satış formundayız
    }

    private void btnNavigateToSalesList_Click(object sender, EventArgs e)
    {
        if (salesListForm == null || salesListForm.IsDisposed)
        {
            salesListForm = new SalesListForm();
            salesListForm.FormClosed += (s, args) => { salesListForm = null; };
            salesListForm.Show();
        }
        else
        {
            salesListForm.BringToFront();
            salesListForm.Activate();
        }
    }

    private void ClearProductInputs()
    {
        txtBarcode.Clear();
        txtProductName.Clear();
        txtPrice.Clear();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        // DataGridView sütunlarını temizle ve yeniden oluştur
        dgvSales.Columns.Clear();
        
        // Sütunları ekle
        dgvSales.Columns.Add("colTcNo", "TC No");
        dgvSales.Columns.Add("colCustomerName", "Müşteri Adı");
        dgvSales.Columns.Add("colPhone", "Telefon");
        dgvSales.Columns.Add("colTotalAmount", "Toplam Tutar");
        dgvSales.Columns.Add("colSaleDate", "Satış Tarihi");
        dgvSales.Columns.Add("colProductDetails", "Ürün Detayları");

        LoadSalesData();
    }
}

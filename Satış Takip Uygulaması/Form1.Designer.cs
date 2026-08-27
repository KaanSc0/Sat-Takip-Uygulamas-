namespace SalesTrackingApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    private GroupBox customerGroup;
    private GroupBox productGroup;
    private Label lblTcNo;
    private TextBox txtTcNo;
    private Label lblCustomerName;
    private TextBox txtCustomerName;
    private Label lblPhone;
    private TextBox txtPhone;
    private Label lblBarcode;
    private TextBox txtBarcode;
    private Label lblProductName;
    private TextBox txtProductName;
    private Label lblPrice;
    private TextBox txtPrice;
    private Button btnSave;
    private Button btnSale;
    private Button btnDelete;
    private Button btnClearAll;
    private DataGridView dgvSales;
    private Button btnNavigateToSales;
    private Button btnNavigateToSalesList;
    private Label lblTotalAmount;
    private TextBox txtTotalAmount;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1000, 600);
        this.Text = "Satış Takip Uygulaması";
        this.StartPosition = FormStartPosition.CenterScreen;

        // Navigasyon Butonları
        btnNavigateToSales = new Button();
        btnNavigateToSales.Text = "Satış";
        btnNavigateToSales.Location = new Point(20, 20);
        btnNavigateToSales.Size = new Size(100, 30);
        btnNavigateToSales.Name = "btnNavigateToSales";
        btnNavigateToSales.Click += btnNavigateToSales_Click;

        btnNavigateToSalesList = new Button();
        btnNavigateToSalesList.Text = "Satışları Listele";
        btnNavigateToSalesList.Location = new Point(140, 20);
        btnNavigateToSalesList.Size = new Size(100, 30);
        btnNavigateToSalesList.Name = "btnNavigateToSalesList";
        btnNavigateToSalesList.Click += btnNavigateToSalesList_Click;

        // Müşteri Bilgileri GroupBox
        customerGroup = new GroupBox();
        customerGroup.Text = "Müşteri Bilgileri";
        customerGroup.Location = new Point(20, 70);
        customerGroup.Size = new Size(450, 150);

        // Müşteri Bilgileri Label ve TextBox'ları
        lblTcNo = new Label();
        lblTcNo.Text = "TC No:";
        lblTcNo.Location = new Point(20, 30);
        lblTcNo.Size = new Size(80, 20);

        txtTcNo = new TextBox();
        txtTcNo.Location = new Point(120, 30);
        txtTcNo.Size = new Size(300, 20);
        txtTcNo.Name = "txtTcNo";

        lblCustomerName = new Label();
        lblCustomerName.Text = "Müşteri Adı:";
        lblCustomerName.Location = new Point(20, 60);
        lblCustomerName.Size = new Size(80, 20);

        txtCustomerName = new TextBox();
        txtCustomerName.Location = new Point(120, 60);
        txtCustomerName.Size = new Size(300, 20);
        txtCustomerName.Name = "txtCustomerName";

        lblPhone = new Label();
        lblPhone.Text = "Telefon:";
        lblPhone.Location = new Point(20, 90);
        lblPhone.Size = new Size(80, 20);

        txtPhone = new TextBox();
        txtPhone.Location = new Point(120, 90);
        txtPhone.Size = new Size(300, 20);
        txtPhone.Name = "txtPhone";

        // Ürün Bilgileri GroupBox
        productGroup = new GroupBox();
        productGroup.Text = "Ürün Bilgileri";
        productGroup.Location = new Point(20, 240);
        productGroup.Size = new Size(450, 150);

        // Ürün Bilgileri Label ve TextBox'ları
        lblBarcode = new Label();
        lblBarcode.Text = "Barkod:";
        lblBarcode.Location = new Point(20, 30);
        lblBarcode.Size = new Size(80, 20);

        txtBarcode = new TextBox();
        txtBarcode.Location = new Point(120, 30);
        txtBarcode.Size = new Size(300, 20);
        txtBarcode.Name = "txtBarcode";

        lblProductName = new Label();
        lblProductName.Text = "Ürün Adı:";
        lblProductName.Location = new Point(20, 60);
        lblProductName.Size = new Size(80, 20);

        txtProductName = new TextBox();
        txtProductName.Location = new Point(120, 60);
        txtProductName.Size = new Size(300, 20);
        txtProductName.Name = "txtProductName";

        lblPrice = new Label();
        lblPrice.Text = "Fiyat:";
        lblPrice.Location = new Point(20, 90);
        lblPrice.Size = new Size(80, 20);

        txtPrice = new TextBox();
        txtPrice.Location = new Point(120, 90);
        txtPrice.Size = new Size(300, 20);
        txtPrice.Name = "txtPrice";

        // Toplam Tutar
        lblTotalAmount = new Label();
        lblTotalAmount.Text = "Toplam Tutar:";
        lblTotalAmount.Location = new Point(20, 410);
        lblTotalAmount.Size = new Size(100, 20);

        txtTotalAmount = new TextBox();
        txtTotalAmount.Location = new Point(120, 410);
        txtTotalAmount.Size = new Size(300, 20);
        txtTotalAmount.Name = "txtTotalAmount";
        txtTotalAmount.ReadOnly = true;

        // Butonlar
        btnSave = new Button();
        btnSave.Text = "Kaydet";
        btnSave.Location = new Point(20, 450);
        btnSave.Size = new Size(100, 30);
        btnSave.Name = "btnSave";
        btnSave.BackColor = Color.Green;
        btnSave.ForeColor = Color.White;
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.FlatAppearance.BorderColor = Color.DarkGreen;
        btnSave.Click += btnSave_Click;

        btnSale = new Button();
        btnSale.Text = "Satış";
        btnSale.Location = new Point(140, 450);
        btnSale.Size = new Size(100, 30);
        btnSale.Name = "btnSale";
        btnSale.BackColor = Color.Blue;
        btnSale.ForeColor = Color.White;
        btnSale.FlatStyle = FlatStyle.Flat;
        btnSale.FlatAppearance.BorderColor = Color.DarkBlue;
        btnSale.Click += btnSale_Click;

        btnDelete = new Button();
        btnDelete.Text = "Sil";
        btnDelete.Location = new Point(260, 450);
        btnDelete.Size = new Size(100, 30);
        btnDelete.Name = "btnDelete";
        btnDelete.BackColor = Color.Red;
        btnDelete.ForeColor = Color.White;
        btnDelete.FlatStyle = FlatStyle.Flat;
        btnDelete.FlatAppearance.BorderColor = Color.DarkRed;
        btnDelete.Click += btnDelete_Click;

        btnClearAll = new Button();
        btnClearAll.Text = "Tümünü Sil";
        btnClearAll.Location = new Point(380, 450);
        btnClearAll.Size = new Size(100, 30);
        btnClearAll.Name = "btnClearAll";
        btnClearAll.BackColor = Color.Orange;
        btnClearAll.ForeColor = Color.White;
        btnClearAll.FlatStyle = FlatStyle.Flat;
        btnClearAll.FlatAppearance.BorderColor = Color.DarkOrange;
        btnClearAll.Click += btnClearAll_Click;

        // DataGridView
        dgvSales = new DataGridView();
        dgvSales.AllowUserToAddRows = false;
        dgvSales.AllowUserToDeleteRows = false;
        dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvSales.Location = new System.Drawing.Point(500, 70);
        dgvSales.Name = "dgvSales";
        dgvSales.ReadOnly = true;
        dgvSales.RowHeadersWidth = 51;
        dgvSales.RowTemplate.Height = 24;
        dgvSales.Size = new System.Drawing.Size(460, 490);
        dgvSales.TabIndex = 0;
        dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        // Sütunları ekle
        dgvSales.Columns.Add("TcNo", "TC No");
        dgvSales.Columns.Add("CustomerName", "Müşteri Adı");
        dgvSales.Columns.Add("Phone", "Telefon");
        dgvSales.Columns.Add("TotalAmount", "Toplam Tutar");
        dgvSales.Columns.Add("SaleDate", "Satış Tarihi");
        dgvSales.Columns.Add("ProductDetails", "Ürün Detayları");

        // Kontrolleri GroupBox'lara ekle
        customerGroup.Controls.AddRange(new Control[] { lblTcNo, txtTcNo, lblCustomerName, txtCustomerName, lblPhone, txtPhone });
        productGroup.Controls.AddRange(new Control[] { lblBarcode, txtBarcode, lblProductName, txtProductName, lblPrice, txtPrice });

        // Form'a tüm kontrolleri ekle
        this.Controls.AddRange(new Control[] { 
            btnNavigateToSales, btnNavigateToSalesList,
            customerGroup, productGroup, 
            lblTotalAmount, txtTotalAmount,
            btnSave, btnSale, btnDelete, btnClearAll, 
            dgvSales 
        });
    }

    #endregion
}

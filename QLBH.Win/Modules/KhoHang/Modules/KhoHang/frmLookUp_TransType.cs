using DevExpress.XtraGrid.Columns;
using QLBanHang.Modules.KhoHang.Base;

namespace QLBanHang.Modules.KhoHang
{
    public class frmLookUp_TransType : frmLookUp_TransTypeBase
    {
        private GridColumn colTen;

        public frmLookUp_TransType(string searchInput) : base(searchInput)
        {
            InitializeComponent();
        }

        public frmLookUp_TransType(bool isMultiSelect, string searchInput)
            : base(isMultiSelect, searchInput)
        {
            InitializeComponent();
        }

        protected override string[] LookUpPropertyNames()
        {
            return new []{"Type"};
        }

        private void InitializeComponent()
        {
            this.colTen = new GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvLookUp)).BeginInit();
            this.SuspendLayout();
            // 
            // grvLookUp
            // 
            this.grvLookUp.Columns.AddRange(new GridColumn[] {
            this.colTen});
            // 
            // colTen
            // 
            //this.colTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTen.FieldName = "Name";
            this.colTen.Caption = "Loại giao dịch";
            this.colTen.Name = "colTen";
            this.colTen.OptionsColumn.AllowEdit = false;
            this.colTen.OptionsColumn.ReadOnly = true;
            this.colTen.Visible = true;
            // 
            // frmLookUp_Nganh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(690, 457);
            this.Name = "frmLookUp_TransType";
            this.Text = "Tìm kiếm nhanh loại giao dịch";
            ((System.ComponentModel.ISupportInitialize)(this.grvLookUp)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
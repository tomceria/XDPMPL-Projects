using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;
using TechShop_Manager.BUS;

namespace TechShop_Manager.GUI
{
    public partial class EditViewTemplate : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Customer _item;
        private bool isUpdate = false;

        public EditViewTemplate() // New Customer
        {
            InitializeComponent();
            _item = new Customer();
            ConfigureControls();
            InitializeDataSources();
        }

        public EditViewTemplate(Customer tour) // Edit Customer
        {
            InitializeComponent();
            _item = tour;
            isUpdate = true;
            ConfigureControls();
            InitializeDataSources();
        }

        private void ConfigureControls() {
            bbiDelete.Enabled = isUpdate;
        }

        private void InitializeDataSources() {
            // Data fetch
            Customer item = Customer.GetOne(_item.Id);

            if (item == null) {
                item = _item; // this "_item" would be INITIALIZED before running this method, meaning it has no reference to ANY BindingList, unlike EditViewTemplate(Customer tour)
            } else {
                _item = item;
            }

            // Data binding
            BindingList<Customer> itemBL = new BindingList<Customer>(new List<Customer>() { item });

            dataLayoutControl_Customer.DataSource = itemBL;

        }

        private Customer getItemState() {
            return _item;

            /*            return ((BindingList<Customer>) dataLayoutControl_Customer.DataSource).ElementAt(0);
            */
        }

        private bool ValidateForm()
        {
            Customer item = _item;

            try
            {
            } catch (ArgumentException e)
            {
                string message = e.Message.Split(Environment.NewLine.ToCharArray())[0];
                MessageBox.Show(message, "Lỗi dữ liệu nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // TODO: Focus on controls

                return false;
            }

            return true;
        }

        // Event Handlers

        private void handleSaveCustomer() {
            // Validations
            if (ValidateForm() == false)
            {
                return;
            }
            
            if (isUpdate) {
                // _item.Update();
            } else {
                // var temp = _item.Create();

                // if (temp.Id != 0)   // tourGroup added to Database => ID changed from 0
                // {
                //     isUpdate = true;
                // }
            }
            
            MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ConfigureControls();
            InitializeDataSources();
        }

        private void handleDeleteCustomer() {
            // Customer.DeleteOne(_item.Id);
            
            // close window
            Dispose();
        }

        private void handleCloseEdit() {
            //Revert changes when click close button
            // Customer.RevertChanges();
        }

        // Events

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            handleSaveCustomer();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            DialogResult res = MessageBox.Show("Bạn chắc chắn muốn xóa tour du lịch này?\nMọi dữ liệu liên quan sẽ bị xoá.", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                handleDeleteCustomer();
            }
        }

        private void tabbedDetails_SelectedPageChanged(object sender, LayoutTabPageChangedEventArgs e) {
            InitializeDataSources(); // TODO: This works for some reasons?????
        }

        private void EditViewTemplate_FormClosed(object sender, FormClosedEventArgs e)
        {
            handleCloseEdit();
        }
    }
}
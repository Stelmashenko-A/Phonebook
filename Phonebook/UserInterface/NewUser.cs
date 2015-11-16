using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Phonebook;

namespace UserInterface
{
    public partial class NewUser : Form
    {
        public NewUser(IRepository repository)
        {
            _repository = repository;
            InitializeComponent();
            dataGridViewPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPhones.MultiSelect = false;
        }

        private readonly IRepository _repository;
        private readonly IList<Phone> _phones = new List<Phone>(); 
        private void buttonAddNumber_Click(object sender, EventArgs e)
        {
            var form = new PhoneForm();
            form.ShowDialog();

            _phones.Add(new Phone(form.Phone,form.Description));
            dataGridViewPhones.Rows.Add(form.Phone, form.Description);
        }

        private void buttonSaveAccount_Click(object sender, EventArgs e)
        {
            _repository.AddUser(textBoxName.Text, _phones);
            Close();
        }

        private void buttonRemovePhone_Click(object sender, EventArgs e)
        {
            foreach (var value1 in from DataGridViewRow row in dataGridViewPhones.SelectedRows select row.Cells[0].Value.ToString())
            {
                _phones.Remove(_phones.First(x => x.Number == value1));
            }

            foreach (var t in dataGridViewPhones.SelectedRows)
            {
                dataGridViewPhones.Rows.RemoveAt(dataGridViewPhones.SelectedRows[0].Index);
            }
        }
    }
}

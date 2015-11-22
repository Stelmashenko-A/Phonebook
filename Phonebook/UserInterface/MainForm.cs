using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Phonebook;
using Phonebook.MSSQL;
using Phonebook.Raven;

namespace UserInterface
{
    public partial class MainForm : Form
    {
        private readonly IRepository _repository = new RavenRepository("Phonebook");

        public MainForm()
        {
            InitializeComponent();
            List<string> data;
            try
            {
                data = _repository.GetAllUserNames().ToList();
            }
            catch (Exception)
            {

                data = new List<string>();
            }
            listBoxUsers.DataSource = data;
            dataGridViewPhones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPhones.MultiSelect = false;

            try
            {
                var s = listBoxUsers.Items[0].ToString();
                var n = _repository.GetPhone(s);
                ViewPhones(n);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = listBoxUsers.SelectedItem.ToString();
            var n = _repository.GetPhone(s);
            ViewPhones(n);
        }

        private void ViewPhones(IEnumerable<Phone> phones)
        {
            dataGridViewPhones.Rows.Clear();
            foreach (var phone in phones)
            {
                dataGridViewPhones.Rows.Add(phone.Number, phone.Description);
            }
        }

        private void buttonAddPhone_Click(object sender, EventArgs e)
        {
            var phoneForm = new PhoneForm(_repository, listBoxUsers.SelectedItem.ToString());
            phoneForm.ShowDialog(this);
            var s = listBoxUsers.SelectedItem.ToString();
            var n = _repository.GetPhone(s);
            ViewPhones(n);
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new NewUser(_repository);
                form.ShowDialog();
                
                listBoxUsers.DataSource = _repository.GetAllUserNames().ToList();
                
                var s = listBoxUsers.SelectedItem.ToString();
                var n = _repository.GetPhone(s);
                ViewPhones(n);
            }
            catch (Exception)
            {
                
                
            }
            
        }

        private void buttonRemoveAccount_Click(object sender, EventArgs e)
        {
            var s = listBoxUsers.SelectedItem.ToString();
            _repository.RemoveUser(s);
            listBoxUsers.SelectedIndex = 0;
            s = listBoxUsers.SelectedItem.ToString();
            var n = _repository.GetPhone(s);
            ViewPhones(n);
            listBoxUsers.DataSource = _repository.GetAllUserNames().ToList();
        }

        private void buttonRemovePhone_Click(object sender, EventArgs e)
        {
            var number = dataGridViewPhones.SelectedRows[0].Cells[0].Value.ToString();
            var description = dataGridViewPhones.SelectedRows[0].Cells[1].Value.ToString();
            _repository.RemovePhone(listBoxUsers.SelectedItem.ToString(), new Phone(number, description));
            dataGridViewPhones.Rows.RemoveAt(dataGridViewPhones.SelectedRows[0].Index);
        }
    }
}

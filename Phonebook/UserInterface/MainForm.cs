using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Phonebook;

namespace UserInterface
{
    public partial class MainForm : Form
    {
        private readonly IRepository _repository = new RavenRepository("Phonebook");

        public MainForm()
        {
            InitializeComponent();
            listBoxUsers.DataSource = _repository.GetAllUserNames().ToList();
        }

        private void listBoxUsers_SelectedIndexChanged(object sender, System.EventArgs e)
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

        private void buttonAddPhone_Click(object sender, System.EventArgs e)
        {
            var phoneForm = new PhoneForm(_repository,listBoxUsers.SelectedItem.ToString());
            phoneForm.ShowDialog(this);
            var s = listBoxUsers.SelectedItem.ToString();
            var n = _repository.GetPhone(s);
            ViewPhones(n);
        }
    }
}

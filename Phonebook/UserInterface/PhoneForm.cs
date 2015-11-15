using System.Windows.Forms;
using Phonebook;

namespace UserInterface
{
    public partial class PhoneForm : Form
    {
        private readonly IRepository _repository;
        private readonly string _userName;

        public PhoneForm(IRepository repository, string userName)
        {
            _repository = repository;
            _userName = userName;
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            _repository.AddPhone(_userName,new Phone(textBoxPhone.Text,textBoxDescription.Text));
            Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}

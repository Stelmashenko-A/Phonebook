using System.Windows.Forms;
using Phonebook;

namespace UserInterface
{
    public partial class PhoneForm : Form
    {
        private readonly IRepository _repository;
        private readonly string _userName;
        public string Phone { get; protected set; }
        public string Description { get; protected set; }

        public PhoneForm(IRepository repository, string userName)
        {
            _repository = repository;
            _userName = userName;
            InitializeComponent();
        }

        public PhoneForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            if (_repository != null)
            {
                _repository.AddPhone(_userName, new Phone(textBoxPhone.Text, textBoxDescription.Text));
            }
            else
            {
                Phone = textBoxPhone.Text;
                Description = textBoxDescription.Text;
            }
            Close();
        }

        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}

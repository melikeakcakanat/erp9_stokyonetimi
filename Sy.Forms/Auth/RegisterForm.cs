using Sy.Business.Repository;
using Sy.Core.Abstracts;
using Sy.Core.Entities;
using Sy.Core.Enums;
using Sy.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sy.Forms.Auth
{
    public partial class RegisterForm : Form
    {
        private readonly IRepository<Client, int> _clientRepository;

        public RegisterForm()
        {
            InitializeComponent();
            _clientRepository = new Repository<Client, int>();
        }

        private void btnkayıt_Click(object sender, EventArgs e)
        {
            var model = new RegisterViewModel()
            {
                Email = txtmail.Text,
                Name = txtad.Text,
                Surname = txtsoyad.Text,
                Password = txtsifre.Text

            };
            //e-mail var mı kontrol edelim..
            var kontrol = _clientRepository.Query(predicate:x => x.Email == model.Email).Any();
            if (kontrol)
            {
                MessageBox.Show("Bu email adresi kullanılmaktadır.!");
                return;
            }

            //benzersiz email kontorlünden sonra kişiyi kaydedelim.
            var musteriMi = _clientRepository.Query().Any();
           

            _clientRepository.Insert(new Client()
            {
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                Password = model.Password,
                ApplicationRole = musteriMi ? ApplicationRole.Customer : ApplicationRole.Admin
            });

            MessageBox.Show($"Kayıt işleminiz başarılıdır.\n{model.Name} {model.Surname}");

            this.Close();


        }
    }
}

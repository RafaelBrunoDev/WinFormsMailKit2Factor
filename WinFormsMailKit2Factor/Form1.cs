using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;

namespace WinFormsMailKit2Factor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            


            // Configurar as credenciais de autenticação
            string email = "email";
            string senhaAplicativo = "senha";

            // Configurar as informações do servidor IMAP
            string imapServer = "outlook.office365.com";
            int imapPort = 993;

            try
            {
                // Criar uma instância do cliente IMAP
                using (var client = new ImapClient())
                {
                    // Desabilitar a validação do certificado SSL
                    client.ServerCertificateValidationCallback = (s, c, h, sslErrors) => true;

                    // Conectar ao servidor IMAP
                    client.Connect(imapServer, imapPort, SecureSocketOptions.SslOnConnect);

                    // Autenticar usando as credenciais de senha de aplicativo
                    client.Authenticate(email, senhaAplicativo);

                    // Exibir informações da caixa de correio
                    MessageBox.Show("Autenticação realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Desconectar do servidor IMAP
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro durante a autenticação ou conexão IMAP: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

           

        
    }
}
    
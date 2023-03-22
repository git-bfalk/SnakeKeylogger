using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Snake_Keylogger.snakesystem;


namespace Snake_Keylogger
{
	// Token: 0x0200001E RID: 30
	public partial class Login : Form
	{
		// Token: 0x06000276 RID: 630 RVA: 0x000033BD File Offset: 0x000015BD
		public Login()
		{
			base.Load +=this.frmCVLogin_Load;
		this.InitializeComponent();
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0001C5D0 File Offset: 0x0001A7D0
		private void btnLogin_Click(object sender, EventArgs e)
		{
			if (this.CheckBox1.Checked)
			{
				StreamWriter streamWriter = new StreamWriter("Snakelogin.ini");
				streamWriter.WriteLine(this.Encrypt(this.txtUsername.Text));
				streamWriter.WriteLine(this.Encrypt(this.txtPassword.Text));
				streamWriter.Close();
			}
			else
			{
				File.Delete("Snakelogin.ini");
			}
			CodeVest.mainForm.MetroLabel20.Text = this.username;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00003453 File Offset: 0x00001653
		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000345C File Offset: 0x0000165C
		private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			new Registter().ShowDialog();
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000346F File Offset: 0x0000166F
		private void txtUsername_TextChanged(object sender, EventArgs e)
		{
		this.username =this.txtUsername.Text;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x00003483 File Offset: 0x00001683
		private void txtPassword_TextChanged(object sender, EventArgs e)
		{
		this.password =this.txtPassword.Text;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0001C664 File Offset: 0x0001A864
		public string Decrypt(string cipherText)
		{
			byte[] bytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
			byte[] bytes2 = Encoding.ASCII.GetBytes("cffffffffffffffffff");
			byte[] array = Convert.FromBase64String(cipherText);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("test", bytes2, 2);
			byte[] bytes3 = rfc2898DeriveBytes.GetBytes(32);
			ICryptoTransform cryptoTransform = new RijndaelManaged { Mode = CipherMode.CBC }.CreateDecryptor(bytes3, bytes);
			MemoryStream memoryStream = new MemoryStream(array);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
			byte[] array2 = new byte[checked(array.Length - 1 + 1)];
			int num3 = cryptoStream.Read(array2, 0, array2.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array2, 0, num3);
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0001C754 File Offset: 0x0001A954
		public string Encrypt(string plainText)
		{
            byte[] bytes = Encoding.ASCII.GetBytes("@1B2c3D4e5F6g7H8");
            byte[] bytes2 = Encoding.ASCII.GetBytes("cffffffffffffffffff");
			byte[] bytes3 = Encoding.UTF8.GetBytes(plainText);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("test", bytes2, 2);
			byte[] bytes4 = rfc2898DeriveBytes.GetBytes(32);
			ICryptoTransform cryptoTransform = new RijndaelManaged { Mode = CipherMode.CBC }.CreateEncryptor(bytes4, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes3, 0, bytes3.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(array);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x0001C840 File Offset: 0x0001AA40
		private void frmCVLogin_Load(object sender, EventArgs e)
		{
			bool flag = File.Exists("Snakelogin.ini");
			if (flag)
			{
				StreamReader streamReader = new StreamReader("Snakelogin.ini");
			this.txtUsername.Text =this.Decrypt(streamReader.ReadLine());
			this.txtPassword.Text =this.Decrypt(streamReader.ReadLine());
				streamReader.Close();
				Console.ReadLine();
			this.CheckBox1.Checked = true;
			}
			else
			{
			this.password = "";
			this.username = "";
			}
		}

		// Token: 0x0400012C RID: 300
		public string username;

		// Token: 0x0400012D RID: 301
		public string password;

		// Token: 0x0400012E RID: 302
        public string ZXCV;
	}
}

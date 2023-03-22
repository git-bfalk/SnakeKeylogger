using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Snake_Keylogger.snakesystem;

namespace Snake_Keylogger
{
	// Token: 0x0200001F RID: 31
	[DesignerGenerated]
	public partial class Registter : Form
	{
		// Token: 0x0600028F RID: 655 RVA: 0x00003497 File Offset: 0x00001697
		public Registter()
		{
			base.Load +=this.frmCVRegister_Load;
		this.InitializeComponent();
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0001D228 File Offset: 0x0001B428
		private void btnLogin_Click(object sender, EventArgs e)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			nameValueCollection["username"] =this.txtUsername.Text;
			nameValueCollection["password"] =this.txtPassword.Text;
			nameValueCollection["email"] =this.txtEmail.Text;
			nameValueCollection["license_code"] =this.txtCode.Text;
			nameValueCollection["fn"] = "register";
			nameValueCollection2 = CodeVest.cv.HTTP_request(nameValueCollection);
			MessageBox.Show(nameValueCollection2["msg"]);
			bool flag = Operators.CompareString(nameValueCollection2["error"], "1", false) != 0;
			if (flag)
			{
				base.Close();
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00003581 File Offset: 0x00001781
		private void btnExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00002331 File Offset: 0x00000531
		private void frmCVRegister_Load(object sender, EventArgs e)
		{
		}
	}
}

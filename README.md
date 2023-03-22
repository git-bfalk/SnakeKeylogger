# SnakeKeylogger
Snake Keylogger 1.0.1 - Full Source Code
<pre>

    $$$$$$\     $$$$$$$\                                          $$\                         
  $$$ ___$$$\   $$  __$$\                                         \__|                        
 $$ _/   \_$$\  $$ |  $$ |$$\   $$\ $$$$$$$\   $$$$$$$\  $$$$$$\  $$\ $$$$$$\$$$$\   $$$$$$\  
$$ / $$$$$\ $$\ $$$$$$$  |$$ |  $$ |$$  __$$\ $$  _____|$$  __$$\ $$ |$$  _$$  _$$\ $$  __$$\ 
$$ |$$  $$ |$$ |$$  __$$< $$ |  $$ |$$ |  $$ |$$ /      $$ |  \__|$$ |$$ / $$ / $$ |$$$$$$$$ |
$$ |$$ /$$ |$$ |$$ |  $$ |$$ |  $$ |$$ |  $$ |$$ |      $$ |      $$ |$$ | $$ | $$ |$$   ____|
$$ |\$$$$$$$$  |$$ |  $$ |\$$$$$$  |$$ |  $$ |\$$$$$$$\ $$ |      $$ |$$ | $$ | $$ |\$$$$$$$\ 
\$$\ \________/ \__|  \__| \______/ \__|  \__| \_______|\__|      \__|\__| \__| \__| \_______|
 \$$$\   $$$\                                                                                 
  \_$$$$$$  _|                                                                                
    \______/                                                                                  

        Analysis by: bfalk escobark
                For: [REDACTED]
                     21.03.23

Target Info
{
	|- Name			  : "Snake Keylogger.exe"
	|- Runtime		  : .NET/CIL (JIT)
	  |- Version	  : .NET Framework 4
	  |- Language	  : VB.NET
	  |- Architecture : AnyCPU (x64 preferred)
	  |- Timestamp	  : 5FB8E728 (11/21/2020 10:08:40 AM)
	
	|- Protectors:
	  |- KoiVM		 (2.0)
	  |- ILProtector (2.0.X.X)
	    |- Modules
	      |- x86: "Protectc86597cf.dll"
	      |- x64: "Protecta45d1cb7.dll"
}

Notes
{
	|- Cannot reach
	  |- '_PreferredMetadataEndPoint' ("https://codevest.to/codevest_api.php")
	  |- '_AlternateMetadataEndPoint' ("http://codevest.to/codevest_api2.php")
	(server might be/is down)
}

Private Key
{
	|- Name 	  : "_PrivateKey"
	|- Value	  : "vyyhqqns8xpmuubro33kymw3uf7cvjp7"
	|- Namespace  : "Snake_Keylogger.snakesystem"
	
	|- Type : AES
	|- Usage: Encrypts/Decrypts login data
	
	|- Used in/by:
	  |- DecryptStringAES()
	  |- EncryptStringAES()
	
	|- Related Variables:
	{
	  |- Name: "_PrivateKey_first"
	  |- Value: MD5 Hash of
		|- "o6806a42kbM7c5K%!>" + "_PrivateKey"
		|- "bb8f53f39f245c4618b95de8071797f7" (Result)
		
	  |- Name: "_PrivateKey_new"
	  |- Value:
		|- If logged in: Value of ["key"] in valid response login
		|- else 	   : Value of '_PrivateKey_first'
	}
}

Identifiable Information
{
	|- HWID: (via WMIClass/MBO)
	{
	  |- Variables:
	    |- "fingerPrintDebug": "M>" + baseId() + "D>>" + diskId()
	    |- "fingerPrint2"	 : MD5 Hash of 'fingerPrintDebug'
	    |- "_hardwareId"	 : Value    of 'fingerPrintDebug'
	
	  |- cpuId() : returns
	  	|- "Win32_Processor"
	  	  |- "UniqueId"
	  	  |- "ProcessorId"
	  	  |- "Name"
	  	  |- "Manufacturer"
	  	  |- "MaxClockSpeed"
	  	  
	  |- biosId() : returns
	  	|- "Win32_BIOS"
	  	  |- "Manufacturer"
	  	  |- "SMBIOSBIOSVersion"
	  	  |- "IdentificationCode"
	  	  |- "SerialNumber"
	  	  |- "ReleaseDate"
	  	  |- "Version"
	
	  |- diskId() : returns
	  	|- "Win32_DiskDrive"
	  	  |- "Model"
	  	  |- "Manufacturer"
	  	  |- "Signature"
	  	  |- "TotalHeads"
	  	  
	  |- baseId() : returns
	  	|- "Win32_BaseBoard"
	  	  |- "Model"
	  	  |- "Manufacturer"
	  	  |- "Name"
	  	  |- "SerialNumber"
	  	  
	  |- videoId() : returns
	  	|- "Win32_VideoController"
	  	  |- "DriverVersion"
	  	  |- "Name"
	  	  
	  |- macId() : returns
	    |- "Win32_NetworkAdapterConfiguration"
	      |- "MACAddress"
	}
}

Cryptography
{
	|- "Encrypt"
	  |- RID  : 653
	  |- RVA  : 0x0001C7B8
	  |- Token: 0x0600028D
	  
	  |- Usage: Read/Write data from "Snakelogin.ini" (login details)
	  
	  |- Type: Rijndael (CBC)
	  |- Key :
	  	{ 0x6E, 0xEF, 0x0F, 0x68, 0x36, 0x08, 0xF8, 0xD3,
	  	  0xE2, 0xB8, 0xFB, 0xC3, 0x6B, 0xAA, 0x56, 0x59,
	  	  0x4C, 0x27, 0x08, 0x90, 0x9A, 0xBE, 0xC5, 0x2C,
	  	  0xC9, 0xBE, 0x44, 0x75, 0x95, 0x6C, 0xBC, 0xAE }
	  |- IV  :
	    { 0x40, 0x31, 0x42, 0x32, 0x63, 0x33, 0x44, 0x34,
	      0x65, 0x35, 0x46, 0x36, 0x67, 0x37, 0x48, 0x38 }
}

Web Requests
{
	|- Variables
	  |- "_PreferredMetadataEndPoint": "https://codevest.to/codevest_api.php"
	  |- "_AlternateMetadataEndPoint": "http://codevest.to/codevest_api2.php" // unused
	  |- "_ProductId"				 : "000000465"
	  |- "_Version"					 : "0.2.1.1"
	  |- "_k"						 : Value of ["key_id"] in valid response login
	  
	|- "fn" Values
	  |- "register"     = Register
	    |- Username
	    |- Password
	    |- Email
	    |- License Code

	  |- "login"        = Login
	  	|- Requires
	      |- Username
	      |- Password
	
	  |- "blockLic"     = Block License
	    |- Requires
	      |- Username
	      |- Password
	      
	  |- "(g/s)etVar"   = Set Global Secure Variable
	    |- Requires
	      |- "varName"  = Name of variable
	      |- "varValue" = Value of variable
	  
	  |- "(g/s)etVar"   = Get/Set Secure Variable
	    |- Requires
		  |- "varName"  = Name of variable
		  |- "varValue" = Value of variable
		  |- Username
	      |- Password
	      
	   |- "get_key" 		= Get Cryptographic key
	      
	|- Login Process
	{
		|- Adds the following data to POST request
		|- "hid" 		   = 'fingerPrintDebug' (see line 75)
		  |- "hardware_id" = '_hardwareId'	    (see line 77)
		  |- "username"    = '_Username'		(empty if not logged in)
		  |- "password"	   = '_Password'		(empty if not logged in)
		  |- "fn"		   = "get_key"
		  
		|- if (_k == null)
		  |- Make POST request to
		    |- _PreferredMetadataEndPoint + "?p_id=" + _ProductId + "&v=" + _Version + "&get_key=1"
		    |- https://codevest.to/codevest_api.php?p_id=000000465&v=0.2.1.1&get_key=1
		|- else
		  |- Make POST request to
		    |- _PreferredMetadataEndPoint + "?p_id=" + _ProductId + "&v=" + _Version + "&k=" + _k + "&get_key=1"
		    |- https://codevest.to/codevest_api.php?p_id=000000465&v=0.2.1.1&k_%KEY%&get_key=1
		
		|- Decrypt body response of POST request using "_PrivateKey"
		  |- DecryptStringAES(response, "vyyhqqns8xpmuubro33kymw3uf7cvjp7")
		|- Save value as "appLic"
		
		|- if "appLic"
		  |- Length <= 5
		  |- Contains "ror=1"
		  |- Contains "ccess=1"
		  	|- if response["error"] == 0
		  	  |- '_PrivateKey_new' = response["key"]
		  	  |- '_k'			   = response["key_id"]
		  	|- else
		  	  |- Throw error of 'response["msg"]'
		|- else
		  |- Throw error of "Application license error"
	}
}
</pre>

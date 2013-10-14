//**************************************************************
// Copyright (c) Emmanuel KARTMANN 2002 (emmanuel@kartmann.org)
// $Revision: 7 $ $Date: 10/30/02 10:45a $
//**************************************************************

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Emmanuel.Cryptography.GnuPG; // My GnuPG wrapping class
using System.Configuration; // ConfigurationSettings class

namespace Emmanuel.Cryptography.GnuPG
{
	/// <summary>
	/// Test Page for <see cref="GnuPGWrapper">GnuPGWrapper</see> class.
	/// </summary>
	public class GnuPG : System.Web.UI.Page
	{
		/// <summary>
		/// Page Load callback function. Initialize text boxes (FromTextBox, ToTextBox) 
		/// with values from Web.Config file ("originator" => FromTextBox, "recipient" =>
		/// ToTextBox).
		/// </summary>
		/// <param name="sender">Object that raised the Load event</param>
		/// <param name="e">The EventArgs object that contains the event data</param>
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				FromTextBox.Text = ConfigurationSettings.AppSettings["originator"];
				ToTextBox.Text = ConfigurationSettings.AppSettings["recipient"];
			}
		}

		#region Web Form Designer generated code
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.CryptAndSignButton.Click += new System.EventHandler(this.CryptAndSignButton_Click);
			this.CryptButton.Click += new System.EventHandler(this.CryptButton_Click);
			this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
			this.SignButton.Click += new System.EventHandler(this.SignButton_Click);
			this.VerifyButton.Click += new System.EventHandler(this.VerifyButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// Callback function when a user clicks on CryptAndSignButton. Processes the input 
		/// text from MessageTextBox control via GnuPG and displays the output into 
		/// OutputTextBox control.
		/// 
		/// Please note that this function reads the following keys from Web.Config and 
		/// passes them to the GnuPGWrapper class: "homedirectory" and "passphrase".
		/// </summary>
		/// <param name="sender">Object that raised the Load event</param>
		/// <param name="e">The EventArgs object that contains the event data</param>
		private void CryptAndSignButton_Click(object sender, System.EventArgs e)
		{

			string inputText = MessageTextBox.Text;
			string outputText = "";

			try 
			{

				// Create GnuPG wrapping class
				GnuPGWrapper gpg = new GnuPGWrapper();

				// Set parameters from on Web.Config file
				gpg.homedirectory = Server.MapPath(ConfigurationSettings.AppSettings["homedirectory"]);
				gpg.passphrase = ConfigurationSettings.AppSettings["passphrase"];
				gpg.originator = FromTextBox.Text;
				gpg.recipient = ToTextBox.Text;
				gpg.command = Commands.SignAndEncrypt;

				// Execute GnuPG
				gpg.ExecuteCommand(inputText, out outputText);

				// Display output text
				OutputTextBox.Text = outputText;
				OutputTextBox.Visible = true;
				ErrorMessage.Visible = false;
				ExitCodeLabel.Text = gpg.exitcode.ToString();

			}
			catch (GnuPGException gpge)
			{
				// Display error message
				ErrorMessage.Text = gpge.Message;
				ErrorMessage.Visible = true;
				OutputTextBox.Visible = false;
			}

		}

		private void CryptButton_Click(object sender, System.EventArgs e)
		{
			string inputText = MessageTextBox.Text;
			string outputText = "";

			try 
			{

				// Create GnuPG wrapping class
				GnuPGWrapper gpg = new GnuPGWrapper();

				// Set parameters from on Web.Config file
				gpg.homedirectory = Server.MapPath(ConfigurationSettings.AppSettings["homedirectory"]);
				gpg.passphrase = ""; // no passphrase needed for encryption only
				gpg.originator = ""; // no originator needed for encryption only
				gpg.recipient = ToTextBox.Text;
				gpg.command = Commands.Encrypt;

				// Execute GnuPG
				gpg.ExecuteCommand(inputText, out outputText);

				// Display output text
				OutputTextBox.Text = outputText;
				OutputTextBox.Visible = true;
				ErrorMessage.Visible = false;
				ExitCodeLabel.Text = gpg.exitcode.ToString();

			}
			catch (GnuPGException gpge)
			{
				// Display error message
				ErrorMessage.Text = gpge.Message;
				ErrorMessage.Visible = true;
				OutputTextBox.Visible = false;
			}
		}

		private void SignButton_Click(object sender, System.EventArgs e)
		{
			string inputText = MessageTextBox.Text;
			string outputText = "";

			try 
			{

				// Create GnuPG wrapping class
				GnuPGWrapper gpg = new GnuPGWrapper();

				// Set parameters from on Web.Config file
				gpg.homedirectory = Server.MapPath(ConfigurationSettings.AppSettings["homedirectory"]);
				gpg.passphrase = ConfigurationSettings.AppSettings["passphrase"];
				gpg.originator = FromTextBox.Text;
				gpg.recipient = ""; // no recipient needed for sign only
				gpg.command = Commands.Sign;

				// Execute GnuPG
				gpg.ExecuteCommand(inputText, out outputText);

				// Display output text
				OutputTextBox.Text = outputText;
				OutputTextBox.Visible = true;
				ErrorMessage.Visible = false;
				ExitCodeLabel.Text = gpg.exitcode.ToString();

			}
			catch (GnuPGException gpge)
			{
				// Display error message
				ErrorMessage.Text = gpge.Message;
				ErrorMessage.Visible = true;
				OutputTextBox.Visible = false;
			}
		}

		private void VerifyButton_Click(object sender, System.EventArgs e)
		{
			string inputText = MessageTextBox.Text;
			string outputText = "";

			try 
			{

				// Create GnuPG wrapping class
				GnuPGWrapper gpg = new GnuPGWrapper();

				// Set parameters from on Web.Config file
				gpg.homedirectory = Server.MapPath(ConfigurationSettings.AppSettings["homedirectory"]);
				gpg.passphrase = ConfigurationSettings.AppSettings["passphrase"];
				gpg.originator = FromTextBox.Text;
				gpg.recipient = ""; // no recipient needed for verify only
				gpg.command = Commands.Verify;

				// Execute GnuPG
				gpg.ExecuteCommand(inputText, out outputText);

				// Display output text
				OutputTextBox.Text = outputText;
				OutputTextBox.Visible = true;
				ErrorMessage.Visible = false;
				ExitCodeLabel.Text = gpg.exitcode.ToString();

			}
			catch (GnuPGException gpge)
			{
				// Display error message
				ErrorMessage.Text = gpge.Message;
				ErrorMessage.Visible = true;
				OutputTextBox.Visible = false;
			}
		}

		private void DecryptButton_Click(object sender, System.EventArgs e)
		{
			string inputText = MessageTextBox.Text;
			string outputText = "";

			try 
			{

				// Create GnuPG wrapping class
				GnuPGWrapper gpg = new GnuPGWrapper();

				// Set parameters from on Web.Config file
				gpg.homedirectory = Server.MapPath(ConfigurationSettings.AppSettings["homedirectory"]);
				gpg.passphrase = ConfigurationSettings.AppSettings["passphrase"];
				gpg.originator = ""; // no originator needed for decryption only
				gpg.recipient = ""; // no recipient needed for decryption only
				gpg.command = Commands.Decrypt;

				// Execute GnuPG
				gpg.ExecuteCommand(inputText, out outputText);

				// Display output text
				OutputTextBox.Text = outputText;
				OutputTextBox.Visible = true;
				ErrorMessage.Visible = false;
				ExitCodeLabel.Text = gpg.exitcode.ToString();

			}
			catch (GnuPGException gpge)
			{
				// Display error message
				ErrorMessage.Text = gpge.Message;
				ErrorMessage.Visible = true;
				OutputTextBox.Visible = false;
			}		
		}

		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.Label ErrorMessage;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.TextBox FromTextBox;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.TextBox ToTextBox;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.TextBox MessageTextBox;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.TextBox OutputTextBox;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.Button CryptAndSignButton;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.Button CryptButton;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.Button SignButton;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.Button VerifyButton;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.Button DecryptButton;
		/// <summary>
		/// 
		/// </summary>
		protected System.Web.UI.WebControls.Label ExitCodeLabel;

	}
}

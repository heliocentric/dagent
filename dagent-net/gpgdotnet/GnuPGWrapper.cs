//**************************************************************
// Copyright (c) Emmanuel KARTMANN 2002 (emmanuel@kartmann.org)
// $Revision: 15 $ $Date: 10/30/02 10:45a $
//**************************************************************

using System;
using System.Text; // for StringBuilder class
using System.Diagnostics; // for Process class
using System.IO; // for StreamWriter/StreamReader classes
using System.Threading; // for Thread class

namespace Emmanuel.Cryptography.GnuPG
{

	/// <summary>
	/// Specific exception thrown whenever a PGP error occurs.
	/// 
	/// <p/>This class is a simple derivation from the Exception class.
	/// </summary>
	public class GnuPGException: Exception
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="message">error message associated with exception</param>
		public GnuPGException(string message): base(message)
		{
		}
	}

	/// <summary>
	/// List (enum) of available commands (sign, encrypt, sign and encrypt, etc...)
	/// </summary>
	public enum Commands 
	{ 
		/// <summary>
		/// Make a signature
		/// </summary>
		Sign,
		/// <summary>
		/// Encrypt  data
		/// </summary>
		Encrypt, 
		/// <summary>
		/// Sign and encrypt data
		/// </summary>
		SignAndEncrypt, 
		/// <summary>
		/// Decrypt data
		/// </summary>
		Decrypt, 
		/// <summary>
		/// Assume that input is a signature and verify it without generating any output
		/// </summary>
		Verify,
		/// <summary>
		/// Generate a KeyPair
		/// </summary>
        KeyGen,
        /// <summary>
        /// Find a key.
        /// </summary>
        FindKey,
        /// <summary>
        /// Import a public key
        /// </summary>
        Import,
		/// <summary>
		/// Export a public key
		/// </summary>
		Export
	};
	// TODO implement other GPG commands (--clearsign, --detach-sign, --symmetric, --store, --verify-files, --encrypt-files, --decrypt-files, --list-keys, --list-public-keys, --list-secret-keys, --list-sigs, --check-sigs, --fingerprint, --check-sigs, --list-packets, --gen-key, --edit-key, --sign-key, --lsign-key, --nrsign-key, --delete-key, --delete-secret-key, --delete-secret-and-public-key, --gen-revoke, --desig-revoke, --export, --send-keys, --export-all, --export-secret-keys, --export-secret-subkeys, --import, --fast-import, --recv-keys, --search-keys, --update-trustdb, --check-trustdb, --export-ownertrust, --import-ownertrust, --rebuild-keydb-caches, --print-md, --print-mds, --gen-random, --gen-prime mode, --version, --warranty, --help)

	/// <summary>
	/// List (enum) of available verbose levels (NoVerbose, Verbose, VeryVerbose)
	/// </summary>
	public enum VerboseLevel { 
		/// <summary>
		/// Reset verbose level to 0 (no information shown during processing)
		/// </summary>
		NoVerbose, 
		/// <summary>
		/// Give more information during processing.
		/// </summary>
		Verbose, 
		/// <summary>
		/// Give full information during processing (the input data is listed in detail).
		/// </summary>
		VeryVerbose 
	};

	/// <summary>
	/// This class is a wrapper class for GNU Privacy Guard (GnuPG). It execute the command 
	/// line program (gpg.exe) in an different process, redirects standard input (stdin),
	/// standard output (stdout) and standard error (stderr) streams, and monitors the 
	/// streams to fetch the results of the encryption/signing operation.<p/>
	/// 
	/// Please note that you must have INSTALLED GnuPG AND generated/imported the 
	/// appropriate keys before using this class.<p/>
	/// 
	/// GnuPG stands for GNU Privacy Guard and is GNU's tool for secure communication and 
	/// data storage. It can be used to encrypt data and to create digital signatures. It 
	/// includes an advanced key management facility and is compliant with the proposed 
	/// OpenPGP Internet standard as described in RFC 2440. As such, GnuPG is a complete 
	/// and free replacement for PGP.<p/>
	/// 
	/// This class has been developed and tested with GnuPG v1.2.0 (MingW32)<p/>
	/// 
	/// For more about GNU, please refer to http://www.gnu.org <br/>
	/// For more about GnuPG, please refer to http://www.gnupg.org <br/>
	/// For more about OpenPGP (RFC 2440), please refer to http://www.gnupg.org/rfc2440.html <br/>
	/// </summary>
	public class GnuPGWrapper
	{

		/// <summary>
		/// Default constructor
		/// </summary>
		public GnuPGWrapper()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="homeDirectory">home directory for GnuPG (where keyrings AND gpg.exe are located)</param>
		public GnuPGWrapper(string homeDirectory)
		{
			homedirectory = homeDirectory;
		}

		/// <summary>
		/// Command property: set the type of command to execute (sign, encrypt...)
		/// 
		/// <p/>Defaults to SignAndEncrypt.
		/// </summary>
		public Commands command
		{
			set 
			{
				_command = value;
			}
		}

		/// <summary>
		/// Boolean flag: if true, GnuPG creates ASCII armored output (text output). 
		/// 
		/// <p/>Defaults to true (ASCII ouput).
		/// </summary>
		public bool armor
		{
			set
			{
				_armor = value;
			}
		}

		/// <summary>
		/// Recipient email address - mandatory when <see cref="command">command</see> is Encrypt or SignAndEncrypt
		/// 
		/// <p/>GnuPG uses this parameter to find the associated public key. You must have imported 
		/// this public key in your keyring before.
		/// </summary>
		public string recipient
		{
			set
			{
				_recipient = value;
			}
		}
        /// <summary>
        /// Command line arguments that may need to be set.
        /// </summary>
        public string arguments
        {
            set
            {
                _arguments = value;
            }
        }
        /// <summary>
        /// Add a binary path, as we use a seperate binary path from our keyring.
        /// </summary>
        public string bindirectory
        {
            get
            {
                if (this._bindirectory == "")
                {
                    return this._homedirectory;
                } else {
                    return this._bindirectory;
                }
            }
            set
            {
				_bindirectory = value;
            }
        }
		/// <summary>
		/// Originator email address - recommended when <see cref="command">command</see> is Sign or SignAndEncrypt
		/// 
		/// <p/>GnuPG uses this parameter to find the associated secret key. You must have imported 
		/// this secret key in your keyring before. Otherwise, GnuPG uses the first secret key 
		/// in your keyring to sign messages. This property is mapped to the "--default-key" option.
		/// </summary>
		public string originator
		{
			set
			{
				_originator = value;
			}
		}

		/// <summary>
		/// Boolean flag; if true, GnuPG assumes "yes" on most questions.
		/// 
		/// <p/>Defaults to true.
		/// </summary>
		public bool yes
		{
			set
			{
				_yes = value;
			}
		}

		/// <summary>
		/// Boolean flag; if true, GnuPG uses batch mode (Never ask, do not allow 
		/// interactive commands).
		/// 
		/// <p/>Defaults to true.
		/// </summary>
		public bool batch
		{
			set
			{
				_batch = value;
			}
		}


		/// <summary>
		/// Passphrase for using your private key - mandatory when 
		/// <see cref="command">command</see> is Sign or SignAndEncrypt.
		/// </summary>
		public string passphrase
		{
			set
			{
				_passphrase = value;
				if (_passphrase != "")
				{
					_passphrasefd = "0"; // stdin
				} 
				else 
				{
					_passphrasefd = "";
				}
			}
		}

		/// <summary>
		/// name of the home directory (where keyrings AND gpg.exe are located)
		/// </summary>
		public string homedirectory
		{
			set
			{
				_homedirectory = value;
			}
		}

		/// <summary>
		/// File descriptor for entering passphrase - defaults to 0 (standard input).
		/// </summary>
		public string passphrasefd
		{
			set
			{
				_passphrasefd = value;
			}
		}

		/// <summary>
		/// Exit code from GnuPG process (0 = success; otherwise an error occured)
		/// </summary>
		public int exitcode
		{
			get
			{
				return(_exitcode);
			}
		}

		/// <summary>
		/// Verbose level (NoVerbose, Verbose, VeryVerbose). 
		/// 
		/// <p/>Defaults to NoVerbose.
		/// </summary>
		public VerboseLevel verbose
		{
			get
			{
				return(_verbose);
			}
			set
			{
				_verbose = value;
			}
		}

		/// <summary>
		/// Timeout for GnuPG process, in milliseconds.
		/// 
		/// <p/>If the process doesn't exit before the end of the timeout period, the process is terminated (killed).
		/// 
		/// <p/>Defaults to 10000 (10 seconds).
		/// </summary>
		public int ProcessTimeOutMilliseconds
		{
			get
			{
				return(_ProcessTimeOutMilliseconds);
			}
			set
			{
				_ProcessTimeOutMilliseconds = value;
			}
		}

		/// <summary>
		/// Generate a string of GnuPG command line arguments, based on the properties
		/// set in this object (e.g. if the <see cref="armor">armor</see> property is true, 
		/// this method generates the "--armor" argument).
		/// </summary>
		/// <returns>GnuPG command line arguments</returns>
		protected string BuildOptions()
		{
			StringBuilder optionsBuilder = new StringBuilder("", 255);
			bool recipientNeeded = false;
			bool passphraseNeeded = false;

			// Home Directory?
			if (_homedirectory != null && _homedirectory != "")
			{
				// WARNING: directory path is between quotes
				// TODO replace directory path with quotes by short path (with "~" for long names) - call GetShortPathName?
				optionsBuilder.Append("--homedir \"");
				optionsBuilder.Append(_homedirectory);
				optionsBuilder.Append("\" ");
			}

			// Answer yes to all questions?
			if (_yes)
			{
				optionsBuilder.Append("--yes ");
			}

			// batch mode?
			if (_batch)
			{
				optionsBuilder.Append("--batch ");
			}

			// Command
			switch (_command)
			{
				case Commands.Sign:
					optionsBuilder.Append("--sign ");
					passphraseNeeded = true;
					break;
				case Commands.Encrypt:
					optionsBuilder.Append("--encrypt ");
					recipientNeeded = true;
					break;
				case Commands.SignAndEncrypt:
					optionsBuilder.Append("--sign ");
					optionsBuilder.Append("--encrypt ");
					recipientNeeded = true;
					passphraseNeeded = true;
					break;
				case Commands.Decrypt:
					optionsBuilder.Append("--decrypt ");
					break;
				case Commands.Verify:
					optionsBuilder.Append("--verify ");
					break;
                case Commands.KeyGen:
                    optionsBuilder.Append("--gen-key ");
                    break;
                case Commands.FindKey:
                    optionsBuilder.Append("--list-keys ");
                    break;
			}

			// ASCII output?
			if (_armor)
			{
				optionsBuilder.Append("--armor ");
			}

			// Recipient?
			if (_recipient != null && _recipient != "")
			{
				optionsBuilder.Append("--recipient ");
				optionsBuilder.Append(_recipient);
				optionsBuilder.Append(" ");
			}
			else
			{
				// If you encrypt, you NEED a recipient!
				if (recipientNeeded)
				{
					throw new GnuPGException("GPGNET: Missing 'recipient' parameter: cannot encrypt without a recipient");
				}
			}

			// Originator?
			if (_originator != null && _originator != "")
			{
				optionsBuilder.Append("--default-key ");
				optionsBuilder.Append(_originator);
				optionsBuilder.Append(" ");
			}

			// Passphrase?
			if (_passphrase == null || _passphrase == "")
			{
				if (passphraseNeeded)
				{
					throw new GnuPGException("GPGNET: Missing 'passphrase' parameter: cannot sign without a passphrase");
				}
			}

			// Passphrase file descriptor?
			if (_passphrasefd != null && _passphrasefd != "")
			{
				optionsBuilder.Append("--passphrase-fd ");
				optionsBuilder.Append(_passphrasefd);
				optionsBuilder.Append(" ");
			}
			else
			{
				if (passphraseNeeded && (_passphrase == null || _passphrase == ""))
				{
					throw new GnuPGException("GPGNET: Missing 'passphrase' parameter: cannot sign without a passphrase");
				}
			}

			// Command
			switch (verbose)
			{
				case VerboseLevel.NoVerbose:
					optionsBuilder.Append("--no-verbose ");
					break;
				case VerboseLevel.Verbose:
					optionsBuilder.Append("--verbose ");
					break;
				case VerboseLevel.VeryVerbose:
					optionsBuilder.Append("--verbose --verbose ");
					break;
			}

            if (!this._arguments.Equals(""))
            {
                optionsBuilder.Append(this._arguments + " ");
            }
			return(optionsBuilder.ToString());
		}

		/// <summary>
		/// Execute the GnuPG command defined by all parameters/options/properties.
		/// 
		/// <p/>Raise a GnuPGException whenever an error occurs.
		/// </summary>
		/// <param name="inputText"></param>
		/// <param name="outputText"></param>
		public void ExecuteCommand(string inputText, out string outputText)
		{
			outputText = "";
			string gpgOptions = BuildOptions();
			string gpgExecutable = _bindirectory + "\\gpg2.exe";

			// TODO check existence of _bindirectory and gpgExecutable

			// Create startinfo object
			ProcessStartInfo pInfo = new ProcessStartInfo(gpgExecutable, gpgOptions);
			pInfo.WorkingDirectory = _bindirectory;
			pInfo.CreateNoWindow = true;
			pInfo.UseShellExecute = false;
			// Redirect everything: 
			// stdin to send the passphrase, stdout to get encrypted message, stderr in case of errors...
			pInfo.RedirectStandardInput = true;
			pInfo.RedirectStandardOutput = true;
			pInfo.RedirectStandardError = true;
			_processObject = Process.Start(pInfo);

			// Send pass phrase, if any
			if (_passphrase != null && _passphrase != "")
			{
				_processObject.StandardInput.WriteLine(_passphrase);
				_processObject.StandardInput.Flush();
			}

			// Send input text
			_processObject.StandardInput.Write(inputText);
			_processObject.StandardInput.Flush();
			_processObject.StandardInput.Close();

			_outputString = "";
			_errorString = "";

			// Create two threads to read both output/error streams without creating a deadlock
			ThreadStart outputEntry = new ThreadStart(StandardOutputReader);
			Thread outputThread = new Thread(outputEntry);
			outputThread.Start();
			ThreadStart errorEntry = new ThreadStart(StandardErrorReader);
			Thread errorThread = new Thread(errorEntry);
			errorThread.Start();

			if (_processObject.WaitForExit(ProcessTimeOutMilliseconds))
			{
				// Process exited before timeout...
				// Wait for the threads to complete reading output/error (but use a timeout!)
				if (!outputThread.Join(ProcessTimeOutMilliseconds/2))
				{
					outputThread.Abort();
				}
				if (!errorThread.Join(ProcessTimeOutMilliseconds/2))
				{
					errorThread.Abort();
				}
			}
			else
			{
				// Process timeout: PGP hung somewhere... kill it (as well as the threads!)
				_outputString = "";
				_errorString = "Timed out after " + ProcessTimeOutMilliseconds.ToString() + " milliseconds";
				_processObject.Kill();
				if (outputThread.IsAlive)
				{
					outputThread.Abort();
				}
				if (errorThread.IsAlive)
				{
					errorThread.Abort();
				}
			}

			// Check results and prepare output
			_exitcode = _processObject.ExitCode;
			if (_exitcode == 0)
			{
				outputText = _outputString;
			}
			else
			{
				if (_errorString == "")
				{
					_errorString = "GPGNET: [" + _processObject.ExitCode.ToString() + "]: Unknown error";
				}
				 throw new GnuPGException(_errorString);
			}
		}

		/// <summary>
		/// Reader thread for standard output
		/// 
		/// <p/>Updates the private variable _outputString (locks it first)
		/// </summary>
		public void StandardOutputReader()
		{
			string output = _processObject.StandardOutput.ReadToEnd();
			lock(this)
			{
				_outputString = output;
			}
		}

		/// <summary>
		/// Reader thread for standard error
		/// 
		/// <p/>Updates the private variable _errorString (locks it first)
		/// </summary>
		public void StandardErrorReader()
		{
			string error = _processObject.StandardError.ReadToEnd();
			lock(this)
			{
				_errorString = error;
			}
		}

		// Variables used to store property values (prefix: underscore "_")
		private Commands _command = Commands.SignAndEncrypt;
		private bool _armor = true;
		private bool _yes = true;
		private string _recipient = "";
		private string _homedirectory = "";
		private string _bindirectory = "";
		private string _passphrase = "";
		private string _passphrasefd = "";
		private VerboseLevel _verbose = VerboseLevel.NoVerbose;
		private bool _batch = true;
		private string _originator = "";
		private int _ProcessTimeOutMilliseconds = 10000; // 10 seconds
		private int _exitcode = 0;
        private string _arguments = "";
		// Variables used for monitoring external process and threads
		private Process _processObject;
		private string _outputString;
		private string _errorString;

	}

}

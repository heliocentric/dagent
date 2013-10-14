<%@ Page language="c#" Codebehind="GnuPG.aspx.cs" AutoEventWireup="false" Inherits="Emmanuel.Cryptography.GnuPG.GnuPG" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
	<head>
		<title>GnuPG</title>
		<meta content="Microsoft Visual Studio 7.0" name=GENERATOR>
		<meta content=C# name=CODE_LANGUAGE>
		<meta content=JavaScript name=vs_defaultClientScript>
		<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
	</head>
	<body>
		<form id=GnuPG method=post runat="server">
			<h2>GnuPGWrapper</h2>
			<p>This page is sample use of GnuPGWrapper, a wrapper class
				for GNU Privacy Guard (GnuPG). It executes the command line program (<code>gpg.exe</code>)
				in
				an different process, redirects standard input (<code>stdin</code>), standard
				output (<code>stdout</code>)
				and standard error (<code>stderr</code>) streams, and monitors the streams to
				fetch the
				results of the encryption/signing operation. </p>
			<p>Please note that you must have INSTALLED GnuPG AND
				generated/imported the appropriate keys before using this class. </p>
			<h2>PGP Form</h2>
			<p>Please fill in the form below a press one of the action buttons to test the 
				GnuPGWrapper.</p>
			<table border=0>
				<tr valign=top>
					<td><asp:label id=Label1 runat="server" font-bold="True">Input Message: </asp:label></td>
					<td><asp:textbox id=MessageTextBox runat="server" textmode="MultiLine" columns="80" rows="5">This is a test message.</asp:textbox></td></tr>
				<tr>
					<td><asp:label id=Label2 runat="server" font-bold="True">From:</asp:label></td>
					<td><asp:textbox id=FromTextBox runat="server" width="243px"></asp:textbox></td></tr>
				<tr>
					<td><asp:label id=Label3 runat="server" font-bold="True">To:</asp:label></td>
					<td><asp:textbox id=ToTextBox runat="server" width="244px"></asp:textbox></td></tr>
				<tr><td colspan=2>&nbsp;</td></tr>
				<tr>
					<td colspan=2>
						<table>
							<tr>
								<td><asp:button id=CryptAndSignButton runat="server" text="Encrypt and Sign"></asp:button></td>
								<td><asp:button id="CryptButton" runat="server" text="Encrypt"></asp:button></td>
								<td><asp:button id="DecryptButton" runat="server" text="Decrypt"></asp:button></td>
								<td><asp:button id="SignButton" runat="server" text="Sign"></asp:button></td>
								<td><asp:button id="VerifyButton" runat="server" text="Verify"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan=2><asp:label id=ErrorMessage runat="server" visible="False" forecolor="Red">ERROR!</asp:label></td></tr>
				<tr><td colspan=2>&nbsp;</td></tr>
				<tr>
					<td><asp:label id=Label4 runat="server" font-bold="True">Output Message: </asp:label></td>
					<td><asp:textbox id=OutputTextBox runat="server" visible="False" textmode="MultiLine" columns="80" rows="10"></asp:textbox></td>
				</tr>
				<tr>
					<td><asp:label id="Label5" runat="server" font-bold="True">Exit Code: </asp:label></td>
					<td><asp:label id="ExitCodeLabel" runat="server"></asp:label></td>
				</tr>
			</table>


			<h2>Low-Level Design</h2>

			<p>For more details about the implementation, please refer to the <a href="CodeCommentReport/GnuPGDotNet/GnuPGDotNet.HTM">
					GnuPG .NET Low Level Design</a>.</p>


			<h2>About GnuPG</h2>
			<p>GnuPG stands for GNU Privacy Guard and is GNU's tool for
				secure communication and data storage. It can be used to encrypt data and to
				create digital signatures. It includes an advanced key management facility and
				is compliant with the proposed OpenPGP Internet standard as described in RFC
				2440. As such, GnuPG is a complete and free replacement for PGP. </p>
			<p>This class has been developed and tested with GnuPG
				v1.2.0 (MingW32) </p>
			<p>You can check the <a href="gpg.txt" target="_blank">command line manual page for 
					gpg.exe</a></p>
			<p>
				For more about GNU, please refer to <a href="http://www.gnu.org" target="_blank">http://www.gnu.org</a><br>
				For more about GnuPG, please refer to <a href="http://www.gnupg.org" target="_blank">
					http://www.gnupg.org</a><br>
				For more about OpenPGP (RFC 2440), please refer to <a href="http://www.gnupg.org/rfc2440.html" target="_blank">
					http://www.gnupg.org/rfc2440.html</a><br></p>
		</form>
	</body>
</html>

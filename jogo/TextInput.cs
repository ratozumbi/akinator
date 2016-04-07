/*
 * Created by SharpDevelop.
 * User: Phantom
 * Date: 06/04/2016
 * Time: 21:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Net.Mime;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace jogo
{
	/// <summary>
	/// Description of TextInput.
	/// </summary>
	public partial class TheWindow : Form
	{
		private String _inputRead;
		private bool _okPressed = false;
		
		public String InputRead
		{
			get{return _inputRead;}
		}
		public bool OkPressed
		{
			get{return _okPressed;}
		}
		
		public TheWindow(String theMessage)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			lblMessage.Text = theMessage;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void BtnOkClick(object sender, EventArgs e)
		{
			_inputRead = textBox.Text;
			_okPressed = true;
			this.Hide();
		}
	}
}

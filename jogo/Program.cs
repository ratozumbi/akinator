
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace jogo
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>


		public static Node mainNode;
		public static Node currNode;
		
		[STAThread]
		private static void Main(string[] args)
		{
			DialogResult resultVerbo;
			DialogResult resultNome;
			
			mainNode = new Node("cat","have 9 lifes");
			
			MessageBox.Show("Think about an animal", "Guessing game");
			currNode = mainNode;
			while(true){
				resultVerbo = MessageBox.Show("Does your animal " + currNode.getVerbo() +"?", "Guessing game", MessageBoxButtons.YesNo);
				switch(resultVerbo){
					case DialogResult.Yes:
						{
							resultNome = MessageBox.Show("Is your animal a " + currNode.getNome() +"?", "Guessing game", MessageBoxButtons.YesNo);
							if(DialogResult.Yes == resultNome){
								DialogResult res = MessageBox.Show("I win!", "Guessing game",  MessageBoxButtons.RetryCancel);
								if(res == DialogResult.Retry) currNode = mainNode;
								else goto fim;
							}else
							{
								if (currNode.yes != null){
									currNode = currNode.yes;
								}
								else{
									EndPlayYes();
								}
							}
						}
						break;
					case DialogResult.No:
						if (currNode.no != null){
							currNode = currNode.no;
						}
						else{
							EndPlayNo();
						}
						break;
				}
			}
		fim:
			return;
		}
		
		private static void EndPlayNo(){
			
			String getVerbo= "";
			String getNome = "";
			
			InputBox("What was the animal you were thinking of?", ref getNome);
			InputBox("A " + getNome + " can ________ but a " + currNode.getNome() + " can not." , ref getVerbo);
			
			currNode.no = new Node(getNome,getVerbo);
			currNode = mainNode;
			
		}
		
		private static void EndPlayYes(){
			
			String getVerbo= "";
			String getNome = "";
			
			InputBox("What was the animal you were thinking of?", ref getNome);
			InputBox("A " + getNome + " can ________ but a " + currNode.getNome() + " can not." , ref getVerbo);
			
			currNode.yes = new Node(getNome,getVerbo);
			currNode = mainNode;
		}
		
		
		public static DialogResult InputBox(string promptText, ref string value)
		{
			Form form = new Form();
			Label label = new Label();
			TextBox textBox = new TextBox();
			Button buttonOk = new Button();

			form.Text = "Guessing game";
			label.Text = promptText;
			textBox.Text = value;

			buttonOk.Text = "OK";
			buttonOk.DialogResult = DialogResult.OK;

			label.SetBounds(9, 18, 372, 13);
			textBox.SetBounds(12, 36, 372, 20);
			buttonOk.SetBounds(228, 72, 75, 23);

			label.AutoSize = true;
			textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
			buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			
			form.ClientSize = new Size(396, 107);
			form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
			form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
			form.FormBorderStyle = FormBorderStyle.FixedDialog;
			form.StartPosition = FormStartPosition.CenterScreen;
			form.MinimizeBox = false;
			form.MaximizeBox = false;
			form.AcceptButton = buttonOk;

			DialogResult dialogResult = form.ShowDialog();
			value = textBox.Text;
			return dialogResult;
		}

		
	}
}

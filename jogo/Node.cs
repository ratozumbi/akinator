/*
 * Created by SharpDevelop.
 * User: Phantom
 * Date: 05/04/2016
 * Time: 23:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace jogo
{
	/// <summary>
	/// Description of node.
	/// </summary>
	public class Node
	{
		
		public Node yes;
		public Node no;
		
		String nome;
		String verbo;
		
		public Node(String nome, String verbo)
		{
			this.nome = nome;
			this.verbo = verbo;
		}

		public string getVerbo()
		{
			return verbo;
		}
		public string getNome()
		{
			return nome;
		}
		
	}
}

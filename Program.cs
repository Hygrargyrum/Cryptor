using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Coder
{
	public class Program
	{
		public string input;
		public string file_name;
		public string[] text;
		public byte[] byte_text;
		public int salt;
		
		public void Main()
		{
		   Menu();
		}
		
		public void Menu()
		{
			Console.Write("Название файла: ");
			input = Console.ReadLine();
			file_name = $@"{input}.txt";
			Console.Write("Введите ключ: ");
			input = Console.ReadLine();
			salt = Convert.ToInt32(input);
			Code();
		}
		
		public void Code()
		{
			text = File.ReadAllLines(file_name);
			string mono_text = null;
			for(int i = 0; i < text.Length; i++)
			{
				mono_text += text[i] + ";";
			}
			byte_text = Encoding.UTF8.GetBytes(mono_text);
			for(int i = 0; i < byte_text.Length; i++)
			{
				//byte error = (byte)(salt ^ 59);
				if(byte_text[i] != 59 && (byte)(byte_text[i] ^ salt) != 59)
				{
				byte_text[i] = (byte)(byte_text[i] ^ salt);
				}
			}
			mono_text = Encoding.UTF8.GetString(byte_text);
			text = mono_text.Split(';');
			File.WriteAllLines($@"{file_name}", text);
			Console.WriteLine($"Файл {file_name} успешно конвертирован.");
		}
		
		
	}
}

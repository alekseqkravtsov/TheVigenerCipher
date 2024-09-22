using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InfoDefendLab2
{
    internal class ReplaceMethod
    {
        private char[] alphabet = new char[73]
        {
            'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З',
            'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р',
            'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ',
            'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', 'а', 'б', 'в',
            'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к',
            'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у',
            'ф', 'х', 'ч', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы',
            'ь', 'э', 'ю', 'я', ' ', '.', ':', '!', '?',
            ','
        };

        public void startProgram()
        {
            printArray();

            string message;
            string encryptMessage;
            string decryptMessage;
            string key1, key2;

            while (true)
            {
                Console.Write("\nВведите сообщение: ");
                message = Console.ReadLine();
                Console.Write("Введите ключ для шифрования: ");
                key1 = Console.ReadLine();

                encryptMessage = Encrypt(message, key1);

                if (encryptMessage != "")
                {
                    Console.Write("Зашифрованное сообщение: " + encryptMessage + "\n");

                    Console.Write("Введите ключ для расшифрования: ");
                    key2 = Console.ReadLine();

                    decryptMessage = Decrypt(encryptMessage, key2);
                    Console.Write("Расшифрованное сообщение: " + decryptMessage + "\n");
                    if (key1 != key2)
                        Console.Write("Ключ не подошел, неудача дешифрования.\n");
                }
                else
                    Console.WriteLine("Сообщение или ключ содержит недопустимый символ для заданного алфавита.");
                
            }
        }

        public void printArray()
        {
            Console.WriteLine("Алфавит символов:");

            int i;
            for (i = 0; i < alphabet.Length; i++)
            {
                Console.Write(alphabet[i] + " ");
                if((i+1) % 8 == 0)
                    Console.WriteLine("");
            }
        }

        private int GetIndex(char character)
        {
            int index = -1;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == character)
                {
                    index = i; break;
                }
            }

            return index;
        }

        private int GetChangedIndex(char messageElement, char keyElement, bool encrypt = true)
        {
            int newIndex = -1;

            if (GetIndex(messageElement) != -1 && GetIndex(keyElement) != -1 && encrypt)
            {
                newIndex = (GetIndex(messageElement) + GetIndex(keyElement)) % alphabet.Count();
            }
            else if (GetIndex(messageElement) != -1 && GetIndex(keyElement) != -1 && !encrypt)
            {
                newIndex = (GetIndex(messageElement) + alphabet.Count() - GetIndex(keyElement)) % alphabet.Count();
            }
           
            return newIndex;
        }

        public string Encrypt(string message, string key)
        {
            string lockedMessage = "";
            char[] characters = message.ToCharArray();
            char[] keyBytes = key.ToCharArray();

            int i = 0, j = i, newIndex;
            for (i = 0; i < characters.Length; i++, j++)
            {
                if (j == keyBytes.Length)
                    j = 0;

                newIndex       = GetChangedIndex(characters[i], keyBytes[j]);
                if (newIndex == -1)
                {
                    lockedMessage = "";
                    return lockedMessage;
                }
                    
                lockedMessage += alphabet[newIndex];
            }

            return lockedMessage;
        }

        public string Decrypt(string lockedMessage, string key)
        {
            string message = "";
            char[] characters = lockedMessage.ToCharArray();
            char[] keyBytes = key.ToCharArray();

            int i = 0, j = i, newIndex;
            for (i = 0; i < characters.Length; i++, j++)
            {
                if (j == keyBytes.Length)
                    j = 0;

                newIndex = GetChangedIndex(characters[i], keyBytes[j], false);
                message += alphabet[newIndex];
            }

            return message;
        }

        static void Main(string[] args)
        {
            ReplaceMethod cryptography = new ReplaceMethod();
            cryptography.startProgram();
        }
    }
}

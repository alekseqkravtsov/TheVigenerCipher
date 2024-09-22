# Учебный проект: шифр Виженера
> ### Программная реализация шифрования/дешифрования представлена в файле ["ReplaceMethod.cs"](https://github.com/alekseqkravtsov/TheVigenerCipher/blob/main/InfoDefendLab2/ReplaceMethod.cs)
**Лабораторная работа по дисциплине "Защита информации".**  
Шифр Виженера - метод полиалфавитного шифрования буквенного текста с использованием ключевого слова.
Шифрование методом замены (подстановки) основано на алгебраической операции, называемой подстановкой.
Подстановкой называется взаимно однозначное отображение некоторого конечного множества М на себя.
Число N элементов этого множества называется степенью подстановки. Природа множества М роли не играет,
поэтому можно считать, что М={1,2,...,N}.

**Общая формула моноалфавитной замены выглядит следующим образом:**
![alt text](https://github.com/alekseqkravtsov/TheVigenerCipher/blob/main/images/KkseihP5arI.jpg)  
где Yi – i-й символ алфавита; k1 и k2 – константы, Xi – i-й символ открытого текста (номер буквы в алфавите);
n - длина используемого алфавита.

**Шифр, задаваемый формулой:**  
![alt text](https://github.com/alekseqkravtsov/TheVigenerCipher/blob/main/images/AodZ5B1WQK0.jpg)  
где ki – i-я буква ключа, в качестве которого используются слово или фраза, называется шифром Виженера.

**Задание:**
1. Заполнить алфавит в массив, в котором должны храниться все буквы
русского алфавита от а до я и от А до Я плюс символы: пробел, точка,
двоеточие, восклицательный знак, вопросительный знак и запятая (всего 72
символа).
2. Зашифровать любую фразу с любым ключом (фраза и ключ вводятся с
клавиатуры) методом замены.
3. Расшифровать полученный шифротекст, используя тот же ключ.

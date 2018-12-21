// Шифрующие таблицы с двойной перестановкой по ключу 
#include <string>
#include <iostream>

int main() {
	system("chcp 1251 & cls");

	char alphabet[] = { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к',	'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х',
		'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ж', 'З', 'И', 'Й', 'К',
		'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я', '-', ',', ' ',
		'!', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
	const int A_S = sizeof(alphabet);

	char wordKey2[] = { '4', '1', '2', '5'}, wordKey2s[sizeof(wordKey2)];
	char wordKey1[] = { 'С', 'К', 'А', 'Н', 'Е', 'Р' }, wordKey1s[sizeof(wordKey1)];

#pragma region initializations
	int const rowNumber = sizeof(wordKey2); // количество строк
	int const colNumber = sizeof(wordKey1); // количество столбцов

	char someSentence[rowNumber * colNumber + 1] = { "СИСТЕМНЫЙ ПАРОЛЬ ИЗМЕНЕН" };
	char encryptedSentence[sizeof(someSentence)];
	char decryptedSentence[sizeof(someSentence)];

	// Сохраним исходные ключи для последующего использования в шифровке
	for (int i = 0; i < rowNumber; i++)
		wordKey2s[i] = wordKey2[i];
	for (int i = 0; i < colNumber; i++)
		wordKey1s[i] = wordKey1[i];
	
	char encrTable[rowNumber][colNumber];

	std::cout << "Исходная строка: " << someSentence << std::endl << std::endl;

#pragma endregion

#pragma region encrypting

// Заполнение таблицы
	int currentCarriagePos = 0;
	for (int I = 0; I < rowNumber; I++) {
		for (int J = 0; J < colNumber; J++) {
			encrTable[I][J] = someSentence[currentCarriagePos];
			currentCarriagePos++;
		}
	}

	// Вывод таблицы
	std::cout << "Таблица с исходным текстом: " << std::endl;
	for (int I = 0; I < rowNumber; I++) {
		for (int J = 0; J < colNumber; J++) {
			std::cout << encrTable[I][J];
		}
		std::cout << std::endl;
	}
	std::cout << std::endl;

	int wordLetterCarriage1;
	int wordLetterCarriage2;

	// сортируем пузырьком первый ключ и столбцы таблицы
	for (int i = 0; i < colNumber; i++) {
		// перебор каждой буквы одной строки таблицы (перебор столбцов)
		for (int i = 0; i < colNumber - 1; i++) {
			// позиции букв слова в алфавите
			for (int j = 0; j < A_S; j++) {
				if (wordKey1s[i] == alphabet[j]) {
					wordLetterCarriage1 = j;
				}
				if (wordKey1s[i + 1] == alphabet[j]) {
					wordLetterCarriage2 = j;
				}
			}
			// Если первая буква "больше" чем вторая в алфавите
			if (wordLetterCarriage1 > wordLetterCarriage2) {
				// меняем местами буквы в ключе
				char temp = wordKey1s[i];
				wordKey1s[i] = wordKey1s[i + 1];
				wordKey1s[i + 1] = temp;

				// перебор каждой буквы одного столбца таблицы (перебор строк)
				for (int j = 0; j < rowNumber; j++) {
					// меняем местами буквы двух соседних столбцов
					temp = encrTable[j][i];
					encrTable[j][i] = encrTable[j][i + 1];
					encrTable[j][i + 1] = temp;
				}
			}
		}
	}

	std::cout << "Таблица после перестановки столбцов: " << std::endl;
	for (int I = 0; I < rowNumber; I++) {
		bool needBreak = 0;

		for (int J = 0; J < colNumber; J++) {
			if (encrTable[I][J] == '\0') {
				needBreak = 1;
				break;
			}

			std::cout << encrTable[I][J];
		}

		if (needBreak == 1)
			break;

		std::cout << std::endl;
	}
	std::cout << std::endl;

	// сортируем пузырьком второй ключ и строки таблицы
	for (int i = 0; i < rowNumber; i++) {
		// перебор каждой буквы одного столбца таблицы (перебор строк)
		for (int i = 0; i < rowNumber - 1; i++) {
			// позиции букв слова в алфавите
			for (int j = 0; j < A_S; j++) {
				if (wordKey2s[i] == alphabet[j]) {
					wordLetterCarriage1 = j;
				}
				if (wordKey2s[i + 1] == alphabet[j]) {
					wordLetterCarriage2 = j;
				}
			}
			// Если первая буква "больше" чем вторая в алфавите
			if (wordLetterCarriage1 > wordLetterCarriage2) {
				// меняем местами буквы в ключе
				char temp = wordKey2s[i];
				wordKey2s[i] = wordKey2s[i + 1];
				wordKey2s[i + 1] = temp;

				// перебор каждой буквы одной строки таблицы (перебор столбцов)
				for (int j = 0; j < colNumber; j++) {
					// меняем местами буквы двух строк
					temp = encrTable[i][j];
					encrTable[i][j] = encrTable[i + 1][j];
					encrTable[i + 1][j] = temp;
				}
			}
		}
	}

	std::cout << "Таблица после перестановки строк(зашифрованная): " << std::endl;
	for (int I = 0; I < rowNumber; I++) {
		bool needBreak = 0;

		for (int J = 0; J < colNumber; J++) {
			if (encrTable[I][J] == '\0') {
				needBreak = 1;
				break;
			}

			std::cout << encrTable[I][J];
		}

		if (needBreak == 1)
			break;

		std::cout << std::endl;
	}
	std::cout << std::endl;

	// Считываем таблицу по столбцам в новую строку, это зашифрованная строка
	int carriage = 0;
	for (int I = 0; I < colNumber; I++) {
		for (int J = 0; J < rowNumber; J++) {
			if (encrTable[J][I] == '\0')
				break;

			encryptedSentence[carriage] = encrTable[J][I];
			carriage++;

			// Если все символы вставлены в строку, то вставляем в конец символ окончания строки
			if (carriage == rowNumber * colNumber)
				encryptedSentence[carriage] = '\0';
		}
	}

	std::cout << "Зашифрованная строка: " << encryptedSentence << std::endl << std::endl;

#pragma endregion

#pragma region decrypting

	// Обратная перестановка строк
	// Повторить перестановку столько раз, сколько элементов в ключе
	for (int y = 0; y < rowNumber; y++) {

		// перебор ключа (измененный)
		for (int i = 0; i < rowNumber; i++) {
			// перебор старого ключа (без изменений)
			for (int j = 0; j < rowNumber; j++) {
				// Если значение переменной 2ключа совпадает со зн. 1люча, то меняем строки таблицы местами
				if (wordKey2s[i] == wordKey2[j]) {
					// Если номер переменной 2ключа совпадает с ном. 1ключа, то прерываем цикл
					if (i == j)
						break;
					// переставляем ключ

					char temp;

					// переставляем ключ
					temp = wordKey2s[i];
					wordKey2s[i] = wordKey2s[j];
					wordKey2s[j] = temp;

					for (int z = 0; z < colNumber; z++) {
						temp = encrTable[i][z];
						encrTable[i][z] = encrTable[j][z];
						encrTable[j][z] = temp;
					}
				}
			}
		}

	}

	// Вывод таблицы
	std::cout << "Таблица после обратной перестановки строк: " << std::endl;
	for (int I = 0; I < rowNumber; I++) {
		bool needBreak = 0;

		for (int J = 0; J < colNumber; J++) {
			if (encrTable[I][J] == '\0') {
				needBreak = 1;
				break;
			}

			std::cout << encrTable[I][J];
		}

		if (needBreak == 1)
			break;

		std::cout << std::endl;
	}
	std::cout << std::endl;

	// Обратная перестановка столбцов
	// Повторить перестановку столько раз, сколько элементов в ключе
	for (int y = 0; y < colNumber; y++) {

		// перебор ключа (измененный)
		for (int i = 0; i < colNumber; i++) {
			// перебор старого ключа (без изменений)
			for (int j = 0; j < colNumber; j++) {
				// Если значение переменной 2ключа совпадает со зн. 1люча, то меняем строки таблицы местами
				if (wordKey1s[i] == wordKey1[j]) {
					// Если номер переменной 2ключа совпадает с ном. 1ключа, то прерываем цикл
					if (i == j)
						break;

					char temp;

					// переставляем значения переменных ключа
					temp = wordKey1s[i];
					wordKey1s[i] = wordKey1s[j];
					wordKey1s[j] = temp;

					// меняем столбцы местами			
					for (int z = 0; z < rowNumber; z++) {
						temp = encrTable[z][i];
						encrTable[z][i] = encrTable[z][j];
						encrTable[z][j] = temp;
					}
				}
			}
		}

	}

	// Вывод таблицы
	std::cout << "Таблица после обратной перестановки столбцов(расшифрованная): "  << std::endl;
	for (int I = 0; I < rowNumber; I++) {
		bool needBreak = 0;

		for (int J = 0; J < colNumber; J++) {
			if (encrTable[I][J] == '\0') {
				needBreak = 1;
				break;
			}

			std::cout << encrTable[I][J];
		}

		if (needBreak == 1)
			break;

		std::cout << std::endl;
	}
	std::cout << std::endl;

	// Считываем таблицу по столбцам в новую строку, это расшифрованная строка
	carriage = 0;
	for (int I = 0; I < rowNumber; I++) {
		for (int J = 0; J < colNumber; J++) {
			if (encrTable[I][J] == '\0')
				break;

			decryptedSentence[carriage] = encrTable[I][J];
			carriage++;

			// Если все символы вставлены в строку, то вставляем в конец символ окончания строки
			if (carriage == rowNumber * colNumber)
				decryptedSentence[carriage] = '\0';
		}
	}

	std::cout << "Расшифрованная строка: " << decryptedSentence << std::endl << std::endl;

#pragma endregion

	system("pause");
	return 0;
}
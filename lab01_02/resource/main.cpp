// ��������� ������� � ������� ������������� �� ����� 
#include <string>
#include <iostream>

int main() {
	system("chcp 1251 & cls");

	char alphabet[] = { '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�',	'�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�',
		'�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�',
		'�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '�', '-', ',', ' ',
		'!', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
	const int A_S = sizeof(alphabet);

	char wordKey2[] = { '4', '1', '2', '5'}, wordKey2s[sizeof(wordKey2)];
	char wordKey1[] = { '�', '�', '�', '�', '�', '�' }, wordKey1s[sizeof(wordKey1)];

#pragma region initializations
	int const rowNumber = sizeof(wordKey2); // ���������� �����
	int const colNumber = sizeof(wordKey1); // ���������� ��������

	char someSentence[rowNumber * colNumber + 1] = { "��������� ������ �������" };
	char encryptedSentence[sizeof(someSentence)];
	char decryptedSentence[sizeof(someSentence)];

	// �������� �������� ����� ��� ������������ ������������� � ��������
	for (int i = 0; i < rowNumber; i++)
		wordKey2s[i] = wordKey2[i];
	for (int i = 0; i < colNumber; i++)
		wordKey1s[i] = wordKey1[i];
	
	char encrTable[rowNumber][colNumber];

	std::cout << "�������� ������: " << someSentence << std::endl << std::endl;

#pragma endregion

#pragma region encrypting

// ���������� �������
	int currentCarriagePos = 0;
	for (int I = 0; I < rowNumber; I++) {
		for (int J = 0; J < colNumber; J++) {
			encrTable[I][J] = someSentence[currentCarriagePos];
			currentCarriagePos++;
		}
	}

	// ����� �������
	std::cout << "������� � �������� �������: " << std::endl;
	for (int I = 0; I < rowNumber; I++) {
		for (int J = 0; J < colNumber; J++) {
			std::cout << encrTable[I][J];
		}
		std::cout << std::endl;
	}
	std::cout << std::endl;

	int wordLetterCarriage1;
	int wordLetterCarriage2;

	// ��������� ��������� ������ ���� � ������� �������
	for (int i = 0; i < colNumber; i++) {
		// ������� ������ ����� ����� ������ ������� (������� ��������)
		for (int i = 0; i < colNumber - 1; i++) {
			// ������� ���� ����� � ��������
			for (int j = 0; j < A_S; j++) {
				if (wordKey1s[i] == alphabet[j]) {
					wordLetterCarriage1 = j;
				}
				if (wordKey1s[i + 1] == alphabet[j]) {
					wordLetterCarriage2 = j;
				}
			}
			// ���� ������ ����� "������" ��� ������ � ��������
			if (wordLetterCarriage1 > wordLetterCarriage2) {
				// ������ ������� ����� � �����
				char temp = wordKey1s[i];
				wordKey1s[i] = wordKey1s[i + 1];
				wordKey1s[i + 1] = temp;

				// ������� ������ ����� ������ ������� ������� (������� �����)
				for (int j = 0; j < rowNumber; j++) {
					// ������ ������� ����� ���� �������� ��������
					temp = encrTable[j][i];
					encrTable[j][i] = encrTable[j][i + 1];
					encrTable[j][i + 1] = temp;
				}
			}
		}
	}

	std::cout << "������� ����� ������������ ��������: " << std::endl;
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

	// ��������� ��������� ������ ���� � ������ �������
	for (int i = 0; i < rowNumber; i++) {
		// ������� ������ ����� ������ ������� ������� (������� �����)
		for (int i = 0; i < rowNumber - 1; i++) {
			// ������� ���� ����� � ��������
			for (int j = 0; j < A_S; j++) {
				if (wordKey2s[i] == alphabet[j]) {
					wordLetterCarriage1 = j;
				}
				if (wordKey2s[i + 1] == alphabet[j]) {
					wordLetterCarriage2 = j;
				}
			}
			// ���� ������ ����� "������" ��� ������ � ��������
			if (wordLetterCarriage1 > wordLetterCarriage2) {
				// ������ ������� ����� � �����
				char temp = wordKey2s[i];
				wordKey2s[i] = wordKey2s[i + 1];
				wordKey2s[i + 1] = temp;

				// ������� ������ ����� ����� ������ ������� (������� ��������)
				for (int j = 0; j < colNumber; j++) {
					// ������ ������� ����� ���� �����
					temp = encrTable[i][j];
					encrTable[i][j] = encrTable[i + 1][j];
					encrTable[i + 1][j] = temp;
				}
			}
		}
	}

	std::cout << "������� ����� ������������ �����(�������������): " << std::endl;
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

	// ��������� ������� �� �������� � ����� ������, ��� ������������� ������
	int carriage = 0;
	for (int I = 0; I < colNumber; I++) {
		for (int J = 0; J < rowNumber; J++) {
			if (encrTable[J][I] == '\0')
				break;

			encryptedSentence[carriage] = encrTable[J][I];
			carriage++;

			// ���� ��� ������� ��������� � ������, �� ��������� � ����� ������ ��������� ������
			if (carriage == rowNumber * colNumber)
				encryptedSentence[carriage] = '\0';
		}
	}

	std::cout << "������������� ������: " << encryptedSentence << std::endl << std::endl;

#pragma endregion

#pragma region decrypting

	// �������� ������������ �����
	// ��������� ������������ ������� ���, ������� ��������� � �����
	for (int y = 0; y < rowNumber; y++) {

		// ������� ����� (����������)
		for (int i = 0; i < rowNumber; i++) {
			// ������� ������� ����� (��� ���������)
			for (int j = 0; j < rowNumber; j++) {
				// ���� �������� ���������� 2����� ��������� �� ��. 1����, �� ������ ������ ������� �������
				if (wordKey2s[i] == wordKey2[j]) {
					// ���� ����� ���������� 2����� ��������� � ���. 1�����, �� ��������� ����
					if (i == j)
						break;
					// ������������ ����

					char temp;

					// ������������ ����
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

	// ����� �������
	std::cout << "������� ����� �������� ������������ �����: " << std::endl;
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

	// �������� ������������ ��������
	// ��������� ������������ ������� ���, ������� ��������� � �����
	for (int y = 0; y < colNumber; y++) {

		// ������� ����� (����������)
		for (int i = 0; i < colNumber; i++) {
			// ������� ������� ����� (��� ���������)
			for (int j = 0; j < colNumber; j++) {
				// ���� �������� ���������� 2����� ��������� �� ��. 1����, �� ������ ������ ������� �������
				if (wordKey1s[i] == wordKey1[j]) {
					// ���� ����� ���������� 2����� ��������� � ���. 1�����, �� ��������� ����
					if (i == j)
						break;

					char temp;

					// ������������ �������� ���������� �����
					temp = wordKey1s[i];
					wordKey1s[i] = wordKey1s[j];
					wordKey1s[j] = temp;

					// ������ ������� �������			
					for (int z = 0; z < rowNumber; z++) {
						temp = encrTable[z][i];
						encrTable[z][i] = encrTable[z][j];
						encrTable[z][j] = temp;
					}
				}
			}
		}

	}

	// ����� �������
	std::cout << "������� ����� �������� ������������ ��������(��������������): "  << std::endl;
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

	// ��������� ������� �� �������� � ����� ������, ��� �������������� ������
	carriage = 0;
	for (int I = 0; I < rowNumber; I++) {
		for (int J = 0; J < colNumber; J++) {
			if (encrTable[I][J] == '\0')
				break;

			decryptedSentence[carriage] = encrTable[I][J];
			carriage++;

			// ���� ��� ������� ��������� � ������, �� ��������� � ����� ������ ��������� ������
			if (carriage == rowNumber * colNumber)
				decryptedSentence[carriage] = '\0';
		}
	}

	std::cout << "�������������� ������: " << decryptedSentence << std::endl << std::endl;

#pragma endregion

	system("pause");
	return 0;
}
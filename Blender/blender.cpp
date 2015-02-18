#include <fstream>
#include <iostream>
#include <string>
#include <bitset>
#include <sstream>

int main()
{
	std::ifstream fin("input.txt");
	std::string temp;
	std::getline(fin, temp);
	std::stringstream stream(temp);
	std::string output;

	while (stream.good())
	{
		std::bitset<8> bits;

		stream >> bits;

		char c = char(bits.to_ulong());
		output += c;
	}

	std::cout << output;

	fin.close();
	system("pause");

	return 0;
}
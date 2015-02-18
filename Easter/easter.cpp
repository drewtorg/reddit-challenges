#include <iostream>
#include <string>

std::string computus(int);
std::string convertMonth(int);

int main()
{
	std::cout << "Welcome to the Easter Calculator!" << std::endl;

	while (true)
	{
		std::cout << "Enter a year: ";

		int year;
		std::cin >> year;

		std::string output = computus(year);

		std::cout << "Easter falls on " << output << std::endl <<std::endl;

		system("pause");

		std::cout << std::endl;
	}

	return 0;
}

std::string computus(int year)
{
	std::string output;

	int a = year % 19;
	int b = std::floor(year / 100);
	int c = year % 100;
	int d = std::floor(b / 4);
	int e = b % 4;
	int f = std::floor((b + 8) / 25);
	int g = std::floor((b - f + 1) / 3);
	int h = (19 * a + b - d - g + 15) % 30;
	int i = std::floor(c / 4);
	int k = c % 4;
	int L = (32 + 2 * e + 2 * i - h - k) % 7;
	int m = std::floor((a + 11 * h + 22 * L) / 451);
	int month = floor((h + L - 7 * m + 115) / 31);
	int day = ((h + L - 7 * m + 114) % 31) + 1;

	output += std::to_string(day) + " " + convertMonth(month) +" " + std::to_string(year);

	return output;
}

std::string convertMonth(int month)
{
	if (month == 1)
		return "January";
	else if (month == 2)
		return "February";
	else if (month == 3)
		return "March";
	else if (month == 4)
		return "April";
	else if (month == 5)
		return "May";
	else if (month == 6)
		return "June";
	else if (month == 7)
		return "July";
	else if (month == 8)
		return "August";
	else if (month == 9)
		return "September";
	else if (month == 10)
		return "October";
	else if (month == 11)
		return "November";
	else if (month == 12)
		return "December";
}
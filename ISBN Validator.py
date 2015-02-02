import random

def isValidISBN(isbn):
	sum = 0
	count = 10
	for num in isbn:
		if num == 'X':
			sum += 10
		else:
			sum += int(num) * count
		count -= 1
	return sum % 11 == 0

def generateISBN():
	random.seed()
	isbn = ''
	
	#generate the first random 9 digits
	for i in range(9):
		num = random.randint(0, 9)
		isbn += str(num)
	
	#generate the last digit so it becomes valid
	for i in range(11):
		if i == 10:
			if isValidISBN(isbn + 'X'):
				return isbn + 'X'
		if isValidISBN(isbn + str(i)):
			return isbn + str(i)

import random

def fight(pword, aiword):
	word1 = pword
	word2 = aiword
	output = word1 + ' vs. ' + word2 + ' -- '

	for letter in pword:
		if letter in aiword:
			word1 = word1.replace(letter, '', 1)
			word2 = word2.replace(letter, '', 1)


	playerScore = len(word1)
	AIscore = len(word2)

	if playerScore > AIscore:
		output += 'You Win.\n'

	elif AIscore > playerScore:
		output += 'Computer Wins.\n'

	else:
		output += 'Tie.\n'

	print output

	print 'You had ' + word1 + ' left over - you score ' + str(playerScore) + ' points'
	print 'AI had ' + word2 + ' left over - AI scores ' + str(AIscore) + ' points\n'

	return [playerScore, AIscore]

def print_letters(letters):
	output = 'Your letters:'
	for letter in letters:
		output += ' ' + letter
	print output

#refresh the letter pool with 12 new letters
def refresh_letters(letters):
	for i in range(len(letters)):
		newLetter = chr(random.randrange(ord('a'), ord('z') + 1))
		while newLetter in letters:
			newLetter = chr(random.randrange(ord('a'), ord('z') + 1))
		letters[i] = newLetter

	letters.sort()

def is_valid_word(word, letters, wordlist):
	for letter in word:
		if not letter in letters:
			return False

	word += '\n'

	if word in wordlist:
		return True

	return False

def is_valid_ai(word, letters):
	for letter in word:
		if not letter in letters:
			return False

	return True


def play():
	f = open('wlist_match7.txt')
	wordlist = list(f)
	f.close()

	done = False

	while not done:

		letters = ['','','','','','','','','','','','']
		turn = 1
		p1score = 0
		p2score = 0

		print 'Welcome to Words with Enemies!'

		difficulty = int(raw_input('What level are you? (1, 2, 3): '))

		while turn <= 5: 

			refresh_letters(letters)

			print 'Turn ' + str(turn) + ' -- Points You: ' + str(p1score) + ' Computer: ' + str(p2score)
			print '-----------------------------------------'
			print_letters(letters)

			word = raw_input('Your word-> ')

			while not is_valid_word(word, letters, wordlist):
				print 'I am sorry but you cannot spell ' + word + ' with your letters. Try again.'
				print_letters(letters)
				word = raw_input('Your word-> ')

			print 'Valid Word! Open Fire!!!!'

			AIword = generate_word(letters, wordlist, difficulty)

			print 'AI selects "' + AIword + '"\n'
			result = fight(word, AIword)
			p1score += result[0]
			p2score += result[1]

			turn += 1
		print 'Final Score -- ' + 'You: ' + str(p1score) + ' Computer: ' + str(p2score)
		if p1score > p2score:
			print 'You win!'
		elif p2score > p1score:
			print 'Computer wins!'
		else:
			print "It's a tie!"

		if not raw_input('Play again? (y/n)').lower() == 'y':
			done = True


#make a word taken from a dictionary with the letters we have
def generate_word(letters, wordlist, difficulty):
	max_len = 0
	if difficulty == 1:
		max_len = 5
	elif difficulty == 2:
		max_len = 7
	else:
		max_len = 100

	longest = ''
	for test in wordlist:
		test = test.replace('\n', '')
		if is_valid_ai(test, letters) and len(test) > len(longest) and len(test) <= max_len:
			longest = test
	return longest

play()
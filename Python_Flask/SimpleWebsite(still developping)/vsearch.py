
def searchForLetters(phrase: str, letters: str = 'aeiou') -> set:
    """wyszukuje litery podane w argumencie w podanym slowie"""
    return set(letters).intersection(set(phrase))

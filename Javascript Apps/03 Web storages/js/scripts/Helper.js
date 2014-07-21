(function () {
    'use strict';

    define(function () {
        if (!Array.prototype.shuffleLast) {
            //Fisher–Yates shuffle - http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
            //Shuffles only the last N elements
            Array.prototype.shuffleLast = function shuffleLast(count) {
                var pointer = this.length - 1,
                    arrayLength = this.length,
                    randomNumber,
                    tempNumber;

                if (count > arrayLength) {
                    throw new Error('Last elements count to shuffle is bigger than the array length!');
                }

                while (pointer > (arrayLength - 1 - count)) {
                    randomNumber = parseInt(Math.random() * arrayLength);
                    tempNumber = this[pointer];
                    this[pointer] = this[randomNumber];
                    this[randomNumber] = tempNumber;
                    pointer--;
                }
            };
        }

        var getRandomNumber = function getRandomNumber(numberLength) {
            var possibleNumbers = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
                randomNumber = [],
                currentNumber,
                parsedNumber;

            if (!numberLength || numberLength <= 0 || numberLength > possibleNumbers.length) {
                throw new Error('Impossible random number length');
            }

            for (var i = 0; i < numberLength; i++) {
                possibleNumbers.shuffleLast(1);
                currentNumber = possibleNumbers.pop();

                //The first number cant be 0
                if (i === 0 && currentNumber === 0) {
                    i--;
                } else {
                    randomNumber.push(currentNumber);
                }
            }

            parsedNumber = parseInt(randomNumber.join(''));
            return parsedNumber;
        };

        var containsRepeatingCharacters = function containsRepeatingCharacters(str) {
            for (var i = 0, len = str.length; i < len; i++) {
                var char = str[i];

                if (str.split(char).length > 2) {
                    return true;
                }
            }

            return false;
        };

        return {
            getRandomNumber: getRandomNumber,
            containsRepeatingCharacters: containsRepeatingCharacters
        };
    });
}());
(function () {
    'use strict';

    define(['jquery', './Helper'], function ($, Helper) {
        var GameEngine = (function GameEngine() {
            var CLASHERS_MARGIN = 10,
                LEFT_CLASHER_CLASS = 'ram-clasher',
                RIGHT_CLASHER_CLASS = 'sheep-clasher',
                CLASHERS_HEIGHT = 210;

            function drawGameField() {
                var self = this;

                var $highScores = $('<ul/>')
                    .addClass('highScores')
                    .css({
                        'list-style-type': 'none'
                    });
                generateHighScoresList.call(self, $highScores);

                $('<img/>')
                    .attr("src", 'images/ram.png')
                    .addClass(RIGHT_CLASHER_CLASS)
                    .css({
                        'position': 'absolute',
                        'top': CLASHERS_MARGIN + 'px',
                        'z-index': '1000',
                        'right': CLASHERS_MARGIN + 'px',
                        'height': CLASHERS_HEIGHT + 'px'
                    })
                    .appendTo(this._gameContainer);

                $('<img/>')
                    .attr("src", 'images/sheep.png')
                    .addClass(LEFT_CLASHER_CLASS)
                    .css({
                        'position': 'absolute',
                        'top': CLASHERS_MARGIN + 'px',
                        'z-index': '1000',
                        'left': CLASHERS_MARGIN + 'px',
                        'height': CLASHERS_HEIGHT + 'px'
                    })
                    .appendTo(this._gameContainer);

                $('<h1/>')
                    .addClass('resultContainer')
                    .css({
                        'position': 'absolute',
                        'top': (CLASHERS_MARGIN + 50) + 'px',
                        'margin': '0 auto',
                        'text-align': 'center',
                        'width': '100%'
                    })
                    .appendTo(this._gameContainer);

                $('<div/>')
                    .css({
                        'margin-top': (CLASHERS_HEIGHT + CLASHERS_MARGIN + 50) + 'px',
                        'text-align': 'center'
                    })
                    .addClass('guessingArea')
                    .append(
                    $('<label/>')
                        .text('Input your number: ')
                        .append(
                        $('<input>')
                            .attr('class', 'guessedNumber')
                            .attr('type', 'text')
                            .attr('maxlength', '4')
                            .css({
                                'border-radius': '10px',
                                'padding': '5px'
                            })
                            .on('input', function (ev) {
                                var $input = $(ev.target),
                                    inputText;
                                inputText = $input.val();

                                if (isNaN($input.val()) ||
                                    inputText.length > 4 ||
                                    Helper.containsRepeatingCharacters(inputText) ||
                                    (inputText.length > 0 && inputText[0] === '0')) {
                                    $input.addClass('invalid');
                                    $input.removeClass('valid');
                                } else if ($input.val() !== '' && inputText.length === 4) {
                                    $input.removeClass('invalid');
                                    $input.addClass('valid');
                                } else {
                                    $input.removeClass('invalid');
                                    $input.removeClass('valid');
                                }
                            })
                    ))
                    .append(
                    $('<button/>')
                        .text('Guess')
                        .css({
                            'border-radius': '10px',
                            'padding': '5px'
                        })
                        .on('click', function (ev) {
                            checkInput.call(self);
                        }))
                    .append(
                    $('<button/>')
                        .text('Hint')
                        .css({
                            'border-radius': '10px',
                            'padding': '5px'
                        })
                        .on('click', function (ev) {
                            var hint = '',
                                padding = '';
                            if (self._hints.length < 3) {
                                self._hints.push((self._numberToGuess.toString())[self._hints.length]);
                            }

                            hint = self._hints.join('');
                            padding = new Array(4 - hint.length + 1).join('*');
                            $(self._gameContainer + ' input.guessedNumber').val(hint + padding);
                        }))
                    .append($highScores)
                    .appendTo(this._gameContainer);
            }

            function checkInput() {
                var inputNumber = $(this._gameContainer + ' input.guessedNumber'),
                    self = this,
                    inputText,
                    result;
                inputText = inputNumber.val();

                if (!isNaN(inputText) &&
                    inputText.length === 4 && !Helper.containsRepeatingCharacters(inputText) &&
                    inputText[0] !== '0') {
                    this._repeats++;
                    result = calculateResult(this._numberToGuess.toString(), inputText);
                    clashAnimation.call(this, function () {
                        displayResult(result);
                    });

                    if (result.rams === 4) {
                        $('<h1/>')
                            .text('You win! Save your achievment to the rank list! New game is loading!')
                            .prependTo('.guessingArea')
                            .fadeOut(1500, function () {
                                $(this).remove();
                                promptToSaveScore.call(self);
                            });
                    }
                }
            }

            function generateHighScoresList($highScores) {
                var len = this._highScores.length,
                    highScore;

                for (var i = 0; i < len; i++) {
                    highScore = this._highScores[i];
                    $highScores.append(
                        $('<li/>')
                            .text(highScore.name + ' - ' + highScore.repeats)
                            .css({
                                'border-bottom': '1px solid black'
                            })
                    );
                }
            }

            function updateHighScoreList() {
                var $highScoresEl = $(this._gameContainer + ' ul.highScores');
                $highScoresEl.empty();
                generateHighScoresList.call(this, $highScoresEl);
            }

            function promptToSaveScore() {
                var self = this;

                $('<div/>')
                    .css({
                        'position': 'absolute',
                        'top': '200px',
                        'width': '100%',
                        'z-index': '2000',
                        'border': '1px solid black',
                        'border-radius': '10px',
                        'text-align': 'center',
                        'margin': '0 auto',
                        'background-color': '#dee8de',
                        'padding-top': '100px',
                        'padding-bottom': '100px'
                    })
                    .append(
                    $('<input/>')
                        .attr('type', 'text')
                        .addClass('player-name')
                        .css({
                            'border-radius': '10px'
                        }))
                    .append(
                    $('<button/>')
                        .text('Save')
                        .css({
                            'border-radius': '10px'
                        })
                        .on('click', function (ev) {
                            var playerNameInput = $(ev.target).parent().find('.player-name'),
                                playerName;
                            playerName = playerNameInput.val().trim();

                            if (playerName.length > 0) {
                                saveHighScore.call(self, playerName, self._repeats);
                                updateHighScoreList.call(self);
                                resetArea.call(self);
                                $(ev.target).parent().remove();
                            }
                        }))
                    .append(
                    $('<button/>')
                        .text('Close')
                        .css({
                            'border-radius': '10px'
                        })
                        .on('click', function (ev) {
                            $(ev.target).parent().remove();
                            resetArea.call(self);
                        }))
                    .appendTo(self._gameContainer);
            }

            function saveHighScore(name, repeats) {
                this._highScores.push({
                    name: name,
                    repeats: repeats
                });

                this._highScores.sort(function (firstScore, secondScore) {
                    return firstScore.repeats - secondScore.repeats;
                });

                while (this._highScores.length > 10) {
                    this._highScores.pop();
                }

                localStorage.setItem('highScores', JSON.stringify(this._highScores));
            }

            function resetArea() {
                $(this._gameContainer + ' .guessingArea')
                    .removeClass('invalid')
                    .removeClass('valid')
                    .find('input.guessedNumber')
                    .val('');

                this._repeats = 0;
                this._numberToGuess = Helper.getRandomNumber(4);
                this._hints = [];
            }

            function displayResult(result) {
                $('.resultContainer')
                    .css('opacity', '0')
                    .text(result.sheeps + ' : ' + result.rams)
                    .animate({
                        opacity: 1
                    }, 1300);
            }

            function calculateResult(numberToGuess, inputText) {
                var pointer = 0,
                    sheeps = 0,
                    rams = 0,
                    len = inputText.length,
                    currentNumIndex;

                for (; pointer < len; pointer++) {
                    currentNumIndex = numberToGuess.indexOf(inputText[pointer]);

                    if (currentNumIndex == pointer) {
                        rams++;
                    } else if (currentNumIndex > -1) {
                        sheeps++;
                    }
                }

                return{
                    sheeps: sheeps,
                    rams: rams
                };
            }

            function loadHighScores() {
                var rawInformation = localStorage.getItem('highScores');

                if (rawInformation === null) {
                    this._highScores = [];
                } else {
                    this._highScores = JSON.parse(rawInformation);
                }
            }

            function clashAnimation(retreatAction) {
                var self = this;
                var $leftClasher = $(self._gameContainer + ' .' + LEFT_CLASHER_CLASS),
                    $rightClasher = $(self._gameContainer + ' .' + RIGHT_CLASHER_CLASS);

                $leftClasher.animate({
                    left: '+=' + ($(self._gameContainer).width() / 2 - $leftClasher.width())
                }, 1000, function () {
                    $(this).animate({
                        left: '-=' + ($(self._gameContainer).width() / 2 - $leftClasher.width())
                    }, 1000);

                    if (typeof retreatAction === 'function') {
                        retreatAction();
                    }
                });

                $rightClasher.animate({
                    right: '+=' + ($(self._gameContainer).width() / 2 - $rightClasher.width())
                }, 1000, function () {
                    $(this).animate({
                        right: '-=' + ($(self._gameContainer).width() / 2 - $rightClasher.width())
                    }, 1000);
                });
            }

            function GameEngine(gameContainer) {
                this._gameContainer = gameContainer;
                this._numberToGuess = Helper.getRandomNumber(4);
                this._hints = [];
                this._repeats = 0;
                this._highScores = [];
                console.log(this._numberToGuess);
            }

            GameEngine.prototype.start = function start() {
                loadHighScores.call(this);
                drawGameField.call(this);
            };

            return GameEngine;
        }());

        return GameEngine;
    });
}());
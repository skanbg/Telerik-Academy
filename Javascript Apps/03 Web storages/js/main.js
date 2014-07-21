(function () {
    'use strict';

    define(['jquery', './scripts/GameEngine', './scripts/Helper'], function ($, GameEngine, Helper) {
        var GAME_CONTAINER = '#game-container',
            gameEngine;
        gameEngine = new GameEngine(GAME_CONTAINER);
        $(function () {
            gameEngine.start();
        });
    });
}());
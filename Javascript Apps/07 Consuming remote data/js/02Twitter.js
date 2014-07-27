(function () {
    'use strict';

    requirejs.config({
        baseUrl: 'js/libs',
        paths: {
            'Q': 'q',
            'oauth': 'oauth',
            'jquery': 'jquery'
        }
    });

    define(['oauth', 'jquery'], function (OAuth, $) {
        OAuth.initialize('V6h61s4QL6dTyqroWoQCT_UD8uc');
        OAuth.popup('twitter', {cache: true})
            .then(function (result) {
                result.get('https://api.twitter.com/1.1/statuses/user_timeline.json')
                    .then(function (tweets) {
                        var tweetsList = $('<ul/>');
                        for (var i = 0, len = tweets.length; i < len; i++) {
                            var tweet = tweets[i];
                            $('<li/>')
                                .text(tweet.text)
                                .appendTo(tweetsList);
                        }

                        $('body')
                            .append($('<h2/>').text('Your tweets:'))
                            .append(tweetsList);
                    });

                return result;
            }, function (error) {
                $('<h1/>')
                    .text(error)
                    .css('color', 'red')
                    .appendTo('body')
                    .fadeOut(4000);
            })
            .then(function (result) {
                result.get('https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name=BillGates')
                    .then(function (tweets) {
                        var tweetsList = $('<ul/>');
                        for (var i = 0, len = tweets.length; i < len; i++) {
                            var tweet = tweets[i];
                            $('<li/>')
                                .text(tweet.text)
                                .appendTo(tweetsList);
                        }

                        $('body')
                            .append($('<h2/>').text('Bill Gates\'s tweets:'))
                            .append(tweetsList);
                    });

                return result;
            }, function (error) {
                $('<h1/>')
                    .text(error)
                    .css('color', 'red')
                    .appendTo('body')
                    .fadeOut(4000);
            })
    });
}());
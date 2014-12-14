var passport = require('passport'),
    messageHandler = require('./messageHandler');

module.exports = {
    login: function (req, res, next) {
        var auth = passport.authenticate('local', function (err, user) {
            if (err) return next(err);
            if (!user) {
                messageHandler.addErrorMessage('Wrong credentials!');
                res.redirect('/login');
            }

            req.logIn(user, function (err) {
                if (err) return next(err);
                messageHandler.addSuccessMessage('You are successfully logged in!');
                res.redirect('/');
            })
        });

        auth(req, res, next);
    },
    logout: function (req, res, next) {
        req.logout();
        messageHandler.addInformationMessage('You are logged out!');
        res.redirect('/');
    },
    isAuthenticated: function (req, res, next) {
        if (!req.isAuthenticated()) {
            messageHandler.addErrorMessage('Please, login first!');
            res.redirect('/login');
        }
        else {
            next();
        }
    },
    isInRole: function (role) {
        return function (req, res, next) {
            if (req.isAuthenticated() && req.user.roles.indexOf(role) > -1) {
                next();
            }
            else {
                messageHandler.addErrorMessage('You have no permissions to do this!');
                res.redirect('/');
            }
        }
    }
};
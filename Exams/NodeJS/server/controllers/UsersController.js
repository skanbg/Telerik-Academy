var config = require('../config/common');
var encryption = require('../utilities/encryption'),
    users = require('../data/UsersData'),
    uploading = require('../utilities/uploading'),
    messageHandler = require(config.localPaths.configs + '/messageHandler'),
    initiatives = require('../data/initiativesData'),
    CONTROLLER_NAME = 'users';

function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

function cleanArray(actual) {
    if (typeof actual === 'string') {
        actual = [actual];
    }

    var newArray = new Array();
    for (var i = 0; i < actual.length; i++) {
        if (actual[i]) {
            newArray.push(actual[i]);
        }
    }
    return newArray;
}

module.exports = {
    getRegister: function (req, res) {
        var data = {
            initiatives: initiatives.getInitiatives()
        };

        if (data.initiatives.length === 0) {
            messageHandler.addInformationMessage('Currently there are no initiatives that you can participate! Please try to register later');
            res.redirect('/');
        }

        res.render(CONTROLLER_NAME + '/register', data);
    },
    postRegister: function (req, res) {
        var newUserData = req.body;
        console.log('============initiatives=============');
        console.log(newUserData.initiative_0);
        console.log('============seasons=============');
        console.log(newUserData.season_0);
        console.log('=========================');
        newUserData.initiative_0 = cleanArray(newUserData.initiative_0);
        newUserData.season_0 = cleanArray(newUserData.season_0);
        newUserData.initiatives = [];
        newUserData.seasons = [];

        var initiativesCount = newUserData.initiative_0.length;
        var seasonsCount = newUserData.season_0.length;

//        console.log('============initiatives=============');
//        console.log(newUserData.initiative_0);
//        console.log('============seasons=============');
//        console.log(newUserData.season_0);
//        console.log('=========================');

        if (initiativesCount !== seasonsCount) {
            console.log('============initiatives=============');
            console.log(newUserData.initiative_0);
            console.log('============seasons=============');
            console.log(newUserData.season_0);
            console.log('=========================');
            messageHandler.addErrorMessage('Please dont hack us!');
            res.redirect('/register');
        } else {

            var allInitiatives = initiatives.getInitiatives();
//            console.log(allInitiatives);
//            console.log(newUserData.initiative_0);
            for (var i = 0, len = Math.min(initiativesCount, seasonsCount); i < len; i++) {
                var season = newUserData.season_0[i],
                    initiative = newUserData.initiative_0[i];

                if (!isBlank(season) && !isBlank(initiative) &&
                    allInitiatives.indexOf(initiative) > -1) {
                    newUserData.initiatives.push(initiative);
                    newUserData.seasons.push(season);
                }
            }
//            for (var initiative in newUserData.initiative_0) {
//                newUserData.initiatives = [];
//                newUserData.seasons = [];
//                if (initiatives.getInitiatives().indexOf(newUserData.initiative_0[initiative]) > -1) {
//                    newUserData.initiatives.push(newUserData.initiative_0[initiative]);
//                    newUserData.seasons.push(newUserData.initiative_0[initiative]);
//                }
//            }

            if (newUserData.password !== newUserData.confirmPassword) {
                messageHandler.addErrorMessage('Passwords do not match!');
                res.redirect('/register');
            } else {
                newUserData.salt = encryption.generateSalt();
                newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
                users.create(newUserData, function (err, user) {
                    if (err) {
                        console.log('Failed to register new user: ' + err);
                        messageHandler.addErrorMessage('User already exists!');
                        res.redirect('/register');
                    } else {
                        req.logIn(user, function (err) {
                            if (err) {
                                messageHandler.addInformationMessage('You are successfully registered. Try to log in!');
                                res.redirect('/');
                            } else {
                                messageHandler.addSuccessMessage('You are successfully registered and logged in!');
                                res.redirect('/');
                            }
                        });
                    }
                });
            }
        }
    },
    getLogin: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    }
};
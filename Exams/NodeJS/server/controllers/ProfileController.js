var config = require('../config/common');
var encryption = require('../utilities/encryption'),
    users = require('../data/UsersData'),
    messageHandler = require(config.localPaths.configs + '/messageHandler'),
    CONTROLLER_NAME = 'profile';

var profileTemplate = {
};

function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

function fillProfileTemplate(template, data) {
//    console.log('TEMPLATE');
//    console.log(template);
//    console.log('DATA');
//    console.log(data);
//    console.log('=============');
    if (data) {
        if (data.phoneNumber) {
            template.phoneNumber = data.phoneNumber;
        }
        if (data.email) {
            template.email = data.email;
        }
        if (data.twitter) {
            template.twitter = data.twitter;
        }
        if (data.googlePlus) {
            template.googlePlus = data.googlePlus;
        }
        if (data.facebook) {
            template.facebook = data.facebook;
        }
        if (data.linkedIn) {
            template.linkedIn = data.linkedIn;
        }
        if (data.address) {
            template.address = data.address;
        }
    }

    return template;
}

function validateProfile(data) {
    var errors = [];

    if (isBlank(data.email)) {
        errors.push('Email cant be blank or empty!');
    } else if (isBlank(data.address)) {
        errors.push('Address cant be blank or empty!');
    }

    return errors;
}

module.exports = {
    getProfile: function (req, res, next) {
        var user = req.user;
        var data = fillProfileTemplate(profileTemplate, user);

        res.render(CONTROLLER_NAME + '/update', data);
    },
    updateProfile: function (req, res, next) {
        var user = req.user;
        var newProfileData = req.body;
        var validationResult = validateProfile(newProfileData);

        if (validationResult.length > 0) {
            for (var error in validationResult) {
                messageHandler.addErrorMessage(validationResult[error]);
            }

            res.redirect(CONTROLLER_NAME);
            return;
        } else {
            var data = fillProfileTemplate(user, newProfileData);

            users.updateProfile(data, function () {
                messageHandler.addSuccessMessage('Profile updated!');
                res.redirect(CONTROLLER_NAME);
            });
        }
    }
};
var config = require('../config/common');

var encryption = require('../utilities/encryption'),
    uploading = require('../utilities/uploading'),
    events = require('../data/eventsData'),
    messageHandler = require(config.localPaths.configs + '/messageHandler'),
    CONTROLLER_NAME = 'events',
    URL_PASSWORD = 'magic unicorns';

function isBlank(str) {
    return (!str || /^\s*$/.test(str));
}

function canParticipate(currentUser, event) {
    if (event.type === 'public') {
        console.log(0);
        return true;
    } else if (event.type === 'initiative') {
        if (!currentUser.initiatives || currentUser.initiatives.length === 0) {
            console.log(95);
            return false;
        } else if (currentUser.initiatives.indexOf(event.initiative) === -1) {
            console.log(96);
            return false;
        }

        console.log(1);
        return true;
    } else if (event.type === 'initiative-season') {
        if (!currentUser.initiatives || currentUser.initiatives.length === 0) {
            console.log(97);
            return false;
        }

        var initiativeId = currentUser.initiatives.indexOf(event.initiative);

        if (initiativeId === -1) {
            console.log(98);
            return false;
        } else if (currentUser.seasons.length < initiativeId + 1) {
            console.log(99);
            return false;
        } else if (currentUser.seasons[initiativeId] !== event.season) {
            console.log('100');
            return false;
        }

        console.log(2);
        return true;
    }
}

module.exports = {
    getPast: function (req, res, next) {
        events.getPast(function (events) {
            var data = {
                events: events
            };

            res.render(CONTROLLER_NAME + '/past', data);
        });
    },
    getActive: function (req, res, next) {
        var user = req.user;
        events.getActive(function (events) {

            for (var i = 0, len = events.length; i < len; i++) {
//                console.log(events[i].creator._id);
//                console.log(user._id);
//                console.log(events[i].creator !== user);
//                console.log(events[i].creator._id === user._id);
                console.log(events[i].creator._id != user._id);
                events[i].joinAllowed = events[i].creator._id != user._id && canParticipate(user, events[i]);
            }

            var data = {
                events: events
            };

//            console.log(data);

            res.render(CONTROLLER_NAME + '/active', data);
        });
    },
    getCreate: function (req, res, next) {
        var user = req.user;

        if (!user.phoneNumber) {
            messageHandler.addErrorMessage('Please update your profile and add phone number to create event!');
            res.redirect(CONTROLLER_NAME + '/profile');
        } else {
            var data = {categories: events.getCategories(),
                user: {
                    initiatives: user.initiatives,
                    seasons: user.seasons
                }};
            res.render(CONTROLLER_NAME + '/create', data);
        }
    },
    postEvent: function (req, res, next) {
        var user = req.user;
        var newEventData = req.body;
        newEventData.creator = user.username;
        newEventData.location = {
            latitude: newEventData.latitude,
            longitude: newEventData.longitude
        };
        newEventData.creator = user;

        if (!user.phoneNumber) {
            messageHandler.addErrorMessage('Please update your profile and add phone number to create event!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (isBlank(newEventData.title)) {
            messageHandler.addErrorMessage('Please set title!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (isBlank(newEventData.description)) {
            messageHandler.addErrorMessage('Please set description!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (isBlank(newEventData.latitude)) {
            messageHandler.addErrorMessage('Please set Latitude!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (isBlank(newEventData.longitude)) {
            messageHandler.addErrorMessage('Please set Longitude!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (isBlank(newEventData.category)) {
            messageHandler.addErrorMessage('Please set category!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (events.getCategories().indexOf(newEventData.category) === -1) {
            messageHandler.addErrorMessage('Please dont try to hack us :(');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (isBlank(newEventData.type)) {
            messageHandler.addErrorMessage('Please set type!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (newEventData.type === 'initiative' && isBlank(newEventData.initiative)) {
            messageHandler.addErrorMessage('Please set initiative!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (newEventData.type === 'initiative-season' && isBlank(newEventData.initiative)) {
            messageHandler.addErrorMessage('Please set initiative and/or assure that you are from the chosen season!');
            res.redirect(CONTROLLER_NAME + '/create');
        } else if (!canParticipate(user, newEventData)) {
            messageHandler.addErrorMessage('You are not participant in the season or the initiative!');
            res.redirect(CONTROLLER_NAME + '/create');
        }
        else {
            events.create(newEventData, function (err, event) {
                if (err) {
                    console.log('Failed to add new event: ' + err);
                    messageHandler.addErrorMessage('Something went wrong. Wait our monkeys to fix it!');
                    res.redirect('/events/create');
                } else {
                    console.log(event);
                    messageHandler.addSuccessMessage('Event successfuly added!');
                    res.redirect(CONTROLLER_NAME + '/create');
                }
            });
        }
    }
};
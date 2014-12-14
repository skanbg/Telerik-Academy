var config = require('../config/common');
var users = require('../data/UsersData'),
    messageHandler = require(config.localPaths.configs + '/messageHandler'),
    initiatives = require('../data/initiativesData'),
    events = require('../data/EventsData');

module.exports = {
    getIndex: function (req, res, next) {
        var data = {
            statistics: events.getEventsStatistics()
        };

        console.log(data);

        res.render('index', data);
    }
};
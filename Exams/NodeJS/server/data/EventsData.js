var Event = require('mongoose').model('Event');

var eventsStatistics = {
    eventsCount: 0,
    lastUpdate: 0,
    scoreOfAllPastEvents: 0,
    updatesMade: 0,
    allUpdatesCount: 2
};

function updateStatistics(callback) {
    updateStatistics.updatesMade = 0;

    Event.find({}, function (err, events) {
    })
        .exec(function (err, events) {
            if (err) {
                console.log(err);
                return;
            }

            eventsStatistics.eventsCount = events.length;
            eventsStatistics.updatesMade++;
            if (eventsStatistics.allUpdatesCount == eventsStatistics.allUpdatesCount) {
                eventsStatistics.lastUpdate = new Date();
                callback(eventsStatistics);
            }
        }
    );


    Event.find({"date": {"$lte": todayStartDate()}}, function (err, events) {
        callback(events);
    })
        .populate('creator')
        .exec(function (err, events) {
            if (err) {
                console.log(err);
                return;
            }

            for (var i = 0, len = events.length; i < len; i++) {
                var event = events[i];
                eventsStatistics.scoreOfAllPastEvents += event.creator.eventPoints;
            }

            eventsStatistics.updatesMade++;
            if (eventsStatistics.allUpdatesCount == eventsStatistics.allUpdatesCount) {
                eventsStatistics.lastUpdate = new Date();
                callback(eventsStatistics);
            }
        }
    );
}

function todayStartDate() {
    var todayDate = new Date();
    todayDate.setHours(0);
    todayDate.setMinutes(0);
    todayDate.setSeconds(0);

    return todayDate;
}

module.exports = {
    create: function (event, callback) {
        Event.create(event, callback);
    },
    getAll: function (callback) {
        Event.find({}, function (err, events) {
            callback(events);
        })
            .populate('creator')
            .exec(function (err, projects) {
            });
    },
    getActive: function (callback) {
        Event.find({"date": {"$gte": todayStartDate()}}, function (err, events) {
            callback(events);
        })
            .populate('creator')
            .exec(function (err, projects) {
            });
    },
    getPast: function (callback) {
        Event.find({"date": {"$lte": todayStartDate()}}, function (err, events) {
            callback(events);
        })
            .populate('creator')
            .exec(function (err, projects) {
            });
    },
    getCategories: function () {
        return ["Academy initiative", "Free time", "Beer pong"];
    },
    getEventsStatistics: function (callback) {
        if (!eventsStatistics) {
            updateStatistics(callback);
        } else {
            var lastUpdate = eventsStatistics.lastUpdate;
            var currentDate = new Date();
            var differenceInMinutes = (Math.round(((currentDate - lastUpdate % 86400000) % 3600000) / 60000));

            if (differenceInMinutes > 10) {
                updateStatistics(callback);
            } else {
                callback(eventsStatistics);
            }
        }
    }
};
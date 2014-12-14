var mongoose = require('mongoose');

module.exports = function (config) {
    mongoose.connect(config.db);
    var db = mongoose.connection;
    db.once('open', function (err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }
        console.log('Database up and running...')
    });
    db.on('error', function (err) {
        console.log('Database error: ' + err);
    });

    var UserModel = require('../data/models/User');
    UserModel.init();
    var FileModel = require('../data/models/File');
    FileModel.init();
    var EventModel = require('../data/models/Event');
    EventModel.init();
};
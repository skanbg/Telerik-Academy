var UsersController = require('./UsersController'),
    FilesController = require('./FilesController'),
    EventsController = require('./EventsController'),
    HomeController = require('./HomeController'),
    ProfileController = require('./ProfileController');

module.exports = {
    users: UsersController,
    files: FilesController,
    events: EventsController,
    home: HomeController,
    profile: ProfileController
};
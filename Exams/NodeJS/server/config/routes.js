var auth = require('./auth'),
    controllers = require('../controllers'),
    events = require('../data/EventsData');

var eventsStatistics = {
    eventsCount: 0,
    lastUpdate: 0,
    scoreOfAllPastEvents: 0,
    updatesMade: 0,
    allUpdatesCount: 2
};

module.exports = function (app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/profile', auth.isAuthenticated, controllers.profile.getProfile);
    app.post('/profile', auth.isAuthenticated, controllers.profile.updateProfile);

    app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);

    app.get('/events/past', auth.isAuthenticated, controllers.events.getPast);
    app.get('/events/active', auth.isAuthenticated, controllers.events.getActive);

    app.get('/events/create', auth.isAuthenticated, controllers.events.getCreate);
    app.post('/events/create', auth.isAuthenticated, controllers.events.postEvent);

    app.get('/', function (req, res) {
        events.getEventsStatistics(function (data) {
            eventsStatistics = data;
        });

        res.render('index', eventsStatistics);
    });

    app.get('*', function (req, res) {
        res.render('index');
    });
};
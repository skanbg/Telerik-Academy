var express = require('express'),
    bodyParser = require('body-parser'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    passport = require('passport'),
    busboy = require('connect-busboy'),
    messageHandler = require('./messageHandler');

module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', config.rootPath + '/server/views');
    app.use(cookieParser());
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({extended: true})); //extended: true parses the connection string
    app.use(busboy({immediate: false})); //immediate true concatenates multiple files
    app.use(session({secret: 'magic unicorns', resave: true, saveUninitialized: true})); //resave: true to overwrite existing ession
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(function (req, res, next) {
        messageHandler.detach();
        messageHandler.attach(app, req);
        messageHandler.exposeErrorMessages();
        messageHandler.exposeInformationMessages();
        messageHandler.exposeSuccessMessages();
        next();
    });
    app.use(express.static(config.rootPath + '/public'));
    app.use(function (req, res, next) {
        if (req.user) {
            app.locals.currentUser = req.user;
        } else {
            app.locals.currentUser = undefined;
        }

        next();
    });
};
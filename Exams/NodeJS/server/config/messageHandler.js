var request, application;

var helper = {
    isAttached: function isAttached() {
        if (request !== undefined && application !== undefined) {
            return true;
        }

        return false;
    },
    detach: function () {
        if (request) {
            if (request.session) {
                request.session.informations = undefined;
                request.session.errors = undefined;
                request.session.successes = undefined;
            }

            request = undefined;
        }

        if (application) {
            application = undefined;
        }
    }
};

module.exports = {
    addErrorMessage: function (errorMessage) {
        if (!helper.isAttached()) {
            throw new {message: 'Attach the error handler to the req and/or app if you are going to use it!'};
        }

        if (!request.session.errors) {
            request.session.errors = [];
        }

        request.session.errors.push(errorMessage);
    },
    addInformationMessage: function (informationMessage) {
        if (!helper.isAttached()) {
            throw new {message: 'Attach the error handler to the req and/or app if you are going to use it!'};
        }

        if (!request.session.informations) {
            request.session.informations = [];
        }

        request.session.informations.push(informationMessage);
    },
    addSuccessMessage: function (successMessage) {
        if (!helper.isAttached()) {
            throw new {message: 'Attach the error handler to the req and/or app if you are going to use it!'};
        }

        if (!request.session.successes) {
            request.session.successes = [];
        }

        request.session.successes.push(successMessage);
    },
    exposeErrorMessages: function () {
        if (request.session.errors) {
            application.locals.errors = function () {
                var messages = request.session.errors;
                helper.detach();
                return messages;
            }
        } else {
            application.locals.errors = function () {
                return [];
            }
        }
    },
    exposeInformationMessages: function () {
        if (request.session.informations) {
            application.locals.informations = function () {
                var messages = request.session.informations;
                helper.detach();
                return messages;
            }
        } else {
            application.locals.informations = function () {
                return [];
            }
        }
    },
    exposeSuccessMessages: function () {
        if (request.session.successes) {
            application.locals.successes = function () {
                var messages = request.session.successes;
                helper.detach();
                return messages;
            }
        } else {
            application.locals.successes = function () {
                return [];
            }
        }
    },
    attach: function (app, req) {
        application = app;
        request = req;
        application.locals.informations = undefined;
        application.locals.errors = undefined;
        application.locals.successes = undefined;
    },
    detach: helper.detach
};
var User = require('mongoose').model('User');

module.exports = {
    create: function (user, callback) {
        User.create(user, callback);
    },
    updateProfile: function (user, callback) {
        var query = {"_id": user._id};
        var options = {new: true};
        console.log(user._id);
        user._id = undefined;
        User.findOneAndUpdate(query, user.toObject(), options, function (err, person) {
            if (err) {
                console.log('got an error');
                console.log(err);
            } else {
                user = person;
                callback();
                console.log('passed');
            }
        });
    }
};
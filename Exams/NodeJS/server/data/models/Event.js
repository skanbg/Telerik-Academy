var mongoose = require('mongoose');
var User = mongoose.model('User');

module.exports.init = function () {
    var eventsSchema = mongoose.Schema({
        title: String,
        description: String,
        location: {
            latitude: Number,
            longitude: Number
        },
        date: Date,
        category: String,
        type: String,
        creator: { type: mongoose.Schema.Types.ObjectId, ref: 'User' , required: true}
    });
    var Event = mongoose.model('Event', eventsSchema);
};
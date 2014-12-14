var path = require('path'),
    os = require('os');

var rootPath = path.normalize(__dirname + '/../../');
var configsPath = path.normalize(rootPath + '/server/config'),
    controllersPath = path.normalize(rootPath + '/server/controllers'),
    dataPath = path.normalize(rootPath + '/server/data'),
    utilitiesPath = path.normalize(rootPath + '/server/utilities'),
    viewsPath = path.normalize(rootPath + '/server/views');

module.exports = {
    localPaths: {
        root: rootPath,
        controllers: controllersPath,
        configs: configsPath,
        data: dataPath,
        utilities: utilitiesPath,
        views: viewsPath
    },
    sitePaths: {
        root: os.hostname()
    }
};
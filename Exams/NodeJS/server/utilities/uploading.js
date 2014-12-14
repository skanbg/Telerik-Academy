var fs = require('fs'),
    FILES_DIR = './files';

module.exports = {
    createDir: function (path, dirName) {
        dirName = dirName || '';
        fs.mkdirSync(FILES_DIR + path + dirName);
    },
    saveFile: function (file, path, fileName) {
        if (!fs.existsSync(FILES_DIR + path)) {
            this.createDir(path);
        }

        var fsStream = fs.createWriteStream(FILES_DIR + path + fileName);
        file.pipe(fsStream);
    }
};